using App.Infrastructure.DatabaseContext;
using App.Infrastructure.Repository;
using App.Infrastructure.Repository.EntityRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.RepositoryPattern.UnitOfWork
{
    public class UnitOfWorkManager : IUnitOfWork
    {
        private PostreSqlDatabaseContext _databaseContext;
        public UnitOfWorkManager(PostreSqlDatabaseContext postreSqlDatabaseContext)
        {
            _databaseContext = postreSqlDatabaseContext;            
        }
        public ICourseRepository Courses => _courseRepository ?? new CourseRepository(_databaseContext);
        public ICategoryRepository Categories => _categoryRepository ?? new CategoryRepository(_databaseContext);
        public IUserCourseMappingRepository UserCourseMapping => _userCourseMappingRepository ?? new UserCourseMappingRepository(_databaseContext);

        private readonly CategoryRepository _categoryRepository;
        private readonly CourseRepository _courseRepository;
        private readonly UserCourseMappingRepository _userCourseMappingRepository;
        public async ValueTask DisposeAsync()
        {
            await _databaseContext.DisposeAsync();
        }

        public int Save()
        {
            return _databaseContext.SaveChanges();
        }

        public void Dispose()
        {
            _databaseContext.Dispose();
        }
    }
}
