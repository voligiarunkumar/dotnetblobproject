using Azuredotnetblobproject.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Azuredotnetblobproject.Services
{
    public interface IBlobService
    {
        Task<List<string>>GetAllBlobs(string containerName);
        Task<string> GetBlob(string name, string containerName);
        Task<bool> UploadBlob(string name,IFormFile file,string containerName,Blob blob);
        Task DeleteBlob(string name,string containerName);

    }
}
