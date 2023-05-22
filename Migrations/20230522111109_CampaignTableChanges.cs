using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalesProject.Migrations
{
    public partial class CampaignTableChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Campaign_Product_ProductId",
                table: "Campaign");

            migrationBuilder.DropIndex(
                name: "IX_Campaign_ProductId",
                table: "Campaign");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Campaign");

            migrationBuilder.AddColumn<int>(
                name: "ActiveCampaignId",
                table: "Product",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DiscountValue",
                table: "Campaign",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Campaign",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Campaign",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Product_ActiveCampaignId",
                table: "Product",
                column: "ActiveCampaignId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Campaign_ActiveCampaignId",
                table: "Product",
                column: "ActiveCampaignId",
                principalTable: "Campaign",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Campaign_ActiveCampaignId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_ActiveCampaignId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ActiveCampaignId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "DiscountValue",
                table: "Campaign");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Campaign");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Campaign");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Campaign",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Campaign_ProductId",
                table: "Campaign",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Campaign_Product_ProductId",
                table: "Campaign",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id");
        }
    }
}
