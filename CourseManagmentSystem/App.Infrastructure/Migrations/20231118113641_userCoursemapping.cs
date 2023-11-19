using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class userCoursemapping : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "56a10d0e-1d9f-4d44-92af-54ec24bec196",
                column: "ConcurrencyStamp",
                value: "7e30a38d-c7c4-4d32-990d-e62424a7e29f");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "f11ae9f8-26ad-447f-890d-995c0d72a5c9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a86ae9b4-afa9-41af-8b7a-f0ed085c3d42", "AQAAAAIAAYagAAAAEMGAqme6mY47C+lOx5vIlpKtD5xnKIhS+k7T9qbrFLGM6SUZes9mNWkqEvq5cDAajw==", "18b1986d-a601-481c-a94d-e7237f60ac81" });

            migrationBuilder.CreateIndex(
                name: "IX_UserCourses_UserId",
                table: "UserCourses",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserCourses_Users_UserId",
                table: "UserCourses",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserCourses_Users_UserId",
                table: "UserCourses");

            migrationBuilder.DropIndex(
                name: "IX_UserCourses_UserId",
                table: "UserCourses");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "56a10d0e-1d9f-4d44-92af-54ec24bec196",
                column: "ConcurrencyStamp",
                value: "b489c433-ce55-4154-bb7a-305d6c8f1bac");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "f11ae9f8-26ad-447f-890d-995c0d72a5c9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "382fddb0-4492-42ff-8291-dd52a7ef9a9a", "AQAAAAIAAYagAAAAEPAlt7hvXHLR2a0kFb/GloQFnE/BjF2OpT2iEaX8BBcRfOdWGsSUtkGD/1fQVfYL2A==", "9582dd1d-e877-4996-8662-051117c271d9" });
        }
    }
}
