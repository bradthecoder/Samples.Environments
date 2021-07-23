using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Samples.Environments.Models;

namespace Samples.Environments.Controllers
{
    public class LabExercisesController : Controller
    {
        private readonly ILogger<LabExercisesController> _logger;

        public LabExercisesController(ILogger<LabExercisesController> logger)
        {
            _logger = logger;
        }
        public IActionResult AccessInController()
        {
            LabExercisesViewModel model = new LabExercisesViewModel();
            //hydrate model here

            return View(model);
        }
        public IActionResult TagHelper()
        {
            return View();
        }

    }
}
