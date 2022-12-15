using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

namespace Azuredotnetblobproject.Services
{
    public class BlobService : IBlobService
    {
        private readonly BlobServiceClient blobServiceClient;

        public BlobService(BlobServiceClient blobServiceClient)
        {
            this.blobServiceClient = blobServiceClient;
        }
        public Task DeleteBlob(string name, string containerName)
        {
            throw new NotImplementedException();
        }

        public async Task<List<string>> GetAllBlobs(string containerName)
        {
            BlobContainerClient blobContainerClient = blobServiceClient.GetBlobContainerClient(containerName);
            var blobs = blobContainerClient.GetBlobsAsync();
            var blobstring=new List<string>();
            await foreach(var item in blobs)
            {
                blobstring.Add(item.Name);
            }
            return blobstring;
        }

        public async Task<string> GetBlob(string name, string containerName)
        {
            BlobContainerClient blobContainerClient = blobServiceClient.GetBlobContainerClient(containerName);
            var blobClient = blobContainerClient.GetBlobClient(name);
            return blobClient.Uri.AbsoluteUri;
           

        }

        public async Task<bool> UploadBlob(string name, IFormFile file, string containerName)
        {
            BlobContainerClient blobContainerClient = blobServiceClient.GetBlobContainerClient(containerName);
            var blobClient = blobContainerClient.GetBlobClient(name);
            var httpheaders = new BlobHttpHeaders()
            {
               ContentType =file.ContentType

            };
            var result = await blobClient.UploadAsync(file.OpenReadStream(), httpheaders);
            if(result!=null)
            {
                return true;
            }
            return false;
            
        }
    }
}
