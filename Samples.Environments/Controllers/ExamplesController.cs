using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Samples.Environments.Models;

namespace Samples.Environments.Controllers
{
    public class ExamplesController : Controller
    {
        private readonly ILogger<ExamplesController> _logger;
        private readonly IWebHostEnvironment _environment;

        public ExamplesController(
            ILogger<ExamplesController> logger,
            IWebHostEnvironment environment
            )
        {
            _logger = logger;
            _environment = environment;
        }

        public IActionResult AccessInController()
        {
            ExamplesViewModel model = new ExamplesViewModel() { Message = "Welcome to the " };

            if(_environment.IsDevelopment())
            {
                model.Message += "Development";
            }
            else if(_environment.IsStaging() || _environment.IsEnvironment("Staging_2"))
            {
                model.Message += "Staging";
            }
            else if(_environment.IsProduction())
            {
                model.Message += "Prodution";
            }
            else
            {
                model.Message = "Warning! Unknown ";
            }

            model.Message += " environment";
            return View(model);
        }
        public IActionResult TagHelper()
        {
            return View();
        }
    }
}
