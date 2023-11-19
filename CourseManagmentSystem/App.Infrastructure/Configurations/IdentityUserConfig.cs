using App.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.Configurations
{
    internal class IdentityUserConfig : IEntityTypeConfiguration<IdentityUser>
    {
        public void Configure(EntityTypeBuilder<IdentityUser> builder)
        {
            var testUser = new IdentityUser
            {
                Id= "f11ae9f8-26ad-447f-890d-995c0d72a5c9",
                Email = "user@gmail.com",
                NormalizedEmail = "USER@GMAIL.COM",
                EmailConfirmed = true, 
                UserName = "metintekin",
                NormalizedUserName = "METINTEKIN",
                PhoneNumber = "5412655821", 
                SecurityStamp = Guid.NewGuid().ToString(), 
            };
            testUser.PasswordHash = CreatePasswordHash(testUser, "user123");
            builder.HasData(testUser);
        }
        private string CreatePasswordHash(IdentityUser user, string pass)
        {
            var hasher = new PasswordHasher<IdentityUser>();
            return hasher.HashPassword(user, pass);
        }
    }
}
