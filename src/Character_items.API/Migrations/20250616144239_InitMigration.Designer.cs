﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using pazio_test2.API.DAL;

#nullable disable

namespace pazio_test2.API.Migrations
{
    [DbContext(typeof(CharactersDbContext))]
    [Migration("20250616144239_InitMigration")]
    partial class InitMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Character_items.API.Models.Backpack", b =>
                {
                    b.Property<int>("CharacterId")
                        .HasColumnType("int");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.HasKey("CharacterId", "ItemId");

                    b.HasIndex("ItemId");

                    b.ToTable("Backpack");
                });

            modelBuilder.Entity("Character_items.API.Models.Character", b =>
                {
                    b.Property<int>("CharacterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CharacterId"));

                    b.Property<int>("CurrentWeight")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MaxWeight")
                        .HasColumnType("int");

                    b.HasKey("CharacterId");

                    b.ToTable("Character");
                });

            modelBuilder.Entity("Character_items.API.Models.CharacterTitle", b =>
                {
                    b.Property<int>("TitleId")
                        .HasColumnType("int");

                    b.Property<int>("CharacterId")
                        .HasColumnType("int");

                    b.Property<DateTime>("AcquiredAt")
                        .HasColumnType("datetime2");

                    b.HasKey("TitleId", "CharacterId");

                    b.HasIndex("CharacterId");

                    b.ToTable("CharacterTitle");
                });

            modelBuilder.Entity("Character_items.API.Models.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Weight")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Item");
                });

            modelBuilder.Entity("Character_items.API.Models.Title", b =>
                {
                    b.Property<int>("TitleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TitleId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TitleId");

                    b.ToTable("Title");
                });

            modelBuilder.Entity("Character_items.API.Models.Backpack", b =>
                {
                    b.HasOne("Character_items.API.Models.Character", "Character")
                        .WithMany("Backpacks")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Character_items.API.Models.Item", "Item")
                        .WithMany("Backpacks")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Character");

                    b.Navigation("Item");
                });

            modelBuilder.Entity("Character_items.API.Models.CharacterTitle", b =>
                {
                    b.HasOne("Character_items.API.Models.Character", "Character")
                        .WithMany("CharacterTitles")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Character_items.API.Models.Title", "Title")
                        .WithMany("CharacterTitles")
                        .HasForeignKey("TitleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Character");

                    b.Navigation("Title");
                });

            modelBuilder.Entity("Character_items.API.Models.Character", b =>
                {
                    b.Navigation("Backpacks");

                    b.Navigation("CharacterTitles");
                });

            modelBuilder.Entity("Character_items.API.Models.Item", b =>
                {
                    b.Navigation("Backpacks");
                });

            modelBuilder.Entity("Character_items.API.Models.Title", b =>
                {
                    b.Navigation("CharacterTitles");
                });
#pragma warning restore 612, 618
        }
    }
}
