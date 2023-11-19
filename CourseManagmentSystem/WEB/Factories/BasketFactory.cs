using App.Application.LoadServices;
using App.Application.Services.Abstract;
using App.Shared.ReturnObjects;
using WEB.Factories.Abstract;
using WEB.Models.Basket;
using WEB.Models.Common;
using WEB.Utilities.RedisOperations;

namespace WEB.Factories
{
    public class BasketFactory : IBasketFactory
    {
        private readonly IRedisService _redis;
        private readonly IServiceManager _serviceManager;

        public BasketFactory(IRedisService redis, IServiceManager serviceManager)
        {
            _redis = redis;
            _serviceManager = serviceManager;
        }

        public BasketViewModel Prepare(Result result=null)
        {
            var loggedUser = _serviceManager.UserService.GetLoggedUser();
            var basket = _redis.GetSelectedCoursesByUserId(loggedUser.Data.Id);
            if (basket.Succeed)
                if (basket.Data.SelectedCourses.Any())
                    return new BasketViewModel(null, basket.Data);

            return new BasketViewModel(result); 
        }
    }
}
