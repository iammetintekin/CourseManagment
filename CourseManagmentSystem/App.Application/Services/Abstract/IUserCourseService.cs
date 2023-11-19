using App.Domain.Models;
using App.Shared.ReturnObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Services.Abstract
{
    public interface IUserCourseService
    {
        DataResult<List<UserCourseMapping>> GetAllByUserId(string UserId);
        Result Create(List<UserCourseMapping> Datas);
        DataResult<UserCourseMapping> CheckUserRegistered(int CourseId, string UserId);
    }
}
