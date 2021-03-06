﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Ombi.Store.Context;
using Ombi.Store.Entities;
using Ombi.Helpers;

namespace Ombi.Store.Migrations
{
    [DbContext(typeof(OmbiContext))]
    [Migration("20170801143617_Inital")]
    partial class Inital
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2");

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole", b =>
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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Ombi.Store.Entities.ApplicationConfiguration", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Type");

                    b.Property<string>("Value");

                    b.HasKey("Id");

                    b.ToTable("ApplicationConfiguration");
                });

            modelBuilder.Entity("Ombi.Store.Entities.Audit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AuditArea");

                    b.Property<int>("AuditType");

                    b.Property<DateTime>("DateTime");

                    b.Property<string>("Description");

                    b.Property<string>("User");

                    b.HasKey("Id");

                    b.ToTable("Audit");
                });

            modelBuilder.Entity("Ombi.Store.Entities.GlobalSettings", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content");

                    b.Property<string>("SettingsName");

                    b.HasKey("Id");

                    b.ToTable("GlobalSettings");
                });

            modelBuilder.Entity("Ombi.Store.Entities.NotificationTemplates", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Agent");

                    b.Property<bool>("Enabled");

                    b.Property<string>("Message");

                    b.Property<int>("NotificationType");

                    b.Property<string>("Subject");

                    b.HasKey("Id");

                    b.ToTable("NotificationTemplates");
                });

            modelBuilder.Entity("Ombi.Store.Entities.OmbiUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("Alias");

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

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.Property<int>("UserType");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Ombi.Store.Entities.PlexContent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("AddedAt");

                    b.Property<string>("Key");

                    b.Property<string>("ProviderId");

                    b.Property<string>("ReleaseYear");

                    b.Property<string>("Title");

                    b.Property<int>("Type");

                    b.Property<string>("Url");

                    b.HasKey("Id");

                    b.ToTable("PlexContent");
                });

            modelBuilder.Entity("Ombi.Store.Entities.PlexSeasonsContent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ParentKey");

                    b.Property<int>("PlexContentId");

                    b.Property<int>("SeasonKey");

                    b.Property<int>("SeasonNumber");

                    b.HasKey("Id");

                    b.HasIndex("PlexContentId");

                    b.ToTable("PlexSeasonsContent");
                });

            modelBuilder.Entity("Ombi.Store.Entities.RadarrCache", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("TheMovieDbId");

                    b.HasKey("Id");

                    b.ToTable("RadarrCache");
                });

            modelBuilder.Entity("Ombi.Store.Entities.Requests.ChildRequests", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Approved");

                    b.Property<bool>("Available");

                    b.Property<bool?>("Denied");

                    b.Property<string>("DeniedReason");

                    b.Property<int?>("IssueId");

                    b.Property<int>("ParentRequestId");

                    b.Property<int>("RequestType");

                    b.Property<DateTime>("RequestedDate");

                    b.Property<string>("RequestedUserId");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("ParentRequestId");

                    b.HasIndex("RequestedUserId");

                    b.ToTable("ChildRequests");
                });

            modelBuilder.Entity("Ombi.Store.Entities.Requests.MovieIssues", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<int?>("IssueId");

                    b.Property<int>("MovieId");

                    b.Property<string>("Subect");

                    b.HasKey("Id");

                    b.HasIndex("IssueId");

                    b.HasIndex("MovieId");

                    b.ToTable("MovieIssues");
                });

            modelBuilder.Entity("Ombi.Store.Entities.Requests.MovieRequests", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Approved");

                    b.Property<bool>("Available");

                    b.Property<bool?>("Denied");

                    b.Property<string>("DeniedReason");

                    b.Property<string>("ImdbId");

                    b.Property<int?>("IssueId");

                    b.Property<string>("Overview");

                    b.Property<string>("PosterPath");

                    b.Property<DateTime>("ReleaseDate");

                    b.Property<int>("RequestType");

                    b.Property<DateTime>("RequestedDate");

                    b.Property<string>("RequestedUserId");

                    b.Property<string>("Status");

                    b.Property<int>("TheMovieDbId");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("RequestedUserId");

                    b.ToTable("MovieRequests");
                });

            modelBuilder.Entity("Ombi.Store.Entities.Requests.TvIssues", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<int?>("IssueId");

                    b.Property<string>("Subect");

                    b.Property<int>("TvId");

                    b.HasKey("Id");

                    b.HasIndex("IssueId");

                    b.HasIndex("TvId");

                    b.ToTable("TvIssues");
                });

            modelBuilder.Entity("Ombi.Store.Entities.Requests.TvRequests", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ImdbId");

                    b.Property<string>("Overview");

                    b.Property<string>("PosterPath");

                    b.Property<DateTime>("ReleaseDate");

                    b.Property<int?>("RootFolder");

                    b.Property<string>("Status");

                    b.Property<string>("Title");

                    b.Property<int>("TvDbId");

                    b.HasKey("Id");

                    b.ToTable("TvRequests");
                });

            modelBuilder.Entity("Ombi.Store.Repository.Requests.EpisodeRequests", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("AirDate");

                    b.Property<bool>("Approved");

                    b.Property<bool>("Available");

                    b.Property<int>("EpisodeNumber");

                    b.Property<bool>("Requested");

                    b.Property<int>("SeasonId");

                    b.Property<string>("Title");

                    b.Property<string>("Url");

                    b.HasKey("Id");

                    b.HasIndex("SeasonId");

                    b.ToTable("EpisodeRequests");
                });

            modelBuilder.Entity("Ombi.Store.Repository.Requests.SeasonRequests", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ChildRequestId");

                    b.Property<int>("SeasonNumber");

                    b.HasKey("Id");

                    b.HasIndex("ChildRequestId");

                    b.ToTable("SeasonRequests");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Ombi.Store.Entities.OmbiUser")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Ombi.Store.Entities.OmbiUser")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Ombi.Store.Entities.OmbiUser")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Ombi.Store.Entities.PlexSeasonsContent", b =>
                {
                    b.HasOne("Ombi.Store.Entities.PlexContent")
                        .WithMany("Seasons")
                        .HasForeignKey("PlexContentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Ombi.Store.Entities.Requests.ChildRequests", b =>
                {
                    b.HasOne("Ombi.Store.Entities.Requests.TvRequests", "ParentRequest")
                        .WithMany("ChildRequests")
                        .HasForeignKey("ParentRequestId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Ombi.Store.Entities.OmbiUser", "RequestedUser")
                        .WithMany()
                        .HasForeignKey("RequestedUserId");
                });

            modelBuilder.Entity("Ombi.Store.Entities.Requests.MovieIssues", b =>
                {
                    b.HasOne("Ombi.Store.Entities.Requests.MovieRequests")
                        .WithMany("Issues")
                        .HasForeignKey("IssueId");

                    b.HasOne("Ombi.Store.Entities.Requests.MovieRequests", "Movie")
                        .WithMany()
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Ombi.Store.Entities.Requests.MovieRequests", b =>
                {
                    b.HasOne("Ombi.Store.Entities.OmbiUser", "RequestedUser")
                        .WithMany()
                        .HasForeignKey("RequestedUserId");
                });

            modelBuilder.Entity("Ombi.Store.Entities.Requests.TvIssues", b =>
                {
                    b.HasOne("Ombi.Store.Entities.Requests.ChildRequests")
                        .WithMany("Issues")
                        .HasForeignKey("IssueId");

                    b.HasOne("Ombi.Store.Entities.Requests.ChildRequests", "Child")
                        .WithMany()
                        .HasForeignKey("TvId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Ombi.Store.Repository.Requests.EpisodeRequests", b =>
                {
                    b.HasOne("Ombi.Store.Repository.Requests.SeasonRequests", "Season")
                        .WithMany("Episodes")
                        .HasForeignKey("SeasonId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Ombi.Store.Repository.Requests.SeasonRequests", b =>
                {
                    b.HasOne("Ombi.Store.Entities.Requests.ChildRequests", "ChildRequest")
                        .WithMany("SeasonRequests")
                        .HasForeignKey("ChildRequestId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
