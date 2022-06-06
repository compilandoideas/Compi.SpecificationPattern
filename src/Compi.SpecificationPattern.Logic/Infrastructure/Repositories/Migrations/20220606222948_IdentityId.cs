using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Compi.SpecificationPattern.Logic.Migrations
{
    public partial class IdentityId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EndtDate",
                table: "Projects",
                newName: "EndDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EndDate",
                table: "Projects",
                newName: "EndtDate");
        }
    }
}
