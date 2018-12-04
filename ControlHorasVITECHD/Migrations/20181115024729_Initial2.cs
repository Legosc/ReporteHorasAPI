using Microsoft.EntityFrameworkCore.Migrations;

namespace ControlHorasVITECHD.Migrations
{
    public partial class Initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "NID",
                table: "Clients",
                nullable: false,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "NID",
                table: "Clients",
                nullable: false,
                oldClrType: typeof(long));
        }
    }
}
