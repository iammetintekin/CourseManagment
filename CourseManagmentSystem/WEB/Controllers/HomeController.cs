using App.Application.LoadServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using WEB.Factories.Abstract;
using WEB.Models;
using WEB.Models.Home;

namespace WEB.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IHomeFactory _homeFactory; 
        private readonly IServiceManager _serviceManager;
        public HomeController(IHomeFactory homeFactory, IServiceManager serviceManager)
        {
            _homeFactory = homeFactory;
            _serviceManager = serviceManager;
        }
        //Login
        public IActionResult Index(int? Id)
        {
            var model = _homeFactory.Prepare(Id);
            return View("Index", model);
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string Username, string Password)
        {
            var loginResult = _serviceManager.UserService.Login(Username, Password);
            if (loginResult.Succeed)
            {
                ClaimsPrincipal currentUser = User;
                var user = _serviceManager.UserService.GetUserByPrincipal(User);
                if(user.Succeed)
                {
                    return RedirectToAction("Index");
                }
            } 
            return View("Login", new LoginViewModel(Username, Password,loginResult));
        } 
        public IActionResult Logout()
        {
            _serviceManager.UserService.Logout();
            return RedirectToAction("Index");
        }
        [Authorize(Roles ="user")]
        public IActionResult Courses()
        {
            var data = _homeFactory.PrepareCourseListModel();
            return View("Courses", data);
        }
        public IActionResult Details(int Id)
        {
            var model = _homeFactory.PrepareCourseEditModel(Id);
            return View("Details", model);
        }
    }
}