using Application.Interfaces.Services;
using Application.Requests;
using Application.Wrappers;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Persons.Commands
{
    /// <summary>
    /// Add Person CQRS
    /// </summary>
    public class AddPersonCommand : IRequest<Result<string>>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class AddPersonCommandHandler : IRequestHandler<AddPersonCommand, Result<string>>
    {
        private readonly IPersonService _personService;
        public AddPersonCommandHandler(IPersonService personService)
        {
            _personService = personService;
        }
        public async Task<Result<string>> Handle(AddPersonCommand request, CancellationToken cancellationToken)
        {
            var person = new PersonRequest(request.FirstName, request.LastName);
            return await _personService.AddAsync(person);
        }
    }
}
