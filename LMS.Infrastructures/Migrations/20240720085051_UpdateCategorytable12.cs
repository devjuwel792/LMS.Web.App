using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCategorytable12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Default",
                table: "Category",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "Default", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2024, 7, 20, 14, 50, 49, 703, DateTimeKind.Unspecified).AddTicks(1729), new TimeSpan(0, 6, 0, 0, 0)), true, new DateTimeOffset(new DateTime(2024, 7, 20, 14, 50, 49, 703, DateTimeKind.Unspecified).AddTicks(1777), new TimeSpan(0, 6, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Publisher",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2024, 7, 20, 14, 50, 49, 703, DateTimeKind.Unspecified).AddTicks(4083), new TimeSpan(0, 6, 0, 0, 0)), new DateTimeOffset(new DateTime(2024, 7, 20, 14, 50, 49, 703, DateTimeKind.Unspecified).AddTicks(4107), new TimeSpan(0, 6, 0, 0, 0)) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Default",
                table: "Category");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2024, 7, 20, 12, 54, 5, 189, DateTimeKind.Unspecified).AddTicks(266), new TimeSpan(0, 6, 0, 0, 0)), new DateTimeOffset(new DateTime(2024, 7, 20, 12, 54, 5, 189, DateTimeKind.Unspecified).AddTicks(304), new TimeSpan(0, 6, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Publisher",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2024, 7, 20, 12, 54, 5, 189, DateTimeKind.Unspecified).AddTicks(1921), new TimeSpan(0, 6, 0, 0, 0)), new DateTimeOffset(new DateTime(2024, 7, 20, 12, 54, 5, 189, DateTimeKind.Unspecified).AddTicks(1928), new TimeSpan(0, 6, 0, 0, 0)) });
        }
    }
}
