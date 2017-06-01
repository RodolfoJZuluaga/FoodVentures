using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace FoodVentures.Services
{
    public class BlobStorageMultipartStreamProvider : MultipartStreamProvider
    {
        public override Stream GetStream(HttpContent parent, HttpContentHeaders headers)
        {
            Stream stream = null;
            ContentDispositionHeaderValue contentDisposition = headers.ContentDisposition;
            if (contentDisposition != null)
            {
                if (!String.IsNullOrWhiteSpace(contentDisposition.FileName))
                {
                    //string connectionString = ConfigurationManager.AppSettings["my-connection-string"];
                    //string containerName = ConfigurationManager.AppSettings["my-container"];
                    CloudStorageAccount storageAccount = ConnectionString.GetConnectionString();
                    CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
                    CloudBlobContainer blobContainer = blobClient.GetContainerReference("images");

                    CloudBlockBlob blob = blobContainer.GetBlockBlobReference(contentDisposition.FileName);
                    stream = blob.OpenWrite();
                }
            }
            return stream;
        }
    }
}