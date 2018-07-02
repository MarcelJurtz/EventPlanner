using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ClubGrid.Migrations
{
    public partial class EventParticipationAnswers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "answer_no",
                table: "EventParticipations",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "answer_yes",
                table: "EventParticipations",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "answer_no",
                table: "EventParticipations");

            migrationBuilder.DropColumn(
                name: "answer_yes",
                table: "EventParticipations");
        }
    }
}
