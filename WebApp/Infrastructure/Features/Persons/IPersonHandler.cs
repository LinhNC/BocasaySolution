using Application.Features.Persons.Commands;
using Application.Wrappers;
using System.Threading.Tasks;

namespace WebApp.Infrastructure.Features.Persons
{
    public interface IPersonHandler
    {
        Task<IResult<string>> AddAsync(AddPersonCommand person);
    }
}
