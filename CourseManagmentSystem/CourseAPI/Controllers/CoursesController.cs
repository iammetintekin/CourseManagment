using Microsoft.AspNetCore.Mvc;

namespace CourseAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    public class CoursesController : BaseController
    {
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Update()
        {
            return View();
        }
        public IActionResult List()
        {
            return View();
        }
        public IActionResult Single(int ID)
        {
            return View();
        }
    }
}
