using System;
using System.Threading.Tasks;
using Transloadit.Models.TemplateCredentials;
using Transloadit.Tests.Configuration;
using Xunit;

namespace Transloadit.Tests
{
    public class TemplateCredentialsApiTests
    {
        private TransloaditConfig Transloadit { get; set; }

        public TemplateCredentialsApiTests()
        {
            Transloadit = TestConfiguration.ReadFromAppSettings().Transloadit;
        }

        [Fact]
        public async Task GetTemplatesCredentialsList()
        {
            var client = new TransloaditClient(Transloadit.AuthKey, Transloadit.AuthSecret);
            var templateCredentials = await client.TemplateCredentials.GetListAsync();
            

            Assert.Equal("TEMPLATE_CREDENTIALS_FOUND", templateCredentials.Base.Ok);
        }

        [Theory]
        [InlineData("sftp-some")]
        public async Task GetTemplateCredential(string credentialIdOrName)
        {
            var client = new TransloaditClient(Transloadit.AuthKey, Transloadit.AuthSecret);
            var template = await client.TemplateCredentials.GetAsync(credentialIdOrName);

            Assert.Equal("TEMPLATE_FOUND", template.Base.Ok);
        }

        [Theory]
        [InlineData("047e1008c1ec4ea3a719d57f3648eff8")]
        public async Task CreateCredentials(string templateId)
        {
            var client = new TransloaditClient(Transloadit.AuthKey, Transloadit.AuthSecret);

            var s3Creds = new S3CredentialsRequest
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
            var client = new TransloaditClient(Transloadit.AuthKey, Transloadit.AuthSecret);

            var s3Creds = new FtpCredentialsRequest
            {
                Name = "my-ftp-test",
                Content = new FtpCredentialsContent
                {
                    Host = "asodfj",
                    Password = "asdflkj",
                    User = "asdf"
                }
            };
            var response = await client.TemplateCredentials.CreateAsync(s3Creds);
        }

        [Fact]
        public async Task CreateCreateGetUpdateDeleteCredential()
        {
            var client = new TransloaditClient(Transloadit.AuthKey, Transloadit.AuthSecret);

            var name = $"{Guid.NewGuid()}-{DateTime.Now:yyyyMMddHHmmss}";

            var ftpCredential = new FtpCredentialsRequest
            {
                Name = name,
                Content = new FtpCredentialsContent
                {
                    Host = "ftp.test.home",
                    Password = "ThePassword123",
                    User = "admin"
                }
            };

            var credentialResponse = await client.TemplateCredentials.CreateAsync(ftpCredential);

            var getCreds = await client.TemplateCredentials.GetAsync(credentialResponse.Credential.Id);

            var newFtpCredential = new FtpCredentialsRequest
            {
                Name = name,
                Content = new FtpCredentialsContent
                {
                    Host = "ftp.new.home",
                    Password = "NewPassword123",
                    User = "admin-new"
                }
            };

            var a = await client.TemplateCredentials.UpdateAsync(getCreds.Credential.Id, newFtpCredential);


            var deleteResponse = await client.TemplateCredentials.DeleteAsync(name);

            var getNotFound = await client.TemplateCredentials.GetAsync(name);
        }

    }
}