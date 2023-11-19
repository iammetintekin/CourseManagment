using App.Domain.Models;
using App.Shared.ReturnObjects;
using WEB.Models.Common;

namespace WEB.Models.Home
{
    public class UserRegisteredCourseBeforeModel
    {
        public readonly Result Result;
        public readonly string UserId;
        public readonly Course Course;
        public readonly UserCourseMapping UserCourse;

        public UserRegisteredCourseBeforeModel()
        {
            
        }
        public UserRegisteredCourseBeforeModel(Result result, string userId="", Course course=null, UserCourseMapping userCourseMapping = null)
        {
            Result = result;
            UserId = userId;
            Course = course;
            UserCourse = userCourseMapping;
        }
        public SelectCourseItemDto CourseItem { get; set; }
        public bool IsInBasket { get; set; } = false;
    }
}
