using App.Shared.ReturnObjects;
using WEB.Models.Common;

namespace WEB.Utilities.RedisOperations
{
    public interface IRedisService
    {
        DataResult<SelectCourseDto> GetSelectedCoursesByUserId(string UserID);
        bool AlreadyInBasket(string UserID, int CourseId);
        DataResult<SelectCourseDto> SaveOrUpdate(SelectCourseDto model);
        DataResult<SelectCourseDto> Delete(string userId);
    }
}
