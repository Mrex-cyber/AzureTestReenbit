using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Azure.Storage.Blobs;
using System.IO;
using System.IO.Pipes;

namespace ReenbitTest.Pages
{
    public class IndexModel : PageModel
    {
        public string blobStorageConnectionString = "DefaultEndpointsProtocol=https;AccountName=emailnotificationr188986;AccountKey=3lAJgWjctRD8SIDUTIh9ew28jRaPZAX5UV0BEiFUik2uy7rcQQpWLWR83hCPkRSCvxybQ2JU7MVl+AStR+DHUQ==;EndpointSuffix=core.windows.net";
        public string blobStorageContainerName = "blob-reenbit-storage";
        
        public async void OnPost(IFormFile uploadedFile, string email)
        {
            BlobContainerClient container = new BlobContainerClient(blobStorageConnectionString, blobStorageContainerName);
            string fileExt = System.IO.Path.GetExtension(uploadedFile.FileName);

            if (uploadedFile != null && (fileExt == ".docx" || fileExt == ".doc"))
            {
                var blob = container.GetBlobClient(uploadedFile.FileName);
                await blob.UploadAsync(uploadedFile.OpenReadStream());          
            }
        }        
    }

}