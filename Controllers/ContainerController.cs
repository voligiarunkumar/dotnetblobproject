using Microsoft.AspNetCore.Mvc;
using Azuredotnetblobproject.Services;
using Azuredotnetblobproject.Models;
using System.Threading.Tasks;

namespace Azuredotnetblobproject.Controllers
{
    public class ContainerController : Controller
    {
        private readonly IContainerService containerService;
        
        public ContainerController(IContainerService containerService)
        {
            this.containerService = containerService;
        }
        public async Task<IActionResult> Index()
        {
            var allContainer = await containerService.GetAllContainer();
            return View(allContainer);
        }public async Task<IActionResult> Delete(string containerName)
        {
             await containerService.DeleteContainer(containerName);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Create()
        {

            return View(new Container());
        }
        [HttpPost]
        public async Task<IActionResult> Create(Container container)
        {
            await containerService.CreateContainer(container.Name);
            return RedirectToAction(nameof(Index));
        }
    } 
}
