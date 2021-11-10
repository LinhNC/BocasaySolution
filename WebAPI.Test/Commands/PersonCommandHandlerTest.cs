using Application.Features.Persons.Commands;
using Application.Interfaces.Services;
using Application.Requests;
using Application.Wrappers;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace WebAPI.Test.Commands
{
    public class PersonCommandHandlerTest
    {
        private Mock<IPersonService> mockPersonService;

        public PersonCommandHandlerTest()
        {
            mockPersonService = new Mock<IPersonService>();
           
        }
        [Fact]
        public async Task Add_Person_Handler_Success()
        {
            // Set up           
            var personRequest = new PersonRequest("Test", "OK");

            mockPersonService.Setup(m => m.AddAsync(personRequest)).ReturnsAsync(() => Result<string>.Success(It.IsAny<string>()));

            // Actions
            var addPersonCommandHandler = new AddPersonCommandHandler(mockPersonService.Object);

            // Verify
            var result = await addPersonCommandHandler.Handle(new AddPersonCommand() { FirstName = personRequest.FirstName, LastName = personRequest.LastName }, CancellationToken.None);
            Assert.True(result.Succeeded);
        }

        [Fact]
        public async Task Add_Person_Handler_Fail()
        {
            // Set up           
            var personRequest = new PersonRequest("Test", "NOT OK");

            mockPersonService.Setup(m => m.AddAsync(personRequest)).ReturnsAsync(() => Result<string>.Fail(It.IsAny<string>()));

            // Actions
            var addPersonCommandHandler = new AddPersonCommandHandler(mockPersonService.Object);

            // Verify
            var result = await addPersonCommandHandler.Handle(new AddPersonCommand() { FirstName = personRequest.FirstName, LastName = personRequest.LastName }, CancellationToken.None);
            Assert.False(result.Succeeded);
        }
    }
}
