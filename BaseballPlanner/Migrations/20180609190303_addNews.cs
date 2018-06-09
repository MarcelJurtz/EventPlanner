using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Planner.Migrations
{
    public partial class addNews : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Teams",
                table: "Teams");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Events",
                table: "Events");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventParticipations",
                table: "EventParticipations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventAssociations",
                table: "EventAssociations");

            migrationBuilder.RenameTable(
                name: "Teams",
                newName: "team");

            migrationBuilder.RenameTable(
                name: "Events",
                newName: "event");

            migrationBuilder.RenameTable(
                name: "EventParticipations",
                newName: "event_participation");

            migrationBuilder.RenameTable(
                name: "EventAssociations",
                newName: "event_association");

            migrationBuilder.RenameIndex(
                name: "IX_Teams_designation",
                table: "team",
                newName: "IX_team_designation");

            migrationBuilder.RenameIndex(
                name: "IX_EventAssociations_team_id_event_id",
                table: "event_association",
                newName: "IX_event_association_team_id_event_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_team",
                table: "team",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_event",
                table: "event",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_event_participation",
                table: "event_participation",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_event_association",
                table: "event_association",
                column: "id");

            migrationBuilder.CreateTable(
                name: "news",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    content = table.Column<string>(nullable: true),
                    created = table.Column<DateTime>(nullable: false),
                    modified = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_news", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "news");

            migrationBuilder.DropPrimaryKey(
                name: "PK_team",
                table: "team");

            migrationBuilder.DropPrimaryKey(
                name: "PK_event_participation",
                table: "event_participation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_event_association",
                table: "event_association");

            migrationBuilder.DropPrimaryKey(
                name: "PK_event",
                table: "event");

            migrationBuilder.RenameTable(
                name: "team",
                newName: "Teams");

            migrationBuilder.RenameTable(
                name: "event_participation",
                newName: "EventParticipations");

            migrationBuilder.RenameTable(
                name: "event_association",
                newName: "EventAssociations");

            migrationBuilder.RenameTable(
                name: "event",
                newName: "Events");

            migrationBuilder.RenameIndex(
                name: "IX_team_designation",
                table: "Teams",
                newName: "IX_Teams_designation");

            migrationBuilder.RenameIndex(
                name: "IX_event_association_team_id_event_id",
                table: "EventAssociations",
                newName: "IX_EventAssociations_team_id_event_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Teams",
                table: "Teams",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventParticipations",
                table: "EventParticipations",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventAssociations",
                table: "EventAssociations",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Events",
                table: "Events",
                column: "id");
        }
    }
}
