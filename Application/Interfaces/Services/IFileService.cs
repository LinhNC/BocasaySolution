using Application.Interfaces.Services.Common;
using Application.Wrappers;
using System.Threading.Tasks;

namespace Application.Interfaces.Services
{
    /// <summary>
    /// File service interface
    /// </summary>
    public interface IFileService : IService
    {
        /// <summary>
        /// Write file as json text
        /// </summary>
        /// <param name="filePath">Path of file</param>
        /// <param name="content">File content</param>
        /// <returns></returns>
        Task<Result<string>> WriteAsync(string filePath, object content);
        Task<string> ReadAsTextAsync(string filePath);
    }
}
