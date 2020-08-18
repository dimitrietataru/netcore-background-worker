using Microsoft.AspNetCore.Mvc;

namespace NetCore.BackgroundWorkerPrototype.WebApplication.Controllers
{
    [ApiController]
    [Produces("application/json")]
    public sealed class WorkerController : ControllerBase
    {
        [HttpGet]
        [Route("api/worker")]
        public IActionResult Index()
        {
            return Ok("Background Worker + API");
        }
    }
}
