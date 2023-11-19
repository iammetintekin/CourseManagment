using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Models;
using App.Infrastructure.Configurations;
using System.Reflection.Emit;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace App.Infrastructure.DatabaseContext
{
    public class PostreSqlDatabaseContext : IdentityDbContext
    {
        public PostreSqlDatabaseContext(DbContextOptions<PostreSqlDatabaseContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new IdentityUserConfig());
            modelBuilder.ApplyConfiguration(new IdentityRoleConfig());
            modelBuilder.ApplyConfiguration(new IdentityUserRoleConfig());
            modelBuilder.ApplyConfiguration(new IdentityUserLoginConfig()); 
            modelBuilder.ApplyConfiguration(new IdentityUserTokenConfig()); 
            modelBuilder.ApplyConfiguration(new RoleClaimConfig()); 

            modelBuilder.ApplyConfiguration(new CategoryConfig());
            modelBuilder.ApplyConfiguration(new CourseConfig());
        } 
        public DbSet<UserCourseMapping> UserCourses { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}
