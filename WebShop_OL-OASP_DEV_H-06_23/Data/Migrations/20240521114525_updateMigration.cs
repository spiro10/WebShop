using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebShop_OL_OASP_DEV_H_06_23.Data.Migrations
{
    /// <inheritdoc />
    public partial class updateMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Addresss",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Created",
                value: new DateTime(2024, 5, 21, 13, 45, 24, 408, DateTimeKind.Local).AddTicks(6055));

            migrationBuilder.UpdateData(
                table: "Companys",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Created",
                value: new DateTime(2024, 5, 21, 13, 45, 24, 408, DateTimeKind.Local).AddTicks(6267));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Addresss",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Created",
                value: new DateTime(2024, 5, 20, 15, 52, 42, 843, DateTimeKind.Local).AddTicks(4049));

            migrationBuilder.UpdateData(
                table: "Companys",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Created",
                value: new DateTime(2024, 5, 20, 15, 52, 42, 843, DateTimeKind.Local).AddTicks(4293));
        }
    }
}
