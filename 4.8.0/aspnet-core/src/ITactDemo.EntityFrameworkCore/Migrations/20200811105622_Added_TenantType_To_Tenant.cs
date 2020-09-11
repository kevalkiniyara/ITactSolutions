using Microsoft.EntityFrameworkCore.Migrations;

namespace ITactDemo.Migrations
{
    public partial class Added_TenantType_To_Tenant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TenantType",
                table: "AbpTenants",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TenantType",
                table: "AbpTenants");
        }
    }
}
