using App.Application.LoadServices;
using App.Domain.Models;
using App.Shared;
using WEB.Factories.Abstract;
using WEB.Models.Home;

namespace WEB.Factories
{
    public class HomeFactory : IHomeFactory
    {
        private readonly IServiceManager _services;
        public HomeFactory(IServiceManager serviceManager)
        {
            _services = serviceManager;            
        }
        public HomeIndexViewModel Prepare(int? categoryId)
        {
            if(categoryId < 1)
                categoryId = null;

            var result = _services.CourseService.List(categoryId);
            if(!result.Succeed)
                return new HomeIndexViewModel(result.Data,new App.Shared.ReturnObjects.Result(result.Message, result.Succeed));
            return new HomeIndexViewModel(result.Data);
        }

        public CourseViewModel PrepareCourseEditModel(int courseId)
        {
            var result = _services.CourseService.GetById(courseId);
            if (!result.Succeed)
                return new CourseViewModel(result.Data, new App.Shared.ReturnObjects.Result(result.Message, result.Succeed));
            return new CourseViewModel(result.Data);
        }

        public CourseListViewModel PrepareCourseListModel()
        {
            var data = _services.UserCourseService.GetAllByUserId(_services.UserService.GetLoggedUser().Data.Id);
            return new CourseListViewModel(data.Data);
        }
    }
}
