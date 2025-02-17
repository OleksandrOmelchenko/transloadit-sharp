using System;
using System.Threading.Tasks;
using Transloadit.Constants;
using Transloadit.Models.Credentials;
using Xunit;

namespace Transloadit.Tests
{
    public class CredentialsApiTests : TestBase
    {
        [Fact]
        public async Task CreateGetUpdateListDeleteCredentials_Should_Succeed()
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
            
            var createCredentialResponse = await TransloaditClient.Credentials.CreateAsync(ftpCredential);
            Assert.Equal(ResponseCodes.TemplateCredentialsCreated, createCredentialResponse.Base.Ok);
            Assert.Equal(ftpCredential.Name, createCredentialResponse.Credential.Name);
            Assert.Equal(ftpCredential.Content.Host, createCredentialResponse.Credential.Content["host"]);
            Assert.Equal(ftpCredential.Content.Password, createCredentialResponse.Credential.Content["password"]);
            Assert.Equal(ftpCredential.Content.User, createCredentialResponse.Credential.Content["user"]);

            var getCredentialResponse = await TransloaditClient.Credentials.GetAsync(createCredentialResponse.Credential.Id);
            Assert.Equal(ResponseCodes.TemplateCredentialsRead, getCredentialResponse.Base.Ok);
            Assert.Equal(ftpCredential.Name, getCredentialResponse.Credential.Name);
            Assert.Equal(ftpCredential.Content.Host, getCredentialResponse.Credential.Content["host"]);
            Assert.Equal(ftpCredential.Content.Password, getCredentialResponse.Credential.Content["password"]);
            Assert.Equal(ftpCredential.Content.User, getCredentialResponse.Credential.Content["user"]);

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

            var updateResponse = await TransloaditClient.Credentials.UpdateAsync(getCredentialResponse.Credential.Id, newFtpCredential);
            Assert.Equal(ResponseCodes.TemplateCredentialsUpdated, updateResponse.Base.Ok);
            Assert.Equal(newFtpCredential.Name, updateResponse.Credential.Name);
            Assert.Equal(newFtpCredential.Content.Host, updateResponse.Credential.Content["host"]);
            Assert.Equal(newFtpCredential.Content.Password, updateResponse.Credential.Content["password"]);
            Assert.Equal(newFtpCredential.Content.User, updateResponse.Credential.Content["user"]);

            var listCredentialsResponse = await TransloaditClient.Credentials.GetListAsync();
            Assert.Equal(ResponseCodes.TemplateCredentialsFound, listCredentialsResponse.Base.Ok);
            Assert.True(listCredentialsResponse.Credentials.Count > 0);

            var deleteResponse = await TransloaditClient.Credentials.DeleteAsync(name);
            Assert.Equal(ResponseCodes.TemplateCredentialsDeleted, deleteResponse.Base.Ok);

            var notFoundResponse = await TransloaditClient.Credentials.GetAsync(name);
            Assert.Equal(ResponseCodes.TemplateCredentialsNotRead, notFoundResponse.Base.Error);
            Assert.Equal(400, notFoundResponse.Base.HttpCode);
        }
    }
}