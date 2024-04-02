using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AMS3ASales.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Product(Id,Description,IsActive,Price,Stock,CreateDate,ImageURL) values('35AB9767-5168-4D75-9B16-4F9D428B80C0','Coca-Cola',1,9.99,32,'2022/04/02','Coca.jpg')");
            migrationBuilder.Sql("INSERT INTO Product(Id,Description,IsActive,Price,Stock,CreateDate,ImageURL) values('484B1620-5D12-414F-9CC2-541466E1E41C','Pão',1,3.25,12,'2021/03/12','pizzas.jpg')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP TABLE Product");
        }
    }
}
