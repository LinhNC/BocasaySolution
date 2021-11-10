using Application.Interfaces.Services;
using Application.Wrappers;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class FileService : IFileService
    {
        public async Task<Result<string>> WriteAsync(string filePath, object content)
        {
            try
            {
                string writenData = JsonConvert.SerializeObject(content);
                System.IO.File.WriteAllText(filePath, writenData);
                return await Task.FromResult(Result<string>.Success("File writen successfully"));
            }
            catch (Exception ex)
            {
                return await Task.FromResult(Result<string>.Fail("File writen faild with error: "+ ex.ToString()));
            }

        }
        public Task<string> ReadAsTextAsync(string path)
        {
            return Task.FromResult(string.Empty);
        }
    }
}
