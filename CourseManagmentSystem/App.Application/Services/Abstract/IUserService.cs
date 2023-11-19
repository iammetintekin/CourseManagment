using App.Shared.ReturnObjects;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Services.Abstract
{
    public interface IUserService
    {
        Result Login(string username, string password);
        DataResult<IdentityUser> GetUserByID(string Is);
        DataResult<IdentityUser> GetLoggedUser();
        DataResult<IdentityUser> GetUserByPrincipal(ClaimsPrincipal claimsPrincipal);
        Task Logout();
    }
}
