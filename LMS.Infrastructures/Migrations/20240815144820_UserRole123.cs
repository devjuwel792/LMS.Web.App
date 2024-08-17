using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UserRole123 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "78fec8c8-f529-453e-beb5-2503503543d6", null, "admin", "admin" },
                    { "987dbad9-be71-4064-9b96-1c6b6a15b3ea", null, "librarian", "librarian" },
                    { "a7f8965e-6a31-49fb-8bb3-d7a3a65a4d78", null, "student", "student" }
                });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2024, 8, 15, 20, 48, 18, 342, DateTimeKind.Unspecified).AddTicks(2302), new TimeSpan(0, 6, 0, 0, 0)), new DateTimeOffset(new DateTime(2024, 8, 15, 20, 48, 18, 342, DateTimeKind.Unspecified).AddTicks(2393), new TimeSpan(0, 6, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Publisher",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2024, 8, 15, 20, 48, 18, 342, DateTimeKind.Unspecified).AddTicks(5501), new TimeSpan(0, 6, 0, 0, 0)), new DateTimeOffset(new DateTime(2024, 8, 15, 20, 48, 18, 342, DateTimeKind.Unspecified).AddTicks(5516), new TimeSpan(0, 6, 0, 0, 0)) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "78fec8c8-f529-453e-beb5-2503503543d6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "987dbad9-be71-4064-9b96-1c6b6a15b3ea");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a7f8965e-6a31-49fb-8bb3-d7a3a65a4d78");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2024, 7, 27, 15, 32, 15, 474, DateTimeKind.Unspecified).AddTicks(9060), new TimeSpan(0, 6, 0, 0, 0)), new DateTimeOffset(new DateTime(2024, 7, 27, 15, 32, 15, 474, DateTimeKind.Unspecified).AddTicks(9098), new TimeSpan(0, 6, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Publisher",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2024, 7, 27, 15, 32, 15, 475, DateTimeKind.Unspecified).AddTicks(920), new TimeSpan(0, 6, 0, 0, 0)), new DateTimeOffset(new DateTime(2024, 7, 27, 15, 32, 15, 475, DateTimeKind.Unspecified).AddTicks(932), new TimeSpan(0, 6, 0, 0, 0)) });
        }
    }
}
