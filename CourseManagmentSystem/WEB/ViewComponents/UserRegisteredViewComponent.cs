using App.Application.LoadServices;
using App.Shared.ReturnObjects;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WEB.Models.Home;
using WEB.Utilities.RedisOperations;

namespace WEB.ViewComponents
{
    [ViewComponent(Name = "UserRegisteredViewComponent")] 
    public class UserRegisteredViewComponent : ViewComponent
    {
        private readonly IServiceManager _serviceManager;
        private readonly IRedisService _redisService;
        public UserRegisteredViewComponent(IServiceManager serviceManager, IRedisService redisService)
        {
            _serviceManager = serviceManager; 
            _redisService = redisService;
        }
        public IViewComponentResult Invoke(int CourseID)
        {
            var loggedUser = _serviceManager.UserService.GetLoggedUser();
            var Model = new UserRegisteredCourseBeforeModel();
            if (loggedUser.Succeed)
            {
                var CourseInDB = _serviceManager.CourseService.GetById(CourseID); 
                var result = _serviceManager.UserCourseService.CheckUserRegistered(CourseID, loggedUser.Data.Id);

                if (CourseInDB.Succeed)
                {
                    if (result.Succeed)
                    {
                        Model = new UserRegisteredCourseBeforeModel(new Result(result.Message, result.Succeed), loggedUser.Data.Id, CourseInDB.Data, result.Data);
                    }
                    else
                    {
                        Model = new UserRegisteredCourseBeforeModel(new Result(CourseInDB.Message, CourseInDB.Succeed), loggedUser.Data.Id, CourseInDB.Data);
                        Model.IsInBasket = _redisService.AlreadyInBasket(loggedUser.Data.Id, CourseID);

                    }
                }
                else
                {
                    Model.IsInBasket = _redisService.AlreadyInBasket(loggedUser.Data.Id, CourseID);
                }
            }
            else
            {
                Model = new UserRegisteredCourseBeforeModel(new Result("", false), "", new App.Domain.Models.Course());
            }

            
            return View(Model); 
        }
    }
}
