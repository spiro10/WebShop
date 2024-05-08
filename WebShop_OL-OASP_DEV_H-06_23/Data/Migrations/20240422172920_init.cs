using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebShop_OL_OASP_DEV_H_06_23.Data.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "AddressId",
                table: "AspNetUsers",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Addresss",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Valid = table.Column<bool>(type: "bit", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresss", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Companys",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Valid = table.Column<bool>(type: "bit", nullable: false),
                    AddressId = table.Column<long>(type: "bigint", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VAT = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Companys_Addresss_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresss",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Addresss",
                columns: new[] { "Id", "City", "Country", "Created", "Number", "Street", "Updated", "Valid" },
                values: new object[] { 1L, "Zagreb", "Hrvatska", new DateTime(2024, 4, 22, 19, 29, 19, 856, DateTimeKind.Local).AddTicks(1172), "100", "Maksimirska", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false });

            migrationBuilder.InsertData(
                table: "Companys",
                columns: new[] { "Id", "AddressId", "Created", "FullName", "ShortName", "Updated", "VAT", "Valid" },
                values: new object[] { 1L, 1L, new DateTime(2024, 4, 22, 19, 29, 19, 856, DateTimeKind.Local).AddTicks(1339), "Tvrtka d.o.o.", "Tvrtka", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "71834573974", false });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_AddressId",
                table: "AspNetUsers",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Companys_AddressId",
                table: "Companys",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Addresss_AddressId",
                table: "AspNetUsers",
                column: "AddressId",
                principalTable: "Addresss",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Addresss_AddressId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Companys");

            migrationBuilder.DropTable(
                name: "Addresss");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_AddressId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");
        }
    }
}
