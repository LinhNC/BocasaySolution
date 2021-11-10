using Application.Features.Persons.Commands;
using Application.Interfaces.Services;
using Application.Requests;
using Application.Wrappers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebAPI.Controllers;
using Xunit;

namespace WebAPI.Test.Controllers
{
    public class PersonControllerTest
    {
        private Mock<IMediator> mockMediator;
        private Mock<IPersonService> mockPersonService;

        [Fact]
        public async Task PersonController_Should_Return_OK()
        {
            // Setup
            var personRequest = new PersonRequest("Test", "OK");

            mockPersonService = new Mock<IPersonService>();
            mockPersonService.Setup(m => m.AddAsync(personRequest)).ReturnsAsync(() => Result<string>.Success(It.IsAny<string>()));

            var addPersonCommandHandler = new AddPersonCommandHandler(mockPersonService.Object);

            var addPersonCommand = new AddPersonCommand() { FirstName = personRequest.FirstName, LastName = personRequest.LastName };

            mockMediator = new Mock<IMediator>();
            mockMediator.Setup(m => m.Send(addPersonCommand, default(CancellationToken))).Returns(addPersonCommandHandler.Handle(addPersonCommand, CancellationToken.None));

            var personController = new PersonController(mockMediator.Object);

            // Actions
            var result = await personController.Post(addPersonCommand);

            //Verify
            var okResult = result as OkObjectResult;
            var resultObject = okResult.Value as IResult;
            Assert.True(resultObject.Succeeded);
        }

        [Fact]
        public async Task PersonController_Should_Return_Not_OK()
        {
            // Setup
            var personRequest = new PersonRequest("", "");

            mockPersonService = new Mock<IPersonService>();
            mockPersonService.Setup(m => m.AddAsync(personRequest)).ReturnsAsync(() => Result<string>.Fail(It.IsAny<string>()));

            var addPersonCommandHandler = new AddPersonCommandHandler(mockPersonService.Object);

            var addPersonCommand = new AddPersonCommand() { FirstName = personRequest.FirstName, LastName = personRequest.LastName };

            mockMediator = new Mock<IMediator>();
            mockMediator.Setup(m => m.Send(addPersonCommand, default(CancellationToken))).Returns(addPersonCommandHandler.Handle(addPersonCommand,CancellationToken.None));

            var personController = new PersonController(mockMediator.Object);

            // Actions
            var result = await personController.Post(addPersonCommand);

            //Verify
            var okResult = result as OkObjectResult;
            var resultObject = okResult.Value as IResult;
            Assert.False(resultObject.Succeeded);
        }
    }
}
