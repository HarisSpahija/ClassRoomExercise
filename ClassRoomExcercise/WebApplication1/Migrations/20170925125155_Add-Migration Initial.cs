using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WebApplication1.Migrations
{
    public partial class AddMigrationInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ads_Categories_CategoryID",
                table: "Ads");

            migrationBuilder.RenameColumn(
                name: "CategoryID",
                table: "Ads",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Ads_CategoryID",
                table: "Ads",
                newName: "IX_Ads_CategoryId");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Ads",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Ads_Categories_CategoryId",
                table: "Ads",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ads_Categories_CategoryId",
                table: "Ads");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Ads",
                newName: "CategoryID");

            migrationBuilder.RenameIndex(
                name: "IX_Ads_CategoryId",
                table: "Ads",
                newName: "IX_Ads_CategoryID");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryID",
                table: "Ads",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Ads_Categories_CategoryID",
                table: "Ads",
                column: "CategoryID",
                principalTable: "Categories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
