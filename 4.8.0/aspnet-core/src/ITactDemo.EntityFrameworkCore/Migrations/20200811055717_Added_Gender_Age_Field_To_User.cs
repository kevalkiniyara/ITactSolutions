using Microsoft.EntityFrameworkCore.Migrations;

namespace ITactDemo.Migrations
{
    public partial class Added_Gender_Age_Field_To_User : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserAge",
                table: "AbpUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserGender",
                table: "AbpUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserAge",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "UserGender",
                table: "AbpUsers");
        }
    }
}
