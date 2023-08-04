using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SalesProject.Migrations
{
    public partial class CartProductPkChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CartProduct",
                table: "CartProduct");

            migrationBuilder.AlterColumn<string>(
                name: "Sku",
                table: "CartProduct",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "CartProduct",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CartProduct",
                table: "CartProduct",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CartProduct",
                table: "CartProduct");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "CartProduct");

            migrationBuilder.AlterColumn<string>(
                name: "Sku",
                table: "CartProduct",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CartProduct",
                table: "CartProduct",
                column: "Sku");
        }
    }
}
