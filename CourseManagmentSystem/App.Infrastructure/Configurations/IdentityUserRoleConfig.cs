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
    public class IdentityUserRoleConfig : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasKey(r => new { r.UserId, r.RoleId });

            builder.HasData(new IdentityUserRole<string>
            {
                RoleId = "56a10d0e-1d9f-4d44-92af-54ec24bec196",
                UserId = "f11ae9f8-26ad-447f-890d-995c0d72a5c9"
            });
          
        }
    }
}
