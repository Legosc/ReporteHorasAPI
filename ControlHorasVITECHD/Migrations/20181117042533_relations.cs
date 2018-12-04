using Microsoft.EntityFrameworkCore.Migrations;

namespace ControlHorasVITECHD.Migrations
{
    public partial class relations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_IdentityUser_UsersId",
                table: "Tasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdentityUser",
                table: "IdentityUser");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "IdentityUser");

            migrationBuilder.RenameTable(
                name: "IdentityUser",
                newName: "Users");

            migrationBuilder.RenameColumn(
                name: "UsersId",
                table: "Tasks",
                newName: "IdUser");

            migrationBuilder.RenameIndex(
                name: "IX_Tasks_UsersId",
                table: "Tasks",
                newName: "IX_Tasks_IdUser");

            migrationBuilder.AddColumn<string>(
                name: "IdUser",
                table: "Hours",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Hours_IdUser",
                table: "Hours",
                column: "IdUser");

            migrationBuilder.AddForeignKey(
                name: "FK_Hours_Users_IdUser",
                table: "Hours",
                column: "IdUser",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Users_IdUser",
                table: "Tasks",
                column: "IdUser",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hours_Users_IdUser",
                table: "Hours");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Users_IdUser",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Hours_IdUser",
                table: "Hours");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IdUser",
                table: "Hours");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "IdentityUser");

            migrationBuilder.RenameColumn(
                name: "IdUser",
                table: "Tasks",
                newName: "UsersId");

            migrationBuilder.RenameIndex(
                name: "IX_Tasks_IdUser",
                table: "Tasks",
                newName: "IX_Tasks_UsersId");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "IdentityUser",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdentityUser",
                table: "IdentityUser",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_IdentityUser_UsersId",
                table: "Tasks",
                column: "UsersId",
                principalTable: "IdentityUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
