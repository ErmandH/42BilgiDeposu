using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ecole42Entity.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Admin",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletionStatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletionStatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Function",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletionStatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Function", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "UsefulLink",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    URL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletionStatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsefulLink", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Project",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShortDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CateogryID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletionStatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Project_Category_CategoryID",
                        column: x => x.CategoryID,
                        principalSchema: "dbo",
                        principalTable: "Category",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProjectFunction",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FunctionID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletionStatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectFunction", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProjectFunction_Function_FunctionID",
                        column: x => x.FunctionID,
                        principalSchema: "dbo",
                        principalTable: "Function",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectFunction_Project_ProjectID",
                        column: x => x.ProjectID,
                        principalSchema: "dbo",
                        principalTable: "Project",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectUsefulLink",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsefulLinkID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletionStatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectUsefulLink", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProjectUsefulLink_Project_ProjectID",
                        column: x => x.ProjectID,
                        principalSchema: "dbo",
                        principalTable: "Project",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectUsefulLink_UsefulLink_UsefulLinkID",
                        column: x => x.UsefulLinkID,
                        principalSchema: "dbo",
                        principalTable: "UsefulLink",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Project_CategoryID",
                schema: "dbo",
                table: "Project",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectFunction_FunctionID",
                schema: "dbo",
                table: "ProjectFunction",
                column: "FunctionID");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectFunction_ProjectID",
                schema: "dbo",
                table: "ProjectFunction",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectUsefulLink_ProjectID",
                schema: "dbo",
                table: "ProjectUsefulLink",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectUsefulLink_UsefulLinkID",
                schema: "dbo",
                table: "ProjectUsefulLink",
                column: "UsefulLinkID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admin",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ProjectFunction",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ProjectUsefulLink",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Function",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Project",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "UsefulLink",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Category",
                schema: "dbo");
        }
    }
}
