using Microsoft.EntityFrameworkCore.Migrations;

namespace RepositoryLayer.Migrations
{
    public partial class label2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LabelTable",
                columns: table => new
                {
                    LabelId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LabelName = table.Column<string>(nullable: true),
                    UserID = table.Column<long>(nullable: false),
                    NoteID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabelTable", x => x.LabelId);
                    table.ForeignKey(
                        name: "FK_LabelTable_NoteTable_NoteID",
                        column: x => x.NoteID,
                        principalTable: "NoteTable",
                        principalColumn: "NoteId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_LabelTable_UserTable_UserID",
                        column: x => x.UserID,
                        principalTable: "UserTable",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LabelTable_NoteID",
                table: "LabelTable",
                column: "NoteID");

            migrationBuilder.CreateIndex(
                name: "IX_LabelTable_UserID",
                table: "LabelTable",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LabelTable");
        }
    }
}
