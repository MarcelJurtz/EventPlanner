using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using System;

namespace ClubGrid.Migrations
{
    public partial class ModelsUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Users_CreatedById",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_Users_ModifiedById",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamAffiliations_TeamRoles_RoleId",
                table: "TeamAffiliations");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamAffiliations_Teams_TeamId",
                table: "TeamAffiliations");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamAffiliations_Users_UserId",
                table: "TeamAffiliations");

            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Events_EventId",
                table: "Teams");

            migrationBuilder.DropTable(
                name: "EventRoles");

            migrationBuilder.DropTable(
                name: "TeamRoles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Teams_EventId",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Events_CreatedById",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_ModifiedById",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_TeamAffiliations_RoleId",
                table: "TeamAffiliations");

            migrationBuilder.DropIndex(
                name: "IX_TeamAffiliations_UserId",
                table: "TeamAffiliations");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "ModifiedById",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "TeamAffiliations");

            migrationBuilder.AlterColumn<string>(
                name: "Designation",
                table: "Teams",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Teams",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Modified",
                table: "Teams",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "MeetingLocation",
                table: "Events",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "Events",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "End",
                table: "Events",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<string>(
                name: "Designation",
                table: "Events",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Events",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "TeamAffiliations",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TeamId",
                table: "TeamAffiliations",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "TeamAffiliations",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Modified",
                table: "TeamAffiliations",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "TeamAffiliations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "EventAssociations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Created = table.Column<DateTime>(nullable: false),
                    EventId = table.Column<int>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    TeamId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventAssociations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventAssociations_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventAssociations_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventParticipations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Created = table.Column<DateTime>(nullable: false),
                    EventId = table.Column<int>(nullable: false),
                    IsCoach = table.Column<bool>(nullable: false),
                    IsPlayer = table.Column<bool>(nullable: false),
                    IsScorer = table.Column<bool>(nullable: false),
                    IsUmpire = table.Column<bool>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Note = table.Column<string>(maxLength: 100, nullable: true),
                    Seats = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventParticipations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventParticipations_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Teams_Designation",
                table: "Teams",
                column: "Designation",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TeamAffiliations_UserId_TeamId_Role",
                table: "TeamAffiliations",
                columns: new[] { "UserId", "TeamId", "Role" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EventAssociations_EventId",
                table: "EventAssociations",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventAssociations_TeamId_EventId",
                table: "EventAssociations",
                columns: new[] { "TeamId", "EventId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EventParticipations_EventId",
                table: "EventParticipations",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_TeamAffiliations_Teams_TeamId",
                table: "TeamAffiliations",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeamAffiliations_Teams_TeamId",
                table: "TeamAffiliations");

            migrationBuilder.DropTable(
                name: "EventAssociations");

            migrationBuilder.DropTable(
                name: "EventParticipations");

            migrationBuilder.DropIndex(
                name: "IX_Teams_Designation",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_TeamAffiliations_UserId_TeamId_Role",
                table: "TeamAffiliations");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "Modified",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "TeamAffiliations");

            migrationBuilder.DropColumn(
                name: "Modified",
                table: "TeamAffiliations");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "TeamAffiliations");

            migrationBuilder.AlterColumn<string>(
                name: "Designation",
                table: "Teams",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EventId",
                table: "Teams",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MeetingLocation",
                table: "Events",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "Events",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "End",
                table: "Events",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Designation",
                table: "Events",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Events",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "Events",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModifiedById",
                table: "Events",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "TeamAffiliations",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "TeamId",
                table: "TeamAffiliations",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "TeamAffiliations",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "EventRoles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Designation = table.Column<string>(nullable: true),
                    QuantityRequired = table.Column<int>(nullable: true),
                    SubDesignation = table.Column<string>(nullable: true),
                    SubQuantityRequired = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TeamRoles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Designation = table.Column<string>(maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Discriminator = table.Column<string>(nullable: false),
                    EMail = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Teams_EventId",
                table: "Teams",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_CreatedById",
                table: "Events",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Events_ModifiedById",
                table: "Events",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_TeamAffiliations_RoleId",
                table: "TeamAffiliations",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamAffiliations_UserId",
                table: "TeamAffiliations",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Users_CreatedById",
                table: "Events",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Users_ModifiedById",
                table: "Events",
                column: "ModifiedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamAffiliations_TeamRoles_RoleId",
                table: "TeamAffiliations",
                column: "RoleId",
                principalTable: "TeamRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamAffiliations_Teams_TeamId",
                table: "TeamAffiliations",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamAffiliations_Users_UserId",
                table: "TeamAffiliations",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Events_EventId",
                table: "Teams",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
