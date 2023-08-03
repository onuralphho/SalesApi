using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalesProject.Migrations
{
    public partial class OrderProductColumChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "CartProduct");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "CartProduct");

            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "CartProduct");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "CartProduct",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "CartProduct",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalPrice",
                table: "CartProduct",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
