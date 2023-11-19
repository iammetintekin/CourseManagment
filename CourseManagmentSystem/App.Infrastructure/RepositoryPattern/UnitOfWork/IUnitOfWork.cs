using App.Infrastructure.Repository.EntityRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.RepositoryPattern.UnitOfWork
{
    public interface IUnitOfWork:IAsyncDisposable, IDisposable
    {
        ICourseRepository Courses { get; }
        ICategoryRepository Categories { get; }
        IUserCourseMappingRepository UserCourseMapping { get; }
        int Save();
    }
}
