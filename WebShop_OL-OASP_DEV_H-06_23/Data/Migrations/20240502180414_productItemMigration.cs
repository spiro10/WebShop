using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebShop_OL_OASP_DEV_H_06_23.Data.Migrations
{
    /// <inheritdoc />
    public partial class productItemMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductCategorys",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Valid = table.Column<bool>(type: "bit", nullable: false),
                    CompanyId = table.Column<long>(type: "bigint", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategorys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductCategorys_Companys_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companys",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProductItems",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Valid = table.Column<bool>(type: "bit", nullable: false),
                    ProductCategoryId = table.Column<long>(type: "bigint", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(9,2)", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(9,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductItems_ProductCategorys_ProductCategoryId",
                        column: x => x.ProductCategoryId,
                        principalTable: "ProductCategorys",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "Addresss",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Created", "Valid" },
                values: new object[] { new DateTime(2024, 5, 2, 20, 4, 12, 919, DateTimeKind.Local).AddTicks(7229), true });

            migrationBuilder.UpdateData(
                table: "Companys",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Created", "Valid" },
                values: new object[] { new DateTime(2024, 5, 2, 20, 4, 12, 919, DateTimeKind.Local).AddTicks(7497), true });

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategorys_CompanyId",
                table: "ProductCategorys",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductItems_ProductCategoryId",
                table: "ProductItems",
                column: "ProductCategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductItems");

            migrationBuilder.DropTable(
                name: "ProductCategorys");

            migrationBuilder.UpdateData(
                table: "Addresss",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Created", "Valid" },
                values: new object[] { new DateTime(2024, 4, 22, 19, 29, 19, 856, DateTimeKind.Local).AddTicks(1172), false });

            migrationBuilder.UpdateData(
                table: "Companys",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Created", "Valid" },
                values: new object[] { new DateTime(2024, 4, 22, 19, 29, 19, 856, DateTimeKind.Local).AddTicks(1339), false });
        }
    }
}
