﻿namespace Azuredotnetblobproject.Services
{
    public interface IContainerService
    {
        Task<List<string>> GetAllContainerAndBlobs();
        Task<List<string>> GetAllContainer();
        Task CreateContainer(string containerName);
        Task DeleteContainer(string containerName);
    }
}
