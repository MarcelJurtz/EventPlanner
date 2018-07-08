using Microsoft.EntityFrameworkCore.Migrations;

namespace ClubGrid.Migrations
{
    public partial class upd_rename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "modified",
                table: "team",
                newName: "updated");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "updated",
                table: "team",
                newName: "modified");
        }
    }
}
