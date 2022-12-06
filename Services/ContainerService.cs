﻿using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

namespace Azuredotnetblobproject.Services
{
    public class ContainerService : IContainerService
    {  
        private readonly BlobServiceClient blobServiceClient; 

        public ContainerService(BlobServiceClient blobServiceClient)
        {
            this.blobServiceClient = blobServiceClient;
        }
        public async Task CreateContainer(string containerName)
        {
            BlobContainerClient blobContainerClient = blobServiceClient.GetBlobContainerClient(containerName);
            await blobContainerClient.CreateIfNotExistsAsync(PublicAccessType.BlobContainer);
                }

        public async Task DeleteContainer(string containerName)
        {
            BlobContainerClient blobContainerClient = blobServiceClient.GetBlobContainerClient(containerName);
            await blobContainerClient.DeleteIfExistsAsync();
        }

        public async Task<List<string>> GetAllContainer()
        {
            List<string> ContainerName = new();
            await foreach (BlobContainerItem blobContainerItem in blobServiceClient.GetBlobContainersAsync())
            {
                ContainerName.Add(blobContainerItem.Name);
            }
            return ContainerName;
        }

        public async Task<List<string>> GetAllContainerAndBlobs()
        {
            throw new NotImplementedException();
        }
    }
}