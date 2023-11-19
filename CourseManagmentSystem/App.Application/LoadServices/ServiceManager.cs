using App.Application.Services;
using App.Application.Services.Abstract;
using App.Infrastructure.RepositoryPattern.UnitOfWork;
using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.LoadServices
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<ICourseService> _courseService; 
        private readonly Lazy<ICategoryService> _categoryService; 
        private readonly Lazy<IUserService> _userService; 
        private readonly Lazy<IUserCourseService> _userCourseService; 
        public ServiceManager(IUnitOfWork db, IMapper mapper, SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _courseService = new Lazy<ICourseService>(() => new CourseService(db, mapper));
            _categoryService = new Lazy<ICategoryService>(() => new  CategoryService(db, mapper));
            _userService = new Lazy<IUserService>(() => new UserService(signInManager, userManager, httpContextAccessor));
            _userCourseService = new Lazy<IUserCourseService>(() => new UserCourseService(db));
        }

        public ICourseService CourseService => _courseService.Value;
        public ICategoryService CategoryService => _categoryService.Value;
        public IUserService UserService => _userService.Value;
        public IUserCourseService UserCourseService => _userCourseService.Value;
    }
}
