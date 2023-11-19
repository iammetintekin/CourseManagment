using App.Application.Services.Abstract;
using App.Domain.Models;
using App.Infrastructure.RepositoryPattern.UnitOfWork;
using App.Shared.ReturnObjects;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _db;
        private readonly IMapper _mapper;
        public CategoryService(IUnitOfWork db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public DataResult<Category> Create(Category Model)
        {
            try
            {
                _db.Categories.Create(Model);
                _db.Save();
                return new DataResult<Category>("Kaydedildi", true, Model);
            }
            catch (Exception ex)
            {
                return new DataResult<Category>($"Hata : {ex.Message}", false, Model);
            }
        }

        public DataResult<List<Category>> List()
        {
            return new DataResult<List<Category>>("", true, _db.Categories.GetAll().ToList());
        }
    }
}
