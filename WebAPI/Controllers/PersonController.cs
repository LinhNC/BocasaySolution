using Application.Features.Persons.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private IMediator _mediator;
        public PersonController(IMediator mediator)
        {
            _mediator = mediator;
        }
        /// <summary>
        /// Add Person
        /// </summary>
        /// <param name="command"></param>
        /// <returns>Status 200 OK</returns>
        [HttpPost]
        public async Task<IActionResult> Post(AddPersonCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}
