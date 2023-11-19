using App.Application.LoadServices;
using App.Application.Services.Abstract;
using App.Domain.Models;
using App.Shared.ReturnObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WEB.Factories.Abstract;
using WEB.Models.Common;
using WEB.Utilities.RedisOperations;

namespace WEB.Controllers
{
    [Authorize(Roles ="user")]
    public class BasketController : Controller
    {
        private readonly IRedisService _redisService;
        private readonly IServiceManager _serviceManager;
        private readonly IBasketFactory _basketFactory;
        public BasketController(IRedisService redisService, IServiceManager userService, IBasketFactory basketFactory)
        {
            _redisService = redisService;
            _serviceManager = userService;
            _basketFactory = basketFactory;
        }
        public IActionResult Index()
        {
            var model = _basketFactory.Prepare();
            return View("Index",model);
        }
        public IActionResult GetItemCount()
        {
            var basket = _redisService.GetSelectedCoursesByUserId(_serviceManager.UserService.GetLoggedUser().Data.Id);
            if(basket.Succeed)
                if(basket.Data.SelectedCourses.Any()) 
                    return Content(basket.Data.SelectedCourses.Count.ToString());
            return Content("Boş");
        }
        [HttpPost]
        public IActionResult SaveOrUpdate(SelectCourseItemDto CourseItem)
        {
            var basket = _redisService.GetSelectedCoursesByUserId(_serviceManager.UserService.GetLoggedUser().Data.Id);

            if(basket.Succeed == false) 
            {
                var createdBasketObject = new SelectCourseDto { UserId = _serviceManager.UserService.GetLoggedUser().Data.Id };
                createdBasketObject.SelectedCourses = new List<SelectCourseItemDto>
                {
                    CourseItem
                };
                _redisService.SaveOrUpdate(createdBasketObject);
            }
            else
            {
                basket.Data.SelectedCourses.Add(CourseItem);
                _redisService.SaveOrUpdate(basket.Data);
            }
            return RedirectToAction("Details","Home",new {Id=CourseItem.CourseId});
        }
        public IActionResult Delete()
        {
            var deleteResult = _redisService.Delete(_serviceManager.UserService.GetLoggedUser().Data.Id); 
            var model = _basketFactory.Prepare(new Result(deleteResult.Message, deleteResult.Succeed));
            return View("Index", model);
        }
        [HttpPost]
        public IActionResult Save(SelectCourseDto Basket)
        { 
            var UserCourseMapping = new List<UserCourseMapping>();
            foreach (var item in Basket.SelectedCourses)
            {
                UserCourseMapping.Add(new UserCourseMapping
                {
                    CourseId = Convert.ToInt32(item.CourseId),
                    UserId = Basket.UserId,
                    CreatedDate = DateTime.UtcNow
                });
            }
            _serviceManager.UserCourseService.Create(UserCourseMapping);
            // kayıt olduktan sonra sepeti temizlenir
            _redisService.Delete(_serviceManager.UserService.GetLoggedUser().Data.Id); 
            var model = _basketFactory.Prepare(new Result("Kayıtlı kurslarınız listeleniyor.", true));
            return View("Index", model);
        }
    }
}
