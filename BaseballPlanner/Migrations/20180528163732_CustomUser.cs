using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Planner.Migrations
{
    public partial class CustomUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeamAffiliations_Teams_TeamId",
                table: "TeamAffiliations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeamAffiliations",
                table: "TeamAffiliations");

            migrationBuilder.RenameTable(
                name: "TeamAffiliations",
                newName: "TeamAssociations");

            migrationBuilder.RenameIndex(
                name: "IX_TeamAffiliations_UserId_TeamId_Role",
                table: "TeamAssociations",
                newName: "IX_TeamAssociations_UserId_TeamId_Role");

            migrationBuilder.RenameIndex(
                name: "IX_TeamAffiliations_TeamId",
                table: "TeamAssociations",
                newName: "IX_TeamAssociations_TeamId");

            migrationBuilder.AlterColumn<string>(
                name: "Designation",
                table: "Teams",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeamAssociations",
                table: "TeamAssociations",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TeamAssociations_Teams_TeamId",
                table: "TeamAssociations",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeamAssociations_Teams_TeamId",
                table: "TeamAssociations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeamAssociations",
                table: "TeamAssociations");

            migrationBuilder.RenameTable(
                name: "TeamAssociations",
                newName: "TeamAffiliations");

            migrationBuilder.RenameIndex(
                name: "IX_TeamAssociations_UserId_TeamId_Role",
                table: "TeamAffiliations",
                newName: "IX_TeamAffiliations_UserId_TeamId_Role");

            migrationBuilder.RenameIndex(
                name: "IX_TeamAssociations_TeamId",
                table: "TeamAffiliations",
                newName: "IX_TeamAffiliations_TeamId");

            migrationBuilder.AlterColumn<string>(
                name: "Designation",
                table: "Teams",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeamAffiliations",
                table: "TeamAffiliations",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TeamAffiliations_Teams_TeamId",
                table: "TeamAffiliations",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
