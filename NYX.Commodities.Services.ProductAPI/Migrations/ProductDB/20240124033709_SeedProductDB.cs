using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NYX.Commodities.Services.ProductAPI.Migrations.ProductDB
{
    /// <inheritdoc />
    public partial class SeedProductDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "ProductColor", "ProductDescription", "ProductName", "ProductPrice" },
                values: new object[,]
                {
                    { 1, "Titanium", "Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit", "iPhone 15 Pro", 999.00m },
                    { 2, "Blue", "Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit", "iPhone 15", 899.00m },
                    { 3, "Silver", "Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit", "iPad", 570.00m },
                    { 4, "Black", "Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit", "Mac Pro", 1300.00m },
                    { 5, "White", "Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit", "AirPods", 260.00m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 5);
        }
    }
}
