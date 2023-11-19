using WEB.Models.Home;

namespace WEB.Factories.Abstract
{
    public interface IHomeFactory
    {
        HomeIndexViewModel Prepare(int? categoryId);
        CourseViewModel PrepareCourseEditModel(int courseId);
        CourseListViewModel PrepareCourseListModel();
    }
}
