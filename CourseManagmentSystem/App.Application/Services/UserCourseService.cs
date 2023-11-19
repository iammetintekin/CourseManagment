using App.Application.Services.Abstract;
using App.Domain.Models;
using App.Infrastructure.RepositoryPattern.UnitOfWork;
using App.Shared.ReturnObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Services
{
    public class UserCourseService : IUserCourseService
    {
        private readonly IUnitOfWork _db;
        public UserCourseService(IUnitOfWork db)
        {
            _db = db;
        }

        public DataResult<UserCourseMapping> CheckUserRegistered(int CourseId, string UserId)
        {
            if(string.IsNullOrEmpty(UserId))
                return new DataResult<UserCourseMapping>("", false,null);

            var anyResult = _db.UserCourseMapping.Any(s=>s.UserId ==  UserId && s.CourseId == CourseId);
            if(anyResult)
                return new DataResult<UserCourseMapping>("", anyResult, _db.UserCourseMapping.Get(s => s.UserId == UserId && s.CourseId == CourseId));
            return new DataResult<UserCourseMapping>("", anyResult, null); 
        }

        public Result Create(List<UserCourseMapping> Datas)
        {
            foreach (var item in Datas)
            {
                _db.UserCourseMapping.Create(item);
                _db.Save();
            }
            return new Result("Kaydedildi.", true);
        }

        public DataResult<List<UserCourseMapping>> GetAllByUserId(string UserId)
        {
            var data = _db.UserCourseMapping.GetAll(s => s.UserId == UserId).ToList();
            foreach (var item in data)
            {
                item.Course = _db.Courses.Get(s => s.Id == item.CourseId);
                item.Course.Category = _db.Categories.Get(s => s.Id == item.Course.CategoryId);
            }

            return new DataResult<List<UserCourseMapping>>("", true, data.OrderBy(s=>s.Course.CategoryId).ToList());
        } 
    }
}
