using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Samples.Environments.Models;

namespace Samples.Environments.Controllers
{
    public class LabExercisesController : Controller
    {
        private readonly ILogger<LabExercisesController> _logger;
        private readonly IWebHostEnvironment _environment;

        public LabExercisesController(ILogger<LabExercisesController> logger, IWebHostEnvironment environment)
        {
            _logger = logger;
            _environment = environment;
        }

        public IActionResult AccessInController()
        {
            LabExercisesViewModel model = new LabExercisesViewModel();
            //hydrate model here
            if (_environment.IsDevelopment())
            {
                model.Message += "Warning, you are in DEVELOPMENT!";
            }
            else if (_environment.IsStaging())
            {
                model.Message = "Caution, you are in STAGING!";
            }
            else if (_environment.IsEnvironment("Staging_2"))
            {
                model.Message = "Caution, you are in STAGING #2!";
            }
            else if (_environment.IsProduction())
            {
                model.Message += "Welcome to PRODUCTION!";
            }
            else
            {
                model.Message = "Error! Unknown ";
            }
            return View(model);
        }
        public IActionResult TagHelper()
        {
            return View();
        }

    }
}
