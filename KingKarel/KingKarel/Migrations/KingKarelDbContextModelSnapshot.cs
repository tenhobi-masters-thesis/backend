﻿// <auto-generated />
using KingKarel.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace KingKarel.Migrations
{
    [DbContext(typeof(KingKarelDbContext))]
    partial class KingKarelDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("KingKarel.Database.Entities.GameProgress", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Commands")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("Completed")
                        .HasColumnType("boolean");

                    b.Property<int>("GameId")
                        .HasColumnType("integer");

                    b.Property<int>("Size")
                        .HasColumnType("integer");

                    b.Property<int>("Speed")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.HasIndex("UserId");

                    b.ToTable("GameProgresses", (string)null);
                });

            modelBuilder.Entity("KingKarel.Database.Entities.Mission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Order")
                        .HasColumnType("integer");

                    b.Property<int>("StoryId")
                        .HasColumnType("integer");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("StoryId");

                    b.HasIndex("Url")
                        .IsUnique();

                    b.ToTable("Missions", (string)null);
                });

            modelBuilder.Entity("KingKarel.Database.Entities.Story", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Url")
                        .IsUnique();

                    b.ToTable("Stories", (string)null);
                });

            modelBuilder.Entity("KingKarel.Database.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("KingKarel.Database.Entities.Game", b =>
                {
                    b.HasBaseType("KingKarel.Database.Entities.Mission");

                    b.Property<string>("BoardInitial")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("BoardResult")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CommandsInitial")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("RobotInitial")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("RobotResult")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("SizeLimit")
                        .HasColumnType("integer");

                    b.Property<int>("SpeedLimit")
                        .HasColumnType("integer");

                    b.ToTable("Game", (string)null);
                });

            modelBuilder.Entity("KingKarel.Database.Entities.Learning", b =>
                {
                    b.HasBaseType("KingKarel.Database.Entities.Mission");

                    b.Property<string>("Data")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsStory")
                        .HasColumnType("boolean");

                    b.ToTable("Learning", (string)null);
                });

            modelBuilder.Entity("KingKarel.Database.Entities.GameProgress", b =>
                {
                    b.HasOne("KingKarel.Database.Entities.Game", "Game")
                        .WithMany()
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KingKarel.Database.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");

                    b.Navigation("User");
                });

            modelBuilder.Entity("KingKarel.Database.Entities.Mission", b =>
                {
                    b.HasOne("KingKarel.Database.Entities.Story", "Story")
                        .WithMany("Missions")
                        .HasForeignKey("StoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Story");
                });

            modelBuilder.Entity("KingKarel.Database.Entities.Game", b =>
                {
                    b.HasOne("KingKarel.Database.Entities.Mission", null)
                        .WithOne()
                        .HasForeignKey("KingKarel.Database.Entities.Game", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("KingKarel.Database.Entities.Learning", b =>
                {
                    b.HasOne("KingKarel.Database.Entities.Mission", null)
                        .WithOne()
                        .HasForeignKey("KingKarel.Database.Entities.Learning", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("KingKarel.Database.Entities.Story", b =>
                {
                    b.Navigation("Missions");
                });
#pragma warning restore 612, 618
        }
    }
}
