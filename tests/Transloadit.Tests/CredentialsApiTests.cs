using System;
using System.Threading.Tasks;
using Transloadit.Models.Credentials;
using Xunit;

namespace Transloadit.Tests
{
    public class CredentialsApiTests : TestBase
    {
        [Fact]
        public async Task GetTemplatesCredentialsList()
        {
            var templateCredentials = await TransloaditClient.Credentials.GetListAsync();

            Assert.Equal("TEMPLATE_CREDENTIALS_FOUND", templateCredentials.Base.Ok);
        }

        [Theory]
        [InlineData("sftp-some")]
        public async Task GetTemplateCredential(string credentialIdOrName)
        {
            var template = await TransloaditClient.Credentials.GetAsync(credentialIdOrName);

            Assert.Equal("TEMPLATE_FOUND", template.Base.Ok);
        }

        [Fact]
        public async Task CreateCredentials()
        {
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
            var response = await TransloaditClient.Credentials.CreateAsync(s3Creds);
        }

        [Fact]
        public async Task CreateFtpCredentials()
        {
            var ftpCredentials = new FtpCredentialsRequest
            {
                Name = "my-ftp-test",
                Content = new FtpCredentialsContent
                {
                    Host = "asodfj",
                    Password = "asdflkj",
                    User = "asdf"
                }
            };
            var response = await TransloaditClient.Credentials.CreateAsync(ftpCredentials);
        }

        [Fact]
        public async Task CreateCreateGetUpdateDeleteCredential()
        {
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

            var credentialResponse = await TransloaditClient.Credentials.CreateAsync(ftpCredential);

            var getCreds = await TransloaditClient.Credentials.GetAsync(credentialResponse.Credential.Id);

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

            var a = await TransloaditClient.Credentials.UpdateAsync(getCreds.Credential.Id, newFtpCredential);


            var deleteResponse = await TransloaditClient.Credentials.DeleteAsync(name);

            var getNotFound = await TransloaditClient.Credentials.GetAsync(name);
        }

    }
}