using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Transloadit;
using Transloadit.Constants;
using Transloadit.Models.Assemblies;
using Transloadit.Models.Robots;
using Transloadit.Models.Robots.ImageManipulation;
using Transloadit.Tests.Fixtures;
using Transloadit.Tests.Infrastructure;
using Transloadit.Tests.Robots;
using Xunit;
using Xunit.Abstractions;

namespace Transloadit.Tests.Tests.Api.Assemblies
{
    // integration tests that exercise real AssemblyResponse payloads across lifecycle states — completed, failed,
    // canceled, listed — to catch deserialization/mapping bugs that hand-written offline JSON cannot. Running on
    // both TFMs also makes each a cross-engine (System.Text.Json vs Newtonsoft) differential check. No NotifyUrl.
    public class AssemblyLifecycleApiTests : TestBase
    {
        private readonly ITestOutputHelper _output;

        public AssemblyLifecycleApiTests(ITestOutputHelper output)
        {
            _output = output;
        }

        private static AssemblyRequest ImportResizeAssembly() => new AssemblyRequest
        {
            Steps = new Dictionary<string, RobotBase>
            {
                ["import"] = TestDataFactory.GetDemoHttpImportRobot(),
                ["resize"] = new ImageResizeRobot { Use = "import", Width = 75, Height = 75 },
            }
        };

        [Fact]
        public async Task CompletedAssembly_DeserializesAndPopulatesLifecycleFields()
        {
            var created = await TransloaditClient.Assemblies.CreateAsync(ImportResizeAssembly());
            var completed = await AssemblyTracker.WaitCompletionAsync(created);

            Assert.Equal(ResponseCodes.AssemblyCompleted, completed.Base.Ok);

            // dates parse to UTC — regression guard for the non-ISO "2020/01/09 12:02:06 GMT" format
            Assert.NotNull(completed.ExecutionStart);
            Assert.Equal(TimeSpan.Zero, completed.ExecutionStart.Value.Offset);
            Assert.NotNull(completed.StartDate);

            // durations are populated once the assembly has executed
            Assert.NotNull(completed.ExecutionDuration);
            Assert.True(completed.ExecutionDuration > 0);

            // usage is present; import-based assemblies have no user uploads, so the processed files land in results
            Assert.True(completed.BytesUsage > 0);
            Assert.NotNull(completed.Results);
            Assert.NotEmpty(completed.Results);

            FileResult file = null;
            foreach (var step in completed.Results)
            {
                if (step.Value != null && step.Value.Count > 0)
                {
                    file = step.Value[0];
                    break;
                }
            }

            // a real result file validates the size:long mapping against live data
            Assert.NotNull(file);
            Assert.True(file.Size > 0);
        }

        [Fact]
        public async Task FailedAssembly_NullLifecycleFieldsDoNotThrow()
        {
            var request = new AssemblyRequest
            {
                Steps = new Dictionary<string, RobotBase> { ["invalid"] = new NonExistentRobot() },
            };

            var response = await TransloaditClient.Assemblies.CreateAsync(request);

            Assert.Equal(400, response.Base.HttpCode);
            // execution never happened, so the API returns null — must deserialize to null, not throw or default
            Assert.Null(response.ExecutionStart);
            Assert.Null(response.ExecutionDuration);
        }

        [Fact]
        public async Task CanceledAssembly_DeserializesWithoutThrowing()
        {
            var created = await TransloaditClient.Assemblies.CreateAsync(ImportResizeAssembly());

            // cancel returns a real assembly response (canceled, or already-completed if it raced) — either shape
            // must deserialize; this is the only path that exercises the canceled-state payload
            var canceled = await TransloaditClient.Assemblies.CancelAsync(created.AssemblyId);

            Assert.NotNull(canceled.Base.Ok);
            _output.WriteLine($"cancel returned ok={canceled.Base.Ok}");
        }

        [Fact]
        public async Task AssemblyList_CompactItemsDeserialize()
        {
            var list = await TransloaditClient.Assemblies.GetListAsync(new AssemblyListRequest { PageSize = 5 });

            Assert.True(list.IsSuccessResponse());
            Assert.NotNull(list.Items);
            // the list mixes completed and in-progress assemblies (nullable execution_start/duration) — none may throw
            foreach (var item in list.Items)
            {
                Assert.False(string.IsNullOrEmpty(item.Id));
            }
        }

        [Fact]
        public async Task AssemblyList_RespectsPagesizeAndDateFilter()
        {
            var page = await TransloaditClient.Assemblies.GetListAsync(new AssemblyListRequest { PageSize = 2 });
            Assert.True(page.Items.Count <= 2, $"pagesize=2 must cap the page, got {page.Items.Count}");

            // no assembly can have been created in the future, so a future fromdate filters everything out
            var future = await TransloaditClient.Assemblies.GetListAsync(
                new AssemblyListRequest { FromDate = DateTime.UtcNow.AddDays(2) });
            Assert.Empty(future.Items);
        }

        [Fact]
        public async Task CompletedAssembly_ModelMapsEveryDataCarryingKey()
        {
            var handler = new CapturingHandler();
            var client = new TransloaditClient(
                Configuration.AuthKey,
                Configuration.AuthSecret,
                new TransloaditClientOptions { HttpClient = new HttpClient(handler) });

            var created = await client.Assemblies.CreateAsync(ImportResizeAssembly());
            var status = created;
            for (var i = 0; i < 40 && status.Base.Ok != ResponseCodes.AssemblyCompleted; i++)
            {
                await Task.Delay(1500);
                status = await client.Assemblies.GetAsync(created.AssemblyId);
            }

            var unmapped = ResponseCoverage.UnmappedTopLevelKeys(handler.LastResponseBody, typeof(AssemblyResponse));
            _output.WriteLine("AssemblyResponse does not map: " + string.Join(", ", unmapped));

            // regression guard: every key the API returns must be mapped, except a small reviewed allowlist.
            // notify_error is notify-feature only (always null without a notify url) and intentionally not modeled.
            var allowed = new HashSet<string> { "notify_error" };
            var unexpected = unmapped.Where(k => !allowed.Contains(k)).ToList();
            Assert.True(
                unexpected.Count == 0,
                "AssemblyResponse silently drops newly-returned API keys: " + string.Join(", ", unexpected));
        }
    }
}
