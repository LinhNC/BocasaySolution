using Application.Features.Persons.Commands;
using Application.Wrappers;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using WebApp.Infrastructure.Extensions;

namespace WebApp.Infrastructure.Features.Persons
{
    public class PersonHandler : IPersonHandler
    {
        private readonly HttpClient _httpClient;
        public PersonHandler(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IResult<string>> AddAsync(AddPersonCommand person)
        {
            if (string.IsNullOrEmpty(person.FirstName) || string.IsNullOrEmpty(person.LastName))
            {
                return await Task.FromResult(Result<string>.Fail("First Name or Last Name are required"));
            }
            var response = await _httpClient.PostAsJsonAsync(EndPointConfig.PersonEndPointPost, person);
            return await response.ToResult<string>();
        }
    }
}
