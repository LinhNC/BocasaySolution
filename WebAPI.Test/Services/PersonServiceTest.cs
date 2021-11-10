using Application.Configurations;
using Application.Interfaces.Services;
using Application.Requests;
using Application.Wrappers;
using Infrastructure.Services;
using Microsoft.Extensions.Options;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace WebAPI.Test.Services
{
    public class PersonServiceTest
    {
        private readonly Mock<IFileService> mockFileService;
        private readonly Mock<IOptions<AppConfiguration>> mockOptionAppConfig;

        public PersonServiceTest()
        {
            var appConfig = new AppConfiguration() { FolderJsonPath = "Files\\Persons" };
            mockOptionAppConfig = new Mock<IOptions<AppConfiguration>>();
            mockOptionAppConfig.Setup(m => m.Value).Returns(appConfig);

            mockFileService = new Mock<IFileService>();
        }

        [Fact]
        public async Task Add_Person_Success()
        {
            // Set up           
            var personRequest = new PersonRequest("Test", "OK");
           
            mockFileService.Setup(m => m.WriteAsync(It.IsAny<string>(), It.IsAny<object>())).ReturnsAsync(() => Result<string>.Success(It.IsAny<string>()));

            var personService = new PersonService(mockOptionAppConfig.Object, mockFileService.Object);
            //Action
            var result = await personService.AddAsync(personRequest);
            // Verify
            Assert.True(result.Succeeded);
        }
        [Fact]
        public async Task Add_Person_Fail()
        {
            // Set up           
            var personRequest = new PersonRequest("Test", "NOT OK");

            mockFileService.Setup(m => m.WriteAsync(It.IsAny<string>(), It.IsAny<object>())).ReturnsAsync(() => Result<string>.Fail(It.IsAny<string>()));

            var personService = new PersonService(mockOptionAppConfig.Object, mockFileService.Object);
            //Action
            var result = await personService.AddAsync(personRequest);
            // Verify
            Assert.False(result.Succeeded);
        }
    }
}
