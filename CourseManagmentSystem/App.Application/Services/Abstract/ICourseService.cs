using App.Domain.Dtos;
using App.Domain.Models;
using App.Shared;
using App.Shared.ReturnObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace App.Application.Services.Abstract
{
    public interface ICourseService
    {
        DataResult<Course> Create(Course Model);
        DataResult<Course> GetById(int Id);
        DataResult<CourseDto> GetByCode(string Code); 
        DataResult<IPagedList<CourseDto>> List(CourseFilterModel filterModel);
        DataResult<List<Course>> List(int? CategoryId);
    }
}
