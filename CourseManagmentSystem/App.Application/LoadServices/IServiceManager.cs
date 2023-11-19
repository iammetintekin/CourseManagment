using App.Application.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.LoadServices
{
    public interface IServiceManager
    {
        public ICourseService CourseService { get; }
        public ICategoryService CategoryService { get; }
        public IUserService UserService { get; }
        public IUserCourseService UserCourseService { get; }
    }
}
