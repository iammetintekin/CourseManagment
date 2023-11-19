using App.Domain.Models;
using App.Shared.ReturnObjects;

namespace WEB.Models.Home
{
    public class CourseViewModel
    {
        public Course Course;
        public Result Result;

        public CourseViewModel(Course course, Result result= null)
        {
            Course = course;
            Result = result;
        }
    }
}
