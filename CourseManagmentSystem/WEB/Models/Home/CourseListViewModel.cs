using App.Domain.Models;

namespace WEB.Models.Home
{
    public class CourseListViewModel
    {
        public readonly List<UserCourseMapping> UserCourses;

        public CourseListViewModel(List<UserCourseMapping> userCourses)
        {
            UserCourses = userCourses;
        }
    }
}
