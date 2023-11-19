using App.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.Configurations
{
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(new Category
                {
                    Id = 1,
                    Name = "Yazılım",
                }, new Category
                {
                    Id = 2,
                    Name = "Grafik & Tasarım"
                }, new Category
                {
                    Id = 3,
                    Name = "Siber Güvenlik"
                });
        }
    }
}
