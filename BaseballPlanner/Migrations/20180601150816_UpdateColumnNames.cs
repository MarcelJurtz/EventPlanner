using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Planner.Migrations
{
    public partial class UpdateColumnNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventAssociations_Events_EventId",
                table: "EventAssociations");

            migrationBuilder.DropForeignKey(
                name: "FK_EventAssociations_Teams_TeamId",
                table: "EventAssociations");

            migrationBuilder.DropForeignKey(
                name: "FK_EventParticipations_Events_EventId",
                table: "EventParticipations");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamAssociations_Teams_TeamId",
                table: "TeamAssociations");

            migrationBuilder.DropIndex(
                name: "IX_TeamAssociations_TeamId",
                table: "TeamAssociations");

            migrationBuilder.DropIndex(
                name: "IX_EventParticipations_EventId",
                table: "EventParticipations");

            migrationBuilder.DropIndex(
                name: "IX_EventAssociations_EventId",
                table: "EventAssociations");

            migrationBuilder.RenameColumn(
                name: "Modified",
                table: "Teams",
                newName: "modified");

            migrationBuilder.RenameColumn(
                name: "Designation",
                table: "Teams",
                newName: "designation");

            migrationBuilder.RenameColumn(
                name: "Created",
                table: "Teams",
                newName: "created");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Teams",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_Teams_Designation",
                table: "Teams",
                newName: "IX_Teams_designation");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "TeamAssociations",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "TeamId",
                table: "TeamAssociations",
                newName: "team_id");

            migrationBuilder.RenameColumn(
                name: "Role",
                table: "TeamAssociations",
                newName: "role");

            migrationBuilder.RenameColumn(
                name: "Modified",
                table: "TeamAssociations",
                newName: "modified");

            migrationBuilder.RenameColumn(
                name: "Created",
                table: "TeamAssociations",
                newName: "created");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "TeamAssociations",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_TeamAssociations_UserId_TeamId_Role",
                table: "TeamAssociations",
                newName: "IX_TeamAssociations_user_id_team_id_role");

            migrationBuilder.RenameColumn(
                name: "UmpiresRequired",
                table: "Events",
                newName: "umpires_required");

            migrationBuilder.RenameColumn(
                name: "Start",
                table: "Events",
                newName: "start");

            migrationBuilder.RenameColumn(
                name: "SeatsRequired",
                table: "Events",
                newName: "seats_required");

            migrationBuilder.RenameColumn(
                name: "ScorersRequired",
                table: "Events",
                newName: "scorers_required");

            migrationBuilder.RenameColumn(
                name: "PlayersRequired",
                table: "Events",
                newName: "players_required");

            migrationBuilder.RenameColumn(
                name: "Modified",
                table: "Events",
                newName: "modified");

            migrationBuilder.RenameColumn(
                name: "MeetingTime",
                table: "Events",
                newName: "meeting_time");

            migrationBuilder.RenameColumn(
                name: "MeetingLocation",
                table: "Events",
                newName: "meeting_location");

            migrationBuilder.RenameColumn(
                name: "Location",
                table: "Events",
                newName: "location");

            migrationBuilder.RenameColumn(
                name: "End",
                table: "Events",
                newName: "end");

            migrationBuilder.RenameColumn(
                name: "Designation",
                table: "Events",
                newName: "designation");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Events",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Created",
                table: "Events",
                newName: "created");

            migrationBuilder.RenameColumn(
                name: "CoachesRequired",
                table: "Events",
                newName: "coaches_required");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Events",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "EventParticipations",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "Seats",
                table: "EventParticipations",
                newName: "seats");

            migrationBuilder.RenameColumn(
                name: "Note",
                table: "EventParticipations",
                newName: "note");

            migrationBuilder.RenameColumn(
                name: "Modified",
                table: "EventParticipations",
                newName: "modified");

            migrationBuilder.RenameColumn(
                name: "IsUmpire",
                table: "EventParticipations",
                newName: "is_umpire");

            migrationBuilder.RenameColumn(
                name: "IsScorer",
                table: "EventParticipations",
                newName: "is_scorer");

            migrationBuilder.RenameColumn(
                name: "IsPlayer",
                table: "EventParticipations",
                newName: "is_player");

            migrationBuilder.RenameColumn(
                name: "IsCoach",
                table: "EventParticipations",
                newName: "is_coach");

            migrationBuilder.RenameColumn(
                name: "EventId",
                table: "EventParticipations",
                newName: "event_id");

            migrationBuilder.RenameColumn(
                name: "Created",
                table: "EventParticipations",
                newName: "created");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "EventParticipations",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "TeamId",
                table: "EventAssociations",
                newName: "team_id");

            migrationBuilder.RenameColumn(
                name: "Modified",
                table: "EventAssociations",
                newName: "modified");

            migrationBuilder.RenameColumn(
                name: "EventId",
                table: "EventAssociations",
                newName: "event_id");

            migrationBuilder.RenameColumn(
                name: "Created",
                table: "EventAssociations",
                newName: "created");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "EventAssociations",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_EventAssociations_TeamId_EventId",
                table: "EventAssociations",
                newName: "IX_EventAssociations_team_id_event_id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "AspNetUsers",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "Registered",
                table: "AspNetUsers",
                newName: "registered");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "modified",
                table: "Teams",
                newName: "Modified");

            migrationBuilder.RenameColumn(
                name: "designation",
                table: "Teams",
                newName: "Designation");

            migrationBuilder.RenameColumn(
                name: "created",
                table: "Teams",
                newName: "Created");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Teams",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Teams_designation",
                table: "Teams",
                newName: "IX_Teams_Designation");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "TeamAssociations",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "team_id",
                table: "TeamAssociations",
                newName: "TeamId");

            migrationBuilder.RenameColumn(
                name: "role",
                table: "TeamAssociations",
                newName: "Role");

            migrationBuilder.RenameColumn(
                name: "modified",
                table: "TeamAssociations",
                newName: "Modified");

            migrationBuilder.RenameColumn(
                name: "created",
                table: "TeamAssociations",
                newName: "Created");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "TeamAssociations",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_TeamAssociations_user_id_team_id_role",
                table: "TeamAssociations",
                newName: "IX_TeamAssociations_UserId_TeamId_Role");

            migrationBuilder.RenameColumn(
                name: "umpires_required",
                table: "Events",
                newName: "UmpiresRequired");

            migrationBuilder.RenameColumn(
                name: "start",
                table: "Events",
                newName: "Start");

            migrationBuilder.RenameColumn(
                name: "seats_required",
                table: "Events",
                newName: "SeatsRequired");

            migrationBuilder.RenameColumn(
                name: "scorers_required",
                table: "Events",
                newName: "ScorersRequired");

            migrationBuilder.RenameColumn(
                name: "players_required",
                table: "Events",
                newName: "PlayersRequired");

            migrationBuilder.RenameColumn(
                name: "modified",
                table: "Events",
                newName: "Modified");

            migrationBuilder.RenameColumn(
                name: "meeting_time",
                table: "Events",
                newName: "MeetingTime");

            migrationBuilder.RenameColumn(
                name: "meeting_location",
                table: "Events",
                newName: "MeetingLocation");

            migrationBuilder.RenameColumn(
                name: "location",
                table: "Events",
                newName: "Location");

            migrationBuilder.RenameColumn(
                name: "end",
                table: "Events",
                newName: "End");

            migrationBuilder.RenameColumn(
                name: "designation",
                table: "Events",
                newName: "Designation");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Events",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "created",
                table: "Events",
                newName: "Created");

            migrationBuilder.RenameColumn(
                name: "coaches_required",
                table: "Events",
                newName: "CoachesRequired");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Events",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "EventParticipations",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "seats",
                table: "EventParticipations",
                newName: "Seats");

            migrationBuilder.RenameColumn(
                name: "note",
                table: "EventParticipations",
                newName: "Note");

            migrationBuilder.RenameColumn(
                name: "modified",
                table: "EventParticipations",
                newName: "Modified");

            migrationBuilder.RenameColumn(
                name: "is_umpire",
                table: "EventParticipations",
                newName: "IsUmpire");

            migrationBuilder.RenameColumn(
                name: "is_scorer",
                table: "EventParticipations",
                newName: "IsScorer");

            migrationBuilder.RenameColumn(
                name: "is_player",
                table: "EventParticipations",
                newName: "IsPlayer");

            migrationBuilder.RenameColumn(
                name: "is_coach",
                table: "EventParticipations",
                newName: "IsCoach");

            migrationBuilder.RenameColumn(
                name: "event_id",
                table: "EventParticipations",
                newName: "EventId");

            migrationBuilder.RenameColumn(
                name: "created",
                table: "EventParticipations",
                newName: "Created");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "EventParticipations",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "team_id",
                table: "EventAssociations",
                newName: "TeamId");

            migrationBuilder.RenameColumn(
                name: "modified",
                table: "EventAssociations",
                newName: "Modified");

            migrationBuilder.RenameColumn(
                name: "event_id",
                table: "EventAssociations",
                newName: "EventId");

            migrationBuilder.RenameColumn(
                name: "created",
                table: "EventAssociations",
                newName: "Created");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "EventAssociations",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_EventAssociations_team_id_event_id",
                table: "EventAssociations",
                newName: "IX_EventAssociations_TeamId_EventId");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "AspNetUsers",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "registered",
                table: "AspNetUsers",
                newName: "Registered");

            migrationBuilder.CreateIndex(
                name: "IX_TeamAssociations_TeamId",
                table: "TeamAssociations",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_EventParticipations_EventId",
                table: "EventParticipations",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventAssociations_EventId",
                table: "EventAssociations",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_EventAssociations_Events_EventId",
                table: "EventAssociations",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventAssociations_Teams_TeamId",
                table: "EventAssociations",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventParticipations_Events_EventId",
                table: "EventParticipations",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamAssociations_Teams_TeamId",
                table: "TeamAssociations",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
