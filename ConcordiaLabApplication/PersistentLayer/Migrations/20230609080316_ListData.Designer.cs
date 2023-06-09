﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PersistentLayer.Configurations;

#nullable disable

namespace PersistentLayer.Migrations
{
    [DbContext(typeof(ConcordiaDbContext))]
    [Migration("20230609080316_ListData")]
    partial class ListData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ExperimentScientist", b =>
                {
                    b.Property<int>("ExperimentsId")
                        .HasColumnType("int");

                    b.Property<int>("ScientistsId")
                        .HasColumnType("int");

                    b.HasKey("ExperimentsId", "ScientistsId");

                    b.HasIndex("ScientistsId");

                    b.ToTable("ExperimentScientist");
                });

            modelBuilder.Entity("PersistentLayer.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("ExperimentId")
                        .HasColumnType("int");

                    b.Property<int?>("ScientistId")
                        .HasColumnType("int");

                    b.Property<string>("TrelloId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("ExperimentId");

                    b.HasIndex("ScientistId");

                    b.HasIndex("TrelloId")
                        .IsUnique()
                        .HasFilter("[TrelloId] IS NOT NULL");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("PersistentLayer.Models.Experiment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DeadLine")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LabelId")
                        .HasColumnType("int");

                    b.Property<int>("ListId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TrelloId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LabelId");

                    b.HasIndex("ListId");

                    b.ToTable("Experiments");
                });

            modelBuilder.Entity("PersistentLayer.Models.Label", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TrelloId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Labels");
                });

            modelBuilder.Entity("PersistentLayer.Models.ListEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TrelloId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("EntityLists");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Title = "to do",
                            TrelloId = "64760804e47275c707e05d38"
                        },
                        new
                        {
                            Id = 2,
                            Title = "in progress",
                            TrelloId = "64760804e47275c707e05d39"
                        },
                        new
                        {
                            Id = 3,
                            Title = "completed",
                            TrelloId = "64760804e47275c707e05d3a"
                        });
                });

            modelBuilder.Entity("PersistentLayer.Models.Scientist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TrelloMemberId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TrelloToken")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Scientists");
                });

            modelBuilder.Entity("ExperimentScientist", b =>
                {
                    b.HasOne("PersistentLayer.Models.Experiment", null)
                        .WithMany()
                        .HasForeignKey("ExperimentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PersistentLayer.Models.Scientist", null)
                        .WithMany()
                        .HasForeignKey("ScientistsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PersistentLayer.Models.Comment", b =>
                {
                    b.HasOne("PersistentLayer.Models.Experiment", "Experiment")
                        .WithMany("Comments")
                        .HasForeignKey("ExperimentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PersistentLayer.Models.Scientist", "Scientist")
                        .WithMany()
                        .HasForeignKey("ScientistId");

                    b.Navigation("Experiment");

                    b.Navigation("Scientist");
                });

            modelBuilder.Entity("PersistentLayer.Models.Experiment", b =>
                {
                    b.HasOne("PersistentLayer.Models.Label", "Label")
                        .WithMany()
                        .HasForeignKey("LabelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PersistentLayer.Models.ListEntity", "List")
                        .WithMany("Experiments")
                        .HasForeignKey("ListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Label");

                    b.Navigation("List");
                });

            modelBuilder.Entity("PersistentLayer.Models.Experiment", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("PersistentLayer.Models.ListEntity", b =>
                {
                    b.Navigation("Experiments");
                });
#pragma warning restore 612, 618
        }
    }
}
