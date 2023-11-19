using App.Shared.ReturnObjects;
using System.Text.Json;
using WEB.Models.Common;

namespace WEB.Utilities.RedisOperations
{
    public class RedisManager : IRedisService
    {
        private readonly Connection RedisConnection;

        public RedisManager(Connection redisConnection)
        {
            RedisConnection = redisConnection;
        }

        public bool AlreadyInBasket(string UserID, int CourseId)
        {
            var BasketExist = GetSelectedCoursesByUserId(UserID);
            if(BasketExist.Succeed)
                if(BasketExist.Data.SelectedCourses.Any(s=>s.CourseId == CourseId.ToString()))
                    return true;
            return false;
        }

        public DataResult<SelectCourseDto> Delete(string userId)
        {
            var status = RedisConnection.Database().KeyDelete(userId);
            if (status)
                return new DataResult<SelectCourseDto>("Sepetiniz zaten boş", false, new SelectCourseDto());
            return GetSelectedCoursesByUserId(userId);
        }

        public DataResult<SelectCourseDto> GetSelectedCoursesByUserId(string UserID)
        {
            // bu key ile data var mı?
            var existBasket = RedisConnection.Database().StringGet(UserID);
            if (!existBasket.HasValue)
                return new DataResult<SelectCourseDto>("Sepetiniz boş", false, new SelectCourseDto());
            return new DataResult<SelectCourseDto>("Sepetiniz", true, JsonSerializer.Deserialize<SelectCourseDto>(existBasket));
        }

        public DataResult<SelectCourseDto> SaveOrUpdate(SelectCourseDto model)
        {
            var basketSucceed = RedisConnection.Database().StringSet(model.UserId,JsonSerializer.Serialize(model));
            if(basketSucceed)
                return new DataResult<SelectCourseDto>("Güncellendi", basketSucceed, model); 
            return new DataResult<SelectCourseDto>("Hata", basketSucceed, model);
        }
    }
}
