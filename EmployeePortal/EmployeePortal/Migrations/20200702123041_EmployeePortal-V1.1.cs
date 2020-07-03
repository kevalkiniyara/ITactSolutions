using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeePortal.Migrations
{
    public partial class EmployeePortalV11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DepartmentModels",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DepartmentName = table.Column<string>(nullable: true),
                    DepartmentAddress = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentModels", x => x.DepartmentId);
                });

            migrationBuilder.CreateTable(
                name: "HumanResourceModels",
                columns: table => new
                {
                    HrId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    HrName = table.Column<string>(nullable: true),
                    HrAddress = table.Column<string>(nullable: true),
                    DepartmentId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HumanResourceModels", x => x.HrId);
                    table.ForeignKey(
                        name: "FK_HumanResourceModels_DepartmentModels_DepartmentId1",
                        column: x => x.DepartmentId1,
                        principalTable: "DepartmentModels",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HumanResourceModels_DepartmentId1",
                table: "HumanResourceModels",
                column: "DepartmentId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HumanResourceModels");

            migrationBuilder.DropTable(
                name: "DepartmentModels");
        }
    }
}
