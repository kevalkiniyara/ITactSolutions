using Microsoft.EntityFrameworkCore.Migrations;

namespace ITactDemo.Migrations
{
    public partial class Added_Address_To_Tenant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "AbpTenants",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "AbpTenants");
        }
    }
}
