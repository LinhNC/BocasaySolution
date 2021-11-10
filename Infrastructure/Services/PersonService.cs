using Application.Configurations;
using Application.Interfaces.Services;
using Application.Requests;
using Application.Wrappers;
using Domain.Entities;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class PersonService : IPersonService
    {
        private readonly AppConfiguration _appConfig;
        private readonly IFileService _fileService;
        public PersonService(IOptions<AppConfiguration> appConfig, IFileService fileService)
        {
            _appConfig = appConfig.Value;
            _fileService = fileService;
        }
        public async Task<Result<string>> AddAsync(PersonRequest personRequest)
        {
            var person = new Person()
            {
                FirstName = personRequest.FirstName,
                LastName = personRequest.LastName
            };
            var filePath = _appConfig.FolderJsonPath + @"\" + person.Id + ".json";
            var result = await _fileService.WriteAsync(filePath, person);
            if (result.Succeeded)
            {
                return await Task.FromResult(Result<string>.Success(person.Id, "Add person successfully"));
            }
            else
            {
                return await Task.FromResult(Result<string>.Fail(result.Messages));
            }
        }
    }
}
