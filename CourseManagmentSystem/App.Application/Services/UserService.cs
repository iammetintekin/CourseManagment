using App.Application.Services.Abstract;
using App.Shared.ReturnObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Services
{
    public class UserService : IUserService
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManagaer;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManagaer, IHttpContextAccessor httpContextAccessor)
        {
            _signInManager = signInManager;
            _userManagaer = userManagaer;
            _httpContextAccessor = httpContextAccessor;
        }

        public DataResult<IdentityUser> GetLoggedUser()
        {
            var loggeduser = _httpContextAccessor.HttpContext.User;
            var userId = loggeduser.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = _userManagaer.FindByIdAsync(userId).Result;
            if (result == null)
                return new DataResult<IdentityUser>("Bulunamadı", false, null);
            return new DataResult<IdentityUser>("", true, result);
        }

        public DataResult<IdentityUser> GetUserByID(string Id)
        {
            var result = _userManagaer.FindByIdAsync(Id).Result;
            if (result == null)
                return new DataResult<IdentityUser>("Bulunamadı", false, null);
            return new DataResult<IdentityUser>("", true, result);
        }

        public DataResult<IdentityUser> GetUserByPrincipal(ClaimsPrincipal claimsPrincipal)
        {
            var data = _userManagaer.GetUserAsync(claimsPrincipal).Result;
            if(data == null)
                return new DataResult<IdentityUser>("Bulunamadı", false, null);
            return new DataResult<IdentityUser>("", true, data);
        }

        public Result Login(string username, string password)
        {
            var user = _userManagaer.FindByNameAsync(username).Result;

            if(user is null)
                return new Result("Hatalı kullanıcı adı/şifre", false); 

            var result = _signInManager.PasswordSignInAsync(user, password,true,false).Result;

            if(result.Succeeded)
                return new Result("Giriş Başarılı", true);

            return new Result("Hatalı kullanıcı adı/şifre", false);
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
