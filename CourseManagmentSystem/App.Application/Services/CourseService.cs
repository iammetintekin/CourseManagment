using App.Application.Services.Abstract;
using App.Domain.Dtos;
using App.Domain.Models;
using App.Infrastructure.RepositoryPattern.UnitOfWork;
using App.Shared;
using App.Shared.ReturnObjects;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace App.Application.Services
{
    public class CourseService : ICourseService
    {
        private readonly IUnitOfWork _db; 
        private readonly IMapper _mapper; 
        public CourseService(IUnitOfWork db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public DataResult<Course> Create(Course Model)
        {
            if (!_db.Courses.Any(s => s.Code.Equals(Model.Code)))
            {
                try
                {
                    _db.Courses.Create(Model);
                    _db.Save();
                    return new DataResult<Course>("Kaydedildi", true, Model);
                }
                catch (Exception ex)
                {
                    return new DataResult<Course>($"Hata : {ex.Message}", false, Model);
                }
            }
            return new DataResult<Course>($"Bu kod daha önce kullanılmış : {Model.Code}", false, Model); 
        }

        public DataResult<CourseDto> GetByCode(string Code)
        {
            if (!_db.Courses.Any(s => s.Code.Equals(Code)))
                return new DataResult<CourseDto>("Kaydedildi", true, _mapper.Map<CourseDto>(_db.Courses.Get(s => s.Code.Equals(Code))));
            return new DataResult<CourseDto>($"Aradığınız kurs bulunamadı. ", false, new CourseDto());
        }

        public DataResult<Course> GetById(int Id)
        {
            if (_db.Courses.Any(s => s.Id.Equals(Id)))
            {
                var courseInDb = _db.Courses.Get(s => s.Id.Equals(Id));
                courseInDb.Category = _db.Categories.Get(s => s.Id == courseInDb.CategoryId);
                return new DataResult<Course>("Kurs detayı", true, courseInDb);
            }
            return new DataResult<Course>($"Bulunamadı. ", false, new Course());
        }

        public DataResult<List<Course>> List(int? CategoryId)
        {
            if(CategoryId.HasValue)
                if(_db.Categories.Any(s=>s.Id==CategoryId))
                    return new DataResult<List<Course>>($"", true, _db.Courses.GetAll(x=>x.CategoryId ==CategoryId).ToList());
            return new DataResult<List<Course>>($"", true, _db.Courses.GetAll().ToList()); 
        }

        public DataResult<IPagedList<CourseDto>> List(CourseFilterModel filterModel)
        {
            List<CourseDto> courses = new();
            if (!string.IsNullOrEmpty(filterModel.Keyword))
            {
                courses = _mapper.Map<List<CourseDto>>(_db.Courses.GetAll(s => s.Name.Contains(filterModel.Keyword) || s.Code.Contains(filterModel.Keyword)));
            } 
            var pagedData = courses.ToPagedList(filterModel.Page, 10);  
            return new DataResult<IPagedList<CourseDto>>("", true, pagedData);
        }
    }
}
