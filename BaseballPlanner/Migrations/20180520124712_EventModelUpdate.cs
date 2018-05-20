using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Planner.Migrations
{
    public partial class EventModelUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CoachesRequired",
                table: "Events",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PlayersRequired",
                table: "Events",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ScorersRequired",
                table: "Events",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SeatsRequired",
                table: "Events",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UmpiresRequired",
                table: "Events",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CoachesRequired",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "PlayersRequired",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "ScorersRequired",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "SeatsRequired",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "UmpiresRequired",
                table: "Events");
        }
    }
}
