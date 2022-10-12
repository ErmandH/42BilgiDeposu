using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ecole42Entity.Migrations
{
    public partial class last : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Answer",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AdminID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletionStatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answer", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Answer_Admin_AdminID",
                        column: x => x.AdminID,
                        principalSchema: "dbo",
                        principalTable: "Admin",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Answer_User_UserID",
                        column: x => x.UserID,
                        principalSchema: "dbo",
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Question",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AdminID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletionStatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Question", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Question_Admin_AdminID",
                        column: x => x.AdminID,
                        principalSchema: "dbo",
                        principalTable: "Admin",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Question_User_UserID",
                        column: x => x.UserID,
                        principalSchema: "dbo",
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnswerQuestion",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AnswerID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    QuestionID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletionStatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnswerQuestion", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AnswerQuestion_Answer_AnswerID",
                        column: x => x.AnswerID,
                        principalSchema: "dbo",
                        principalTable: "Answer",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AnswerQuestion_Question_QuestionID",
                        column: x => x.QuestionID,
                        principalSchema: "dbo",
                        principalTable: "Question",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Answer_AdminID",
                schema: "dbo",
                table: "Answer",
                column: "AdminID");

            migrationBuilder.CreateIndex(
                name: "IX_Answer_UserID",
                schema: "dbo",
                table: "Answer",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_AnswerQuestion_AnswerID",
                schema: "dbo",
                table: "AnswerQuestion",
                column: "AnswerID");

            migrationBuilder.CreateIndex(
                name: "IX_AnswerQuestion_QuestionID",
                schema: "dbo",
                table: "AnswerQuestion",
                column: "QuestionID");

            migrationBuilder.CreateIndex(
                name: "IX_Question_AdminID",
                schema: "dbo",
                table: "Question",
                column: "AdminID");

            migrationBuilder.CreateIndex(
                name: "IX_Question_UserID",
                schema: "dbo",
                table: "Question",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnswerQuestion",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Answer",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Question",
                schema: "dbo");
        }
    }
}
