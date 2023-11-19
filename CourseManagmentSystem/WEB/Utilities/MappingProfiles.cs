using App.Domain.Dtos;
using App.Domain.Models;
using AutoMapper;

namespace WEB.Extensions
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Course, CourseDto>();
        }
    }
}
