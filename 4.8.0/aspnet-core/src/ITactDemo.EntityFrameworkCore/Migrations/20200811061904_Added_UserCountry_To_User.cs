using Microsoft.EntityFrameworkCore.Migrations;

namespace ITactDemo.Migrations
{
    public partial class Added_UserCountry_To_User : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserAge",
                table: "AbpUsers");

            migrationBuilder.RenameColumn(
                name: "UserGender",
                table: "AbpUsers",
                newName: "UserCountry");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserCountry",
                table: "AbpUsers",
                newName: "UserGender");

            migrationBuilder.AddColumn<int>(
                name: "UserAge",
                table: "AbpUsers",
                nullable: false,
                defaultValue: 0);
        }
    }
}
