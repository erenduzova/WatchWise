﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WatchWise.Data;

#nullable disable

namespace WatchWise.Migrations
{
    [DbContext(typeof(WatchWiseContext))]
    [Migration("20240327120105_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.17")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<long>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("RoleId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<long>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<long>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<long>", b =>
                {
                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<long>("RoleId")
                        .HasColumnType("bigint");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<long>", b =>
                {
                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("WatchWise.Models.CrossTables.MediaRestriction", b =>
                {
                    b.Property<int>("MediaId")
                        .HasColumnType("int");

                    b.Property<byte>("RestrictionId")
                        .HasColumnType("tinyint");

                    b.HasKey("MediaId", "RestrictionId");

                    b.HasIndex("RestrictionId");

                    b.ToTable("MediaRestrictions");
                });

            modelBuilder.Entity("WatchWise.Models.CrossTables.UserFavorite", b =>
                {
                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<int>("MediaId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "MediaId");

                    b.HasIndex("MediaId");

                    b.ToTable("UserFavorites");
                });

            modelBuilder.Entity("WatchWise.Models.CrossTables.UserPlan", b =>
                {
                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<short>("PlanId")
                        .HasColumnType("smallint");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("date");

                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("date");

                    b.HasKey("UserId", "PlanId");

                    b.HasIndex("PlanId");

                    b.ToTable("UserPlans");
                });

            modelBuilder.Entity("WatchWise.Models.CrossTables.UserWatchedEpisode", b =>
                {
                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<long>("EpisodeId")
                        .HasColumnType("bigint");

                    b.HasKey("UserId", "EpisodeId");

                    b.HasIndex("EpisodeId");

                    b.ToTable("UserWatchedEpisodes");
                });

            modelBuilder.Entity("WatchWise.Models.Director", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Directors");
                });

            modelBuilder.Entity("WatchWise.Models.Episode", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<TimeSpan>("Duration")
                        .HasColumnType("time");

                    b.Property<short>("EpisodeNum")
                        .HasColumnType("smallint");

                    b.Property<int>("MediaId")
                        .HasColumnType("int");

                    b.Property<bool>("Passive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.Property<byte>("SeasonNum")
                        .HasColumnType("tinyint");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("ViewCount")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("MediaId");

                    b.ToTable("Episodes");
                });

            modelBuilder.Entity("WatchWise.Models.Genre", b =>
                {
                    b.Property<short>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<short>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("WatchWise.Models.Media", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<float>("ImdbRating")
                        .HasColumnType("real");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<bool>("Passive")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Medias");
                });

            modelBuilder.Entity("WatchWise.Models.MediaDirector", b =>
                {
                    b.Property<int>("MediaId")
                        .HasColumnType("int");

                    b.Property<int>("DirectorId")
                        .HasColumnType("int");

                    b.HasKey("MediaId", "DirectorId");

                    b.HasIndex("DirectorId");

                    b.ToTable("MediaDirectors");
                });

            modelBuilder.Entity("WatchWise.Models.MediaGenre", b =>
                {
                    b.Property<int>("MediaId")
                        .HasColumnType("int");

                    b.Property<short>("GenreId")
                        .HasColumnType("smallint");

                    b.HasKey("MediaId", "GenreId");

                    b.HasIndex("GenreId");

                    b.ToTable("MediaGenres");
                });

            modelBuilder.Entity("WatchWise.Models.MediaStar", b =>
                {
                    b.Property<int>("MediaId")
                        .HasColumnType("int");

                    b.Property<int>("StarId")
                        .HasColumnType("int");

                    b.HasKey("MediaId", "StarId");

                    b.HasIndex("StarId");

                    b.ToTable("MediaStars");
                });

            modelBuilder.Entity("WatchWise.Models.Plan", b =>
                {
                    b.Property<short>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<short>("Id"));

                    b.Property<string>("MaxResolution")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Plans");
                });

            modelBuilder.Entity("WatchWise.Models.Restriction", b =>
                {
                    b.Property<byte>("Id")
                        .HasColumnType("tinyint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Restrictions");
                });

            modelBuilder.Entity("WatchWise.Models.Star", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Stars");
                });

            modelBuilder.Entity("WatchWise.Models.WatchWiseRole", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("WatchWise.Models.WatchWiseUser", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("date");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("Passive")
                        .HasColumnType("bit");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<long>", b =>
                {
                    b.HasOne("WatchWise.Models.WatchWiseRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<long>", b =>
                {
                    b.HasOne("WatchWise.Models.WatchWiseUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<long>", b =>
                {
                    b.HasOne("WatchWise.Models.WatchWiseUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<long>", b =>
                {
                    b.HasOne("WatchWise.Models.WatchWiseRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WatchWise.Models.WatchWiseUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<long>", b =>
                {
                    b.HasOne("WatchWise.Models.WatchWiseUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WatchWise.Models.CrossTables.MediaRestriction", b =>
                {
                    b.HasOne("WatchWise.Models.Media", "Media")
                        .WithMany("MediaRestrictions")
                        .HasForeignKey("MediaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WatchWise.Models.Restriction", "Restriction")
                        .WithMany("MediaRestrictions")
                        .HasForeignKey("RestrictionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Media");

                    b.Navigation("Restriction");
                });

            modelBuilder.Entity("WatchWise.Models.CrossTables.UserFavorite", b =>
                {
                    b.HasOne("WatchWise.Models.Media", "Media")
                        .WithMany("UserFavorites")
                        .HasForeignKey("MediaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WatchWise.Models.WatchWiseUser", "WatchWiseUser")
                        .WithMany("UserFavorites")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Media");

                    b.Navigation("WatchWiseUser");
                });

            modelBuilder.Entity("WatchWise.Models.CrossTables.UserPlan", b =>
                {
                    b.HasOne("WatchWise.Models.Plan", "Plan")
                        .WithMany("UserPlans")
                        .HasForeignKey("PlanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WatchWise.Models.WatchWiseUser", "WatchWiseUser")
                        .WithMany("UserPlans")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Plan");

                    b.Navigation("WatchWiseUser");
                });

            modelBuilder.Entity("WatchWise.Models.CrossTables.UserWatchedEpisode", b =>
                {
                    b.HasOne("WatchWise.Models.Episode", "Episode")
                        .WithMany("UserWatchedEpisodes")
                        .HasForeignKey("EpisodeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WatchWise.Models.WatchWiseUser", "WatchWiseUser")
                        .WithMany("UserWatchedEpisodes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Episode");

                    b.Navigation("WatchWiseUser");
                });

            modelBuilder.Entity("WatchWise.Models.Episode", b =>
                {
                    b.HasOne("WatchWise.Models.Media", "Media")
                        .WithMany()
                        .HasForeignKey("MediaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Media");
                });

            modelBuilder.Entity("WatchWise.Models.MediaDirector", b =>
                {
                    b.HasOne("WatchWise.Models.Director", "Director")
                        .WithMany("MediaDirectors")
                        .HasForeignKey("DirectorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WatchWise.Models.Media", "Media")
                        .WithMany("MediaDirectors")
                        .HasForeignKey("MediaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Director");

                    b.Navigation("Media");
                });

            modelBuilder.Entity("WatchWise.Models.MediaGenre", b =>
                {
                    b.HasOne("WatchWise.Models.Genre", "Genre")
                        .WithMany("MediaGenres")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WatchWise.Models.Media", "Media")
                        .WithMany("MediaGenres")
                        .HasForeignKey("MediaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genre");

                    b.Navigation("Media");
                });

            modelBuilder.Entity("WatchWise.Models.MediaStar", b =>
                {
                    b.HasOne("WatchWise.Models.Media", "Media")
                        .WithMany("MediaStars")
                        .HasForeignKey("MediaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WatchWise.Models.Star", "Star")
                        .WithMany("MediaStars")
                        .HasForeignKey("StarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Media");

                    b.Navigation("Star");
                });

            modelBuilder.Entity("WatchWise.Models.Director", b =>
                {
                    b.Navigation("MediaDirectors");
                });

            modelBuilder.Entity("WatchWise.Models.Episode", b =>
                {
                    b.Navigation("UserWatchedEpisodes");
                });

            modelBuilder.Entity("WatchWise.Models.Genre", b =>
                {
                    b.Navigation("MediaGenres");
                });

            modelBuilder.Entity("WatchWise.Models.Media", b =>
                {
                    b.Navigation("MediaDirectors");

                    b.Navigation("MediaGenres");

                    b.Navigation("MediaRestrictions");

                    b.Navigation("MediaStars");

                    b.Navigation("UserFavorites");
                });

            modelBuilder.Entity("WatchWise.Models.Plan", b =>
                {
                    b.Navigation("UserPlans");
                });

            modelBuilder.Entity("WatchWise.Models.Restriction", b =>
                {
                    b.Navigation("MediaRestrictions");
                });

            modelBuilder.Entity("WatchWise.Models.Star", b =>
                {
                    b.Navigation("MediaStars");
                });

            modelBuilder.Entity("WatchWise.Models.WatchWiseUser", b =>
                {
                    b.Navigation("UserFavorites");

                    b.Navigation("UserPlans");

                    b.Navigation("UserWatchedEpisodes");
                });
#pragma warning restore 612, 618
        }
    }
}
