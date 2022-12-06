using Microsoft.AspNetCore.Mvc;
using Azuredotnetblobproject.Services;

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
        }
    } 
}
