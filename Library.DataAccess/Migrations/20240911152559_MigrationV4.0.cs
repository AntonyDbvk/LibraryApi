using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class MigrationV40 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookInstance_Books_BookId",
                table: "BookInstance");

            migrationBuilder.DropForeignKey(
                name: "FK_BookInstance_User_UserId",
                table: "BookInstance");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookInstance",
                table: "BookInstance");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "BookInstance",
                newName: "BookInstances");

            migrationBuilder.RenameIndex(
                name: "IX_BookInstance_UserId",
                table: "BookInstances",
                newName: "IX_BookInstances_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_BookInstance_BookId",
                table: "BookInstances",
                newName: "IX_BookInstances_BookId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookInstances",
                table: "BookInstances",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BookInstances_Books_BookId",
                table: "BookInstances",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookInstances_Users_UserId",
                table: "BookInstances",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookInstances_Books_BookId",
                table: "BookInstances");

            migrationBuilder.DropForeignKey(
                name: "FK_BookInstances_Users_UserId",
                table: "BookInstances");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookInstances",
                table: "BookInstances");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "BookInstances",
                newName: "BookInstance");

            migrationBuilder.RenameIndex(
                name: "IX_BookInstances_UserId",
                table: "BookInstance",
                newName: "IX_BookInstance_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_BookInstances_BookId",
                table: "BookInstance",
                newName: "IX_BookInstance_BookId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookInstance",
                table: "BookInstance",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BookInstance_Books_BookId",
                table: "BookInstance",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookInstance_User_UserId",
                table: "BookInstance",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
