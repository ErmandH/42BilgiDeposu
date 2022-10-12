using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ecole42Entity.Migrations
{
    public partial class bitti : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Project_Category_CategoryID",
                schema: "dbo",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "CateogryID",
                schema: "dbo",
                table: "Project");

            migrationBuilder.AlterColumn<Guid>(
                name: "CategoryID",
                schema: "dbo",
                table: "Project",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Category_CategoryID",
                schema: "dbo",
                table: "Project",
                column: "CategoryID",
                principalSchema: "dbo",
                principalTable: "Category",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Project_Category_CategoryID",
                schema: "dbo",
                table: "Project");

            migrationBuilder.AlterColumn<Guid>(
                name: "CategoryID",
                schema: "dbo",
                table: "Project",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "CateogryID",
                schema: "dbo",
                table: "Project",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Category_CategoryID",
                schema: "dbo",
                table: "Project",
                column: "CategoryID",
                principalSchema: "dbo",
                principalTable: "Category",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
