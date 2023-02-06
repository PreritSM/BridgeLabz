using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RepositoryLayer.Migrations
{
    public partial class Initial3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                table: "NoteTable");

            migrationBuilder.RenameColumn(
                name: "NoteID",
                table: "NoteTable",
                newName: "NoteId");

            migrationBuilder.AddColumn<string>(
                name: "Colour",
                table: "NoteTable",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "NoteTable",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "NoteTable",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsArchived",
                table: "NoteTable",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPinned",
                table: "NoteTable",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsTrash",
                table: "NoteTable",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "NoteTable",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "NoteTable",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_NoteTable_UserId",
                table: "NoteTable",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_NoteTable_UserTable_UserId",
                table: "NoteTable",
                column: "UserId",
                principalTable: "UserTable",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NoteTable_UserTable_UserId",
                table: "NoteTable");

            migrationBuilder.DropIndex(
                name: "IX_NoteTable_UserId",
                table: "NoteTable");

            migrationBuilder.DropColumn(
                name: "Colour",
                table: "NoteTable");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "NoteTable");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "NoteTable");

            migrationBuilder.DropColumn(
                name: "IsArchived",
                table: "NoteTable");

            migrationBuilder.DropColumn(
                name: "IsPinned",
                table: "NoteTable");

            migrationBuilder.DropColumn(
                name: "IsTrash",
                table: "NoteTable");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "NoteTable");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "NoteTable");

            migrationBuilder.RenameColumn(
                name: "NoteId",
                table: "NoteTable",
                newName: "NoteID");

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "NoteTable",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
