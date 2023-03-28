using System;
using System.IO;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace Emailing
{
    [StorageAccount("BlobConnectionString")]
    public class EmailingFunction
    {
        [FunctionName("EmailingFunction")]
        public void Run([BlobTrigger("blob-reenbit-storage/{name}")]Stream myBlob, string name, ILogger log)
        {            
            log.LogInformation($"C# Blob trigger function Processed blob\n Name:{name} \n Size: {myBlob.Length} Bytes");
        }
    }
}
