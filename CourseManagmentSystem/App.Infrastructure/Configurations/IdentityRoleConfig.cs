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
    public class IdentityRoleConfig : IEntityTypeConfiguration<IdentityRole>
    {

        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            var userRole = new IdentityRole
            {
                Id= "56a10d0e-1d9f-4d44-92af-54ec24bec196",
                Name = "user",
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                NormalizedName = "USER".ToLower().ToUpper(),
            };
            builder.HasData(userRole);
        }
    }
}
