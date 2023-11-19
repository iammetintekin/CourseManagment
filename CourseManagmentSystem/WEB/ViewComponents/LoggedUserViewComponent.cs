using App.Application.LoadServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Security.Principal;
using WEB.Models;

namespace WEB.ViewComponents
{
    [ViewComponent(Name = "LoggedUserViewComponent")]
    public class LoggedUserViewComponent : ViewComponent
    {
        private readonly IServiceManager _serviceManager; 
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LoggedUserViewComponent(IServiceManager serviceManager, IHttpContextAccessor httpContextAccessor)
        {
            _serviceManager = serviceManager;
            _httpContextAccessor = httpContextAccessor;
        }
        public IViewComponentResult Invoke()
        { 
            var loggeduser = _serviceManager.UserService.GetLoggedUser();
            if (!loggeduser.Succeed)
                return View(new IdentityUser()); 
            return View(loggeduser.Data);
        }
    }
}
