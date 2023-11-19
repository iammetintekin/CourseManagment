using Microsoft.AspNetCore.Mvc;

namespace CourseAPI.Controllers
{
    [ApiController]
    public class BaseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
