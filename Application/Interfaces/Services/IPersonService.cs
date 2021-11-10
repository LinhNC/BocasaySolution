using Application.Interfaces.Services.Common;
using Application.Requests;
using Application.Wrappers;
using System.Threading.Tasks;

namespace Application.Interfaces.Services
{
    public interface IPersonService : IService
    {
        /// <summary>
        /// Add Person
        /// </summary>
        /// <param name="personRequest">Person Model request</param>
        /// <returns></returns>
        Task<Result<string>> AddAsync(PersonRequest personRequest);
    }
}
