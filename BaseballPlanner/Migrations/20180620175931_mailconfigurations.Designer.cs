﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Planner.Models;
using System;

namespace Planner.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20180620175931_mailconfigurations")]
    partial class mailconfigurations
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026");

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Planner.Models.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<int>("CoachesRequired")
                        .HasColumnName("coaches_required");

                    b.Property<DateTime>("Created")
                        .HasColumnName("created");

                    b.Property<string>("Description")
                        .HasColumnName("description")
                        .HasMaxLength(500);

                    b.Property<string>("Designation")
                        .IsRequired()
                        .HasColumnName("designation")
                        .HasMaxLength(100);

                    b.Property<DateTime?>("End")
                        .HasColumnName("end");

                    b.Property<string>("Location")
                        .HasColumnName("location")
                        .HasMaxLength(50);

                    b.Property<string>("MeetingLocation")
                        .HasColumnName("meeting_location")
                        .HasMaxLength(100);

                    b.Property<DateTime>("MeetingTime")
                        .HasColumnName("meeting_time");

                    b.Property<DateTime>("Modified")
                        .HasColumnName("modified");

                    b.Property<int>("PlayersRequired")
                        .HasColumnName("players_required");

                    b.Property<int>("ScorersRequired")
                        .HasColumnName("scorers_required");

                    b.Property<int>("SeatsRequired")
                        .HasColumnName("seats_required");

                    b.Property<DateTime>("Start")
                        .HasColumnName("start");

                    b.Property<int>("UmpiresRequired")
                        .HasColumnName("umpires_required");

                    b.HasKey("Id");

                    b.ToTable("event");
                });

            modelBuilder.Entity("Planner.Models.EventAssociation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<DateTime>("Created")
                        .HasColumnName("created");

                    b.Property<int>("EventId")
                        .HasColumnName("event_id");

                    b.Property<DateTime>("Modified")
                        .HasColumnName("modified");

                    b.Property<int>("TeamId")
                        .HasColumnName("team_id");

                    b.HasKey("Id");

                    b.HasIndex("TeamId", "EventId")
                        .IsUnique();

                    b.ToTable("event_association");
                });

            modelBuilder.Entity("Planner.Models.EventParticipation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<bool>("AnswerNo")
                        .HasColumnName("answer_no");

                    b.Property<bool>("AnswerYes")
                        .HasColumnName("answer_yes");

                    b.Property<DateTime>("Created")
                        .HasColumnName("created");

                    b.Property<int>("EventId")
                        .HasColumnName("event_id");

                    b.Property<bool>("IsCoach")
                        .HasColumnName("is_coach");

                    b.Property<bool>("IsPlayer")
                        .HasColumnName("is_player");

                    b.Property<bool>("IsScorer")
                        .HasColumnName("is_scorer");

                    b.Property<bool>("IsUmpire")
                        .HasColumnName("is_umpire");

                    b.Property<DateTime>("Modified")
                        .HasColumnName("modified");

                    b.Property<string>("Note")
                        .HasColumnName("note")
                        .HasMaxLength(100);

                    b.Property<int>("Seats")
                        .HasColumnName("seats");

                    b.Property<int>("UserId")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.ToTable("event_participation");
                });

            modelBuilder.Entity("Planner.Models.News", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("Content")
                        .HasColumnName("content")
                        .HasMaxLength(250);

                    b.Property<DateTime>("Created")
                        .HasColumnName("created");

                    b.Property<DateTime>("Modified")
                        .HasColumnName("modified");

                    b.HasKey("Id");

                    b.ToTable("news");
                });

            modelBuilder.Entity("Planner.Models.NotificationConfiguration", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<int>("AdminId")
                        .HasColumnName("admin_id");

                    b.Property<bool>("NewUserRegistered")
                        .HasColumnName("new_user_registered");

                    b.Property<bool>("UserParticipationUpdated")
                        .HasColumnName("user_participation_updated");

                    b.HasKey("Id");

                    b.ToTable("notification_configuration");
                });

            modelBuilder.Entity("Planner.Models.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<DateTime>("Created")
                        .HasColumnName("created");

                    b.Property<string>("Designation")
                        .IsRequired()
                        .HasColumnName("designation")
                        .HasMaxLength(100);

                    b.Property<DateTime>("Modified")
                        .HasColumnName("modified");

                    b.HasKey("Id");

                    b.HasIndex("Designation")
                        .IsUnique();

                    b.ToTable("team");
                });

            modelBuilder.Entity("Planner.Models.TeamAssociation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<DateTime>("Created")
                        .HasColumnName("created");

                    b.Property<DateTime>("Modified")
                        .HasColumnName("modified");

                    b.Property<int>("Role")
                        .HasColumnName("role");

                    b.Property<int>("TeamId")
                        .HasColumnName("team_id");

                    b.Property<int>("UserId")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("UserId", "TeamId", "Role")
                        .IsUnique();

                    b.ToTable("TeamAssociations");
                });

            modelBuilder.Entity("Planner.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<DateTime>("Registered")
                        .HasColumnName("registered");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("user_id");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Planner.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Planner.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Planner.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Planner.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
