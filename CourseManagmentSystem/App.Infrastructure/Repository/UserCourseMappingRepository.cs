using App.Domain.Models;
using App.Infrastructure.DatabaseContext;
using App.Infrastructure.Repository.EntityRepositories;
using App.Infrastructure.RepositoryPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.Repository
{
    public class UserCourseMappingRepository : RepositoryManager<UserCourseMapping>, IUserCourseMappingRepository
    {
        public UserCourseMappingRepository(PostreSqlDatabaseContext postreSqlDatabaseContext) : base(postreSqlDatabaseContext)
        {
        }
    }
}
