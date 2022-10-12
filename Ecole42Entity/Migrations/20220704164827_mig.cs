using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ecole42Entity.Migrations
{
    public partial class mig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Article_Admin_AdminID",
                schema: "dbo",
                table: "Article");

            migrationBuilder.AlterColumn<Guid>(
                name: "AdminID",
                schema: "dbo",
                table: "Article",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "UserID",
                schema: "dbo",
                table: "Article",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Role",
                schema: "dbo",
                table: "Admin",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "User",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletionStatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Article_UserID",
                schema: "dbo",
                table: "Article",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Article_Admin_AdminID",
                schema: "dbo",
                table: "Article",
                column: "AdminID",
                principalSchema: "dbo",
                principalTable: "Admin",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Article_User_UserID",
                schema: "dbo",
                table: "Article",
                column: "UserID",
                principalSchema: "dbo",
                principalTable: "User",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Article_Admin_AdminID",
                schema: "dbo",
                table: "Article");

            migrationBuilder.DropForeignKey(
                name: "FK_Article_User_UserID",
                schema: "dbo",
                table: "Article");

            migrationBuilder.DropTable(
                name: "User",
                schema: "dbo");

            migrationBuilder.DropIndex(
                name: "IX_Article_UserID",
                schema: "dbo",
                table: "Article");

            migrationBuilder.DropColumn(
                name: "UserID",
                schema: "dbo",
                table: "Article");

            migrationBuilder.DropColumn(
                name: "Role",
                schema: "dbo",
                table: "Admin");

            migrationBuilder.AlterColumn<Guid>(
                name: "AdminID",
                schema: "dbo",
                table: "Article",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

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
    }
}
