﻿// <auto-generated />
using System;
using App.Infrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace App.Infrastructure.Migrations
{
    [DbContext(typeof(PostreSqlDatabaseContext))]
    [Migration("20231118113641_userCoursemapping")]
    partial class userCoursemapping
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("App.Domain.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Category");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Yazılım"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Grafik & Tasarım"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Siber Güvenlik"
                        });
                });

            modelBuilder.Entity("App.Domain.Models.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("integer");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Courses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Code = "EGT01",
                            Description = ".NET Framework, Microsoft tarafından geliştirilen, açık İnternet protokolleri ve standartları üzerine kurulmuş bir \"uygulama\" geliştirme platformu. Daha önce Sun Microsystems tarafından geliştirilmiş olan Java platformuna önemli benzerlikler göstermektedir. Buradaki uygulama kavramının kapsamı çok geniştir.",
                            Name = ".Net Eğitimi"
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            Code = "EGT02",
                            Description = "C#, birden fazla paradigmayı destekleyen genel amaçlı, üst düzey bir programlama dilidir. C#, statik yazım, güçlü yazım, sözcüksel kapsamlı, zorunlu, bildirimsel, işlevsel, genel, nesne yönelimli ve bileşen yönelimli programlama disiplinlerini kapsar.",
                            Name = "C# Temelleri"
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 1,
                            Code = "EGT03",
                            Description = "Web geliştiricilerinin öğrenmesi gereken 3 farklı dil bulunmaktadır. Bunlar; web sayfalarının içeriğini tanımlamak için HTML, web sayfalarının düzenini belirlemek için CSS ve son olarak web sayfalarının davranışlarını programlamak için kullanılan JavaScript, yani kısaca JS'dir.",
                            Name = "Html, CSS, Javascript"
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 2,
                            Code = "EGT04",
                            Description = "",
                            Name = "Photoshop"
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 2,
                            Code = "EGT05",
                            Description = "",
                            Name = "Adobe CS 6"
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 2,
                            Code = "EGT06",
                            Description = "",
                            Name = "Paint Dersleri"
                        },
                        new
                        {
                            Id = 7,
                            CategoryId = 3,
                            Code = "EGT07",
                            Description = "",
                            Name = "Temel Sızma Eğitimleri"
                        },
                        new
                        {
                            Id = 8,
                            CategoryId = 3,
                            Code = "EGT08",
                            Description = "",
                            Name = "Linux Dersleri"
                        },
                        new
                        {
                            Id = 9,
                            CategoryId = 3,
                            Code = "EGT09",
                            Description = "",
                            Name = "Wireshark Kullanımı"
                        });
                });

            modelBuilder.Entity("App.Domain.Models.UserCourseMapping", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CourseId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("UserId");

                    b.ToTable("UserCourses");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("NormalizedName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = "56a10d0e-1d9f-4d44-92af-54ec24bec196",
                            ConcurrencyStamp = "7e30a38d-c7c4-4d32-990d-e62424a7e29f",
                            Name = "user",
                            NormalizedName = "USER"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("RoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("text");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("text");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = "f11ae9f8-26ad-447f-890d-995c0d72a5c9",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "a86ae9b4-afa9-41af-8b7a-f0ed085c3d42",
                            Email = "user@gmail.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            PasswordHash = "AQAAAAIAAYagAAAAEMGAqme6mY47C+lOx5vIlpKtD5xnKIhS+k7T9qbrFLGM6SUZes9mNWkqEvq5cDAajw==",
                            PhoneNumber = "5412655821",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "18b1986d-a601-481c-a94d-e7237f60ac81",
                            TwoFactorEnabled = false,
                            UserName = "metintekin"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("UserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.ToTable("UserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.HasKey("UserId", "RoleId");

                    b.ToTable("UserRoles");

                    b.HasData(
                        new
                        {
                            UserId = "f11ae9f8-26ad-447f-890d-995c0d72a5c9",
                            RoleId = "56a10d0e-1d9f-4d44-92af-54ec24bec196"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("UserTokens");
                });

            modelBuilder.Entity("App.Domain.Models.Course", b =>
                {
                    b.HasOne("App.Domain.Models.Category", "Category")
                        .WithMany("Courses")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("App.Domain.Models.UserCourseMapping", b =>
                {
                    b.HasOne("App.Domain.Models.Course", "Course")
                        .WithMany("Users")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("User");
                });

            modelBuilder.Entity("App.Domain.Models.Category", b =>
                {
                    b.Navigation("Courses");
                });

            modelBuilder.Entity("App.Domain.Models.Course", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
