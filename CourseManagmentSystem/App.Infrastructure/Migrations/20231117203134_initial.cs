using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace App.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: false),
                    CategoryId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courses_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserCourses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    CourseId = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCourses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserCourses_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Yazılım" },
                    { 2, "Grafik & Tasarım" },
                    { 3, "Siber Güvenlik" }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CategoryId", "Code", "Description", "Name" },
                values: new object[,]
                {
                    { 1, 1, "EGT01", ".NET Framework, Microsoft tarafından geliştirilen, açık İnternet protokolleri ve standartları üzerine kurulmuş bir \"uygulama\" geliştirme platformu. Daha önce Sun Microsystems tarafından geliştirilmiş olan Java platformuna önemli benzerlikler göstermektedir. Buradaki uygulama kavramının kapsamı çok geniştir.", ".Net Eğitimi" },
                    { 2, 1, "EGT02", "C#, birden fazla paradigmayı destekleyen genel amaçlı, üst düzey bir programlama dilidir. C#, statik yazım, güçlü yazım, sözcüksel kapsamlı, zorunlu, bildirimsel, işlevsel, genel, nesne yönelimli ve bileşen yönelimli programlama disiplinlerini kapsar.", "C# Temelleri" },
                    { 3, 1, "EGT03", "Web geliştiricilerinin öğrenmesi gereken 3 farklı dil bulunmaktadır. Bunlar; web sayfalarının içeriğini tanımlamak için HTML, web sayfalarının düzenini belirlemek için CSS ve son olarak web sayfalarının davranışlarını programlamak için kullanılan JavaScript, yani kısaca JS'dir.", "Html, CSS, Javascript" },
                    { 4, 2, "EGT04", "", "Photoshop" },
                    { 5, 2, "EGT05", "", "Adobe CS 6" },
                    { 6, 2, "EGT06", "", "Paint Dersleri" },
                    { 7, 3, "EGT07", "", "Temel Sızma Eğitimleri" },
                    { 8, 3, "EGT08", "", "Linux Dersleri" },
                    { 9, 3, "EGT09", "", "Wireshark Kullanımı" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CategoryId",
                table: "Courses",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCourses_CourseId",
                table: "UserCourses",
                column: "CourseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserCourses");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
