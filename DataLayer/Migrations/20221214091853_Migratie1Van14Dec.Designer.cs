﻿// <auto-generated />
using System;
using DataLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataLayer.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20221214091853_Migratie1Van14Dec")]
    partial class Migratie1Van14Dec
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DataLayer.Party", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FeestCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FeestNaam")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FeestOwnerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FeestOwnerId");

                    b.ToTable("parties");
                });

            modelBuilder.Entity("DataLayer.Preference", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("FeestId")
                        .HasColumnType("int");

                    b.Property<string>("Nummer1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nummer2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nummer3")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Oorsprong1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Oorsprong2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Oorsprong3")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FeestId");

                    b.ToTable("preferences");
                });

            modelBuilder.Entity("DataLayer.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PartyId")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PartyId");

                    b.ToTable("users");
                });

            modelBuilder.Entity("DataLayer.Party", b =>
                {
                    b.HasOne("DataLayer.User", "FeestOwner")
                        .WithMany()
                        .HasForeignKey("FeestOwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FeestOwner");
                });

            modelBuilder.Entity("DataLayer.Preference", b =>
                {
                    b.HasOne("DataLayer.Party", "Feest")
                        .WithMany()
                        .HasForeignKey("FeestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Feest");
                });

            modelBuilder.Entity("DataLayer.User", b =>
                {
                    b.HasOne("DataLayer.Party", null)
                        .WithMany("FeestVisitors")
                        .HasForeignKey("PartyId");
                });

            modelBuilder.Entity("DataLayer.Party", b =>
                {
                    b.Navigation("FeestVisitors");
                });
#pragma warning restore 612, 618
        }
    }
}