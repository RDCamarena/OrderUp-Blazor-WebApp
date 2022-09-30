using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderUp.Server.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "enim.etiam@yahoo.net", "Cameron", "Dunlap", "202-918-2132" },
                    { 2, "nulla.integer@aol.couk", "Cameran", "Mercer", "929-891-3348" },
                    { 3, "nec@protonmail.edu", "Arthur", "Hernandez", "212-241-0523" },
                    { 4, "a.auctor.non@aol.couk", "Isadora", "Philips", "326-314-3918" },
                    { 5, "odio.auctor@protonmail.ca", "Davis", "Vega", "582-333-0008" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CustomerId", "Date", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { 1, 4, "2022-03-01", 2, 5 },
                    { 2, 2, "2022-01-20", 1, 1 },
                    { 3, 0, "2019-12-01", 3, 10 },
                    { 4, 5, "2012-05-19", 4, 1 },
                    { 5, 4, "2022-09-30", 3, 1 },
                    { 6, 3, "2022-03-10", 1, 1 },
                    { 7, 3, "2022-03-10", 2, 3 },
                    { 8, 1, "2005-11-01", 1, 2 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Price", "ProductName" },
                values: new object[,]
                {
                    { 1, "Brand new Macbook Pro with new retna display, a 3tb memory and carrying a solid 4060 nvidia graphic card.", 1299.99, "Macbook Pro 13" },
                    { 2, "Gorgeous 60inch TV with 4k capabilities.", 570.64999999999998, "Tv 4K" },
                    { 3, "The most powerful graphic card in the market... good luck getting it.", 2500.0, "RTX 4090" },
                    { 4, "Start your chef dream with a fully loaded cooking set.", 399.99000000000001, "Culinary 50 Piece Set" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
