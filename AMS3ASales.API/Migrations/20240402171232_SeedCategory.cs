using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AMS3ASales.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Category(Id,Description,IsActive,ImageURL) values('5F59179B-5C40-4F95-A78F-8A8E2C4128F5','Bebidas',1,'bebidas.jpg')");
            migrationBuilder.Sql("INSERT INTO Category(Id,Description,IsActive,ImageURL) values('7F54E53E-45CB-481C-91F7-2C25249E0CD9','Pizzas',1,'pizzas.jpg')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP TABLE Category");
        }
    }
}
