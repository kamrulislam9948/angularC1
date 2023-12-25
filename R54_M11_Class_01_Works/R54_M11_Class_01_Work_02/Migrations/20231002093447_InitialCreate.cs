using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace R54_M11_Class_01_Work_02.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Size = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "money", nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    OnSale = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    SaleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.SaleId);
                    table.ForeignKey(
                        name: "FK_Sales_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "OnSale", "Picture", "Price", "ProductName", "Size" },
                values: new object[,]
                {
                    { 1, null, "1jpg", 1424m, "Product 1", 2 },
                    { 2, null, "2jpg", 1373m, "Product 2", 3 },
                    { 3, null, "3jpg", 1481m, "Product 3", 1 },
                    { 4, null, "4jpg", 1883m, "Product 4", 2 },
                    { 5, null, "5jpg", 1228m, "Product 5", 3 }
                });

            migrationBuilder.InsertData(
                table: "Sales",
                columns: new[] { "SaleId", "Date", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 6, 4, 15, 34, 46, 832, DateTimeKind.Local).AddTicks(8980), 1, 148 },
                    { 2, new DateTime(2022, 8, 24, 15, 34, 46, 832, DateTimeKind.Local).AddTicks(9007), 2, 111 },
                    { 3, new DateTime(2022, 8, 8, 15, 34, 46, 832, DateTimeKind.Local).AddTicks(9016), 3, 104 },
                    { 4, new DateTime(2022, 8, 11, 15, 34, 46, 832, DateTimeKind.Local).AddTicks(9024), 4, 153 },
                    { 5, new DateTime(2022, 6, 3, 15, 34, 46, 832, DateTimeKind.Local).AddTicks(9032), 5, 128 },
                    { 6, new DateTime(2022, 7, 1, 15, 34, 46, 832, DateTimeKind.Local).AddTicks(9042), 1, 156 },
                    { 7, new DateTime(2022, 5, 21, 15, 34, 46, 832, DateTimeKind.Local).AddTicks(9051), 2, 138 },
                    { 8, new DateTime(2022, 8, 20, 15, 34, 46, 832, DateTimeKind.Local).AddTicks(9058), 3, 144 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sales_ProductId",
                table: "Sales",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sales");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
