using System;
using System.Net.Sockets;
using System.Threading.Tasks;
using Transloadit.Models;
using Transloadit.Models.TemplateCredentials;
using Transloadit.Tests.Configuration;
using Xunit;

namespace Transloadit.Tests
{
    public class TemplateCredentialsApiTests
    {
        [Fact]
        public async Task GetTemplatesCredentialsList()
        {
            var config = TestConfiguration.ReadFromAppSettings().Transloadit;

            var client = new TransloaditClient(config.AuthKey, config.AuthSecret);
            var templateCredentials = await client.TemplateCredentials.GetListAsync();

            Assert.Equal("TEMPLATE_CREDENTIALS_FOUND", templateCredentials.Ok);
        }

        [Theory]
        [InlineData("047e1008c1ec4ea3a719d57f3648eff8")]
        public async Task GetTemplate(string templateId)
        {
            var config = TestConfiguration.ReadFromAppSettings().Transloadit;

            var client = new TransloaditClient(config.AuthKey, config.AuthSecret);
            var template = await client.Templates.GetAsync(templateId);

            Assert.Equal("TEMPLATE_FOUND", template.Ok);
        }

        [Theory]
        [InlineData("047e1008c1ec4ea3a719d57f3648eff8")]
        public async Task CreateCredentials(string templateId)
        {
            var config = TestConfiguration.ReadFromAppSettings().Transloadit;

            var client = new TransloaditClient(config.AuthKey, config.AuthSecret);

            var s3Creds = new CreateS3CredentialsRequest
            {
                Name = "my-s3-test3",
                Content = new S3CredentialsContent
                {
                    Bucket = "test bucket",
                    BucketRegion = "us-east-1",
                    Key = "xxx-yyy-zzz",
                    Secret = "the secret"
                }
            };
            var response = await client.TemplateCredentials.CreateAsync(s3Creds);
        }

        [Fact]
        public async Task CreateFtpCredentials()
        {
            var config = TestConfiguration.ReadFromAppSettings().Transloadit;

            var client = new TransloaditClient(config.AuthKey, config.AuthSecret);

            var s3Creds = new CreateFtpCredentialsRequest
            {
                Name = "my-ftp-test",
                Content = new S3CredentialsContent
                {
                    Bucket = "test bucket",
                    BucketRegion = "us-east-1",
                    Key = "xxx-yyy-zzz",
                    Secret = "the secret"
                }
            };
            var response = await client.TemplateCredentials.CreateAsync(s3Creds);
        }

    }
}