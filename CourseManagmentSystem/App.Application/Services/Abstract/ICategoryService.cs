using App.Domain.Models;
using App.Shared.ReturnObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Services.Abstract
{
    public interface ICategoryService
    {
        DataResult<Category> Create(Category Model);
        DataResult<List<Category>> List(); 
    }
}
