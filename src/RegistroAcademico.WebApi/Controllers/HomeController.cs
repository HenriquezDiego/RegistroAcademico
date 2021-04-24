using Microsoft.AspNetCore.Mvc;

namespace RegistroAcademico.WebApi.Controllers
{
    [ApiController]
    [Route("/")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        [ApiExplorerSettings(IgnoreApi=true)]
        public IActionResult GetIndex()
        {
            return Redirect("swagger");
        }
    }
}