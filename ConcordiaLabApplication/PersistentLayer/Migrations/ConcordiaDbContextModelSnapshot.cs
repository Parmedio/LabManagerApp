﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PersistentLayer.Configurations;

#nullable disable

namespace PersistentLayer.Migrations
{
    [DbContext(typeof(ConcordiaDbContext))]
    partial class ConcordiaDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

            modelBuilder.Entity("PersistentLayer.Models.Column", b =>
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

                    b.ToTable("Column");

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
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("LabelId")
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

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Title = "Medium",
                            TrelloId = "647609751afdaf2b05536cd9"
                        },
                        new
                        {
                            Id = 2,
                            Title = "Low",
                            TrelloId = "647609751afdaf2b05536cd7"
                        },
                        new
                        {
                            Id = 3,
                            Title = "High",
                            TrelloId = "647609751afdaf2b05536cdf"
                        },
                        new
                        {
                            Id = 4,
                            Title = "Medium",
                            TrelloId = "647608041afdaf2b0545a16c"
                        },
                        new
                        {
                            Id = 5,
                            Title = "High",
                            TrelloId = "647608041afdaf2b0545a16b"
                        },
                        new
                        {
                            Id = 6,
                            Title = "Low",
                            TrelloId = "647608041afdaf2b0545a160"
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

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Alessandro Ferluga",
                            TrelloMemberId = "5bf9f901921c336b20b29d25",
                            TrelloToken = "ATTA5c0a0bf47c1be3f495ebb81c42316684ff55e1134be71c0eba2cbecdd0614558CDCC81F8"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Marco de Piave",
                            TrelloMemberId = "639c692ed850f6055714fd55",
                            TrelloToken = "ATTAd93cf67ec0072d821ff32e199156a675ed9301feea0f899df160829b3f14082dAB1E41AD"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Gabriele Ceccutti",
                            TrelloMemberId = "6474f28f0d4924c1eaff2824",
                            TrelloToken = "ATTA408bebeedb9948e62a1e38c11691049bc07e9329984c3897908a0127279faa4956E9CC86"
                        });
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
                        .HasForeignKey("LabelId");

                    b.HasOne("PersistentLayer.Models.Column", "List")
                        .WithMany("Experiments")
                        .HasForeignKey("ListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Label");

                    b.Navigation("List");
                });

            modelBuilder.Entity("PersistentLayer.Models.Column", b =>
                {
                    b.Navigation("Experiments");
                });

            modelBuilder.Entity("PersistentLayer.Models.Experiment", b =>
                {
                    b.Navigation("Comments");
                });
#pragma warning restore 612, 618
        }
    }
}
