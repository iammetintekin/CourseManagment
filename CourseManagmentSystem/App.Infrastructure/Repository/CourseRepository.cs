using App.Domain.Models;
using App.Infrastructure.DatabaseContext;
using App.Infrastructure.Repository.EntityRepositories;
using App.Infrastructure.RepositoryPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.Repository
{
    public class CourseRepository : RepositoryManager<Course>, ICourseRepository
    {
        public CourseRepository(PostreSqlDatabaseContext postreSqlDatabaseContext) : base(postreSqlDatabaseContext)
        {
        }
    }
}
