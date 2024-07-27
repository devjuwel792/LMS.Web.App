using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdatebookTable12343 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "PublisherYear",
                table: "Books",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateOnly),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "EditionDate",
                table: "Books",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateOnly),
                oldType: "date",
                oldNullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateOnly>(
                name: "PublisherYear",
                table: "Books",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateOnly>(
                name: "EditionDate",
                table: "Books",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2024, 7, 27, 15, 21, 11, 358, DateTimeKind.Unspecified).AddTicks(7237), new TimeSpan(0, 6, 0, 0, 0)), new DateTimeOffset(new DateTime(2024, 7, 27, 15, 21, 11, 358, DateTimeKind.Unspecified).AddTicks(7277), new TimeSpan(0, 6, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                table: "Publisher",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTimeOffset(new DateTime(2024, 7, 27, 15, 21, 11, 358, DateTimeKind.Unspecified).AddTicks(8861), new TimeSpan(0, 6, 0, 0, 0)), new DateTimeOffset(new DateTime(2024, 7, 27, 15, 21, 11, 358, DateTimeKind.Unspecified).AddTicks(8869), new TimeSpan(0, 6, 0, 0, 0)) });
        }
    }
}
