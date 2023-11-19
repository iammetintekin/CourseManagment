using CourseAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CourseAPI.DatabaseContext
{
    public class PostreSqlDatabaseContext:DbContext
    {
        public PostreSqlDatabaseContext(DbContextOptions<PostreSqlDatabaseContext> options): base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PostreSqlDatabaseContext).Assembly);
        }
        public DbSet<UserCourseMapping> UserCourses { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}
