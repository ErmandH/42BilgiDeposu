using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ecole42Entity.Migrations
{
    public partial class fkadmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AdminID",
                schema: "dbo",
                table: "Article",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Article_AdminID",
                schema: "dbo",
                table: "Article",
                column: "AdminID");

            migrationBuilder.AddForeignKey(
                name: "FK_Article_Admin_AdminID",
                schema: "dbo",
                table: "Article",
                column: "AdminID",
                principalSchema: "dbo",
                principalTable: "Admin",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Article_Admin_AdminID",
                schema: "dbo",
                table: "Article");

            migrationBuilder.DropIndex(
                name: "IX_Article_AdminID",
                schema: "dbo",
                table: "Article");

            migrationBuilder.DropColumn(
                name: "AdminID",
                schema: "dbo",
                table: "Article");
        }
    }
}
