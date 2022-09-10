using Azure.Storage.Blobs;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsMusic.Data
{
    public class AzureBlobStorage : IAzureBlobStorage
    {
        private IConfiguration _configuration;

        public AzureBlobStorage(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<string> UploadFile(string fileName, Stream buffer, string directory = "")
        {
            BlobServiceClient blobServiceClient = new BlobServiceClient(_configuration["BlobStorageConnection"]);
            BlobContainerClient container = null;

            if (string.IsNullOrWhiteSpace(directory) == false)
            {
                container = blobServiceClient.GetBlobContainerClient($"imagemcapa/{directory}");
                await container.UploadBlobAsync(fileName, buffer);
                return $"{_configuration["BasePathBlobStorageImagemCapa"]}/imagemcapa/{fileName}";
            }
            else
            {
                container = blobServiceClient.GetBlobContainerClient($"imagemcapa");
                await container.UploadBlobAsync(fileName, buffer);
                return $"{_configuration["BasePathBlobStorageImagemCapa"]}/imagemcapa/{fileName}";
            }
        }
    }
}
