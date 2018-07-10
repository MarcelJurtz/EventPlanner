using Microsoft.EntityFrameworkCore.Migrations;

namespace ClubGrid.Migrations
{
    public partial class add_member_count : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "user_count",
                table: "team",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "user_count",
                table: "team");
        }
    }
}
