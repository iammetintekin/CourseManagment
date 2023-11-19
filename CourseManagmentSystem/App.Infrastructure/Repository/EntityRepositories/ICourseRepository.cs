using App.Domain.Models;
using App.Infrastructure.RepositoryPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.Repository.EntityRepositories
{
    public interface ICourseRepository:IRepositoryService<Course>
    {

    }
}
