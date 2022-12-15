using Azuredotnetblobproject.Services;
using Microsoft.AspNetCore.Mvc;

namespace Azuredotnetblobproject.Controllers
{
    public class BlobController : Controller
    {
        private readonly IBlobService blobService;

        public BlobController(IBlobService blobService)
        {
            this.blobService = blobService;
        }
        [HttpGet]
        public async Task<IActionResult> Manage(string containerName)
        {
            var blobsobj = await blobService.GetAllBlobs(containerName); 
            return View(blobsobj);
        }
        [HttpGet]
        public async Task<IActionResult> AddFile(string containerName)
        {
             
            return View();
        }
        [HttpPost]
        public  async Task <IActionResult> AddFile(string containerName,IFormFile file)
        {
            //here we are using Guid for overiding the file *if some has it already
            if(file==null||file.Length<1)return View();
            var fileName=Path.GetFileNameWithoutExtension(file.FileName)+"_"+Guid.NewGuid()+Path.GetExtension(file.FileName);
            var result = await blobService.UploadBlob(fileName, file, containerName);
            if(result)
                return RedirectToAction("Index","Container");
             
            return View();
        }
        public async Task<IActionResult> ViewFile(string name,string containerName)
        {

            return Redirect(await blobService.GetBlob(name, containerName));
        }

        public async Task<IActionResult> DeleteFile(string name,string containerName)
        {
            await blobService.DeleteBlob(name, containerName); 
            return RedirectToAction("Index", "Home");
        }
    }
}
