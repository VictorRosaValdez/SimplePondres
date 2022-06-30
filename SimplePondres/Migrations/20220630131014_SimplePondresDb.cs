using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimplePondres.Migrations
{
    public partial class SimplePondresDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    CompanyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    CompanyPhoneNumber = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.CompanyId);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ExternalReference = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    State = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    TimeOfDelivery = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Adress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ExternalReference = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ExtraRequirements = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Order_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Company",
                columns: new[] { "CompanyId", "CompanyName", "CompanyPhoneNumber", "Email" },
                values: new object[,]
                {
                    { 1, "Package solutions", 310401574, "package@solutions.com" },
                    { 2, "Het thuiszorg BV", 310401575, "ana@thuiszorg.nl" }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ProductId", "Description", "ExternalReference", "Name", "Stock", "Type" },
                values: new object[,]
                {
                    { 1, "This is a wonderful card", "Pondres simple card", "Simple card", 5, "Card" },
                    { 2, "The best bord ever", "Pondres amazing bord", "Amazing bord", 0, "Bord" },
                    { 3, "Magic paper", "Pondres paper", "Paper", 10, "Print Paper" }
                });

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "OrderId", "Adress", "CompanyId", "ExternalReference", "ExtraRequirements", "ProductId", "State", "TimeOfDelivery" },
                values: new object[] { 1, "Molenlaan 5", 2, "Customer 1", "Please deliver the order at the warehouse", 3, "Created", new DateTime(2022, 6, 30, 15, 10, 14, 512, DateTimeKind.Local).AddTicks(1799) });

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "OrderId", "Adress", "CompanyId", "ExternalReference", "ExtraRequirements", "ProductId", "State", "TimeOfDelivery" },
                values: new object[] { 2, "Sonseweg 7", 2, "Customer 2", "No extra requirements", 3, "Picked", new DateTime(2022, 6, 30, 15, 10, 14, 512, DateTimeKind.Local).AddTicks(1837) });

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "OrderId", "Adress", "CompanyId", "ExternalReference", "ExtraRequirements", "ProductId", "State", "TimeOfDelivery" },
                values: new object[] { 3, "Planetelaan 1", 1, "Customer 3", "No extra requirements", 1, "Delivered", new DateTime(2022, 6, 30, 15, 10, 14, 512, DateTimeKind.Local).AddTicks(1840) });

            migrationBuilder.CreateIndex(
                name: "IX_Order_CompanyId",
                table: "Order",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_ProductId",
                table: "Order",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "Product");
        }
    }
}
