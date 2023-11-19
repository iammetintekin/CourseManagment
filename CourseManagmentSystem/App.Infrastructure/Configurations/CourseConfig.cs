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
    public class CourseConfig : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasData(new Course
                {
                    Id=1,
                    Name = ".Net Eğitimi",
                    Description = ".NET Framework, Microsoft tarafından geliştirilen, açık İnternet protokolleri ve standartları üzerine kurulmuş bir \"uygulama\" geliştirme platformu. Daha önce Sun Microsystems tarafından geliştirilmiş olan Java platformuna önemli benzerlikler göstermektedir. Buradaki uygulama kavramının kapsamı çok geniştir.",
                    Code= "EGT01",
                    CategoryId = 1, 
                },
                new Course
                {
                    Id = 2,
                    Name = "C# Temelleri",
                    Description = "C#, birden fazla paradigmayı destekleyen genel amaçlı, üst düzey bir programlama dilidir. C#, statik yazım, güçlü yazım, sözcüksel kapsamlı, zorunlu, bildirimsel, işlevsel, genel, nesne yönelimli ve bileşen yönelimli programlama disiplinlerini kapsar.",
                    Code = "EGT02",
                    CategoryId = 1,
                }, 
                new Course
                {
                    Id = 3,
                    Name = "Html, CSS, Javascript",
                    Description = "Web geliştiricilerinin öğrenmesi gereken 3 farklı dil bulunmaktadır. Bunlar; web sayfalarının içeriğini tanımlamak için HTML, web sayfalarının düzenini belirlemek için CSS ve son olarak web sayfalarının davranışlarını programlamak için kullanılan JavaScript, yani kısaca JS'dir.",
                    Code = "EGT03",
                    CategoryId = 1,
                },
                new Course
                {
                     Id = 4,
                     Name = "Photoshop",
                     Description = "",
                     Code = "EGT04",
                     CategoryId = 2,
                },
                new Course
                {
                    Id = 5,
                    Name = "Adobe CS 6",
                    Description = "",
                    Code = "EGT05",
                    CategoryId = 2,
                },
                new Course
                {
                    Id = 6,
                    Name = "Paint Dersleri",
                    Description = "",
                    Code = "EGT06",
                    CategoryId = 2,
                },
                new Course
                {
                    Id = 7,
                    Name = "Temel Sızma Eğitimleri",
                    Description = "",
                    Code = "EGT07",
                    CategoryId = 3,
                },
                new Course
                {
                    Id = 8,
                    Name = "Linux Dersleri",
                    Description = "",
                    Code = "EGT08",
                    CategoryId = 3,
                },
                new Course
                {
                    Id = 9,
                    Name = "Wireshark Kullanımı",
                    Description = "",
                    Code = "EGT09",
                    CategoryId = 3,
                });
        }
    }
}
