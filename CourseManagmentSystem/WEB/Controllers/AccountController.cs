using Microsoft.AspNetCore.Mvc;

namespace WEB.Controllers
{
    public class AccountController : BaseController
    {
        public IActionResult Signup()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Account()
        {
            return View();
        }
    }
}
