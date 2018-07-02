using Microsoft.EntityFrameworkCore.Migrations;

namespace ClubGrid.Migrations
{
    public partial class Upd_TeamAssociation_TableName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TeamAssociations",
                table: "TeamAssociations");

            migrationBuilder.RenameTable(
                name: "TeamAssociations",
                newName: "team_association");

            migrationBuilder.RenameIndex(
                name: "IX_TeamAssociations_user_id_team_id_role",
                table: "team_association",
                newName: "IX_team_association_user_id_team_id_role");

            migrationBuilder.AddPrimaryKey(
                name: "PK_team_association",
                table: "team_association",
                column: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_team_association",
                table: "team_association");

            migrationBuilder.RenameTable(
                name: "team_association",
                newName: "TeamAssociations");

            migrationBuilder.RenameIndex(
                name: "IX_team_association_user_id_team_id_role",
                table: "TeamAssociations",
                newName: "IX_TeamAssociations_user_id_team_id_role");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeamAssociations",
                table: "TeamAssociations",
                column: "id");
        }
    }
}
