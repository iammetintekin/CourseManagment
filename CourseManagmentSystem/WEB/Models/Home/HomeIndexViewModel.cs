using App.Domain.Dtos;
using App.Domain.Models;
using App.Shared.ReturnObjects;
using X.PagedList;

namespace WEB.Models.Home
{
    public class HomeIndexViewModel
    {
        public readonly List<Course> Courses;
        public Result Result; 
        public HomeIndexViewModel(List<Course> courses, Result result = null)
        {
            Courses = courses;
            Result = result;
        }
    }
}
