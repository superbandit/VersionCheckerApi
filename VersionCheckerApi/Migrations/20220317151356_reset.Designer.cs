﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VersionCheckerApi.Persistence;

#nullable disable

namespace VersionCheckerApi.Migrations
{
    [DbContext(typeof(ProjectContext))]
    [Migration("20220317151356_reset")]
    partial class reset
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("VersionCheckerApi.Persistence.Module", b =>
                {
                    b.Property<int>("ModuleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ModuleId"), 1L, 1);

                    b.Property<int>("BiggestDiscrepancyLevel")
                        .HasColumnType("int");

                    b.Property<int?>("HighestVulnerabilitySeverity")
                        .HasColumnType("int");

                    b.Property<string>("ImportantTag")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ModuleType")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.HasKey("ModuleId");

                    b.HasIndex("ProjectId");

                    b.ToTable("Modules");
                });

            modelBuilder.Entity("VersionCheckerApi.Persistence.Package", b =>
                {
                    b.Property<string>("PackageId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("DiscrepancyLevel")
                        .HasColumnType("int");

                    b.Property<string>("ImportantTag")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LatestVersion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ModuleId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tags")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Version")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("VulnerabilitySeverity")
                        .HasColumnType("int");

                    b.Property<string>("VulnerabilityUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PackageId");

                    b.HasIndex("ModuleId");

                    b.ToTable("Packages");
                });

            modelBuilder.Entity("VersionCheckerApi.Persistence.Project", b =>
                {
                    b.Property<int>("ProjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProjectId"), 1L, 1);

                    b.Property<int>("BiggestDiscrepancyLevel")
                        .HasColumnType("int");

                    b.Property<string>("Branch")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("HighestVulnerabilitySeverity")
                        .HasColumnType("int");

                    b.Property<string>("ImportantTag")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RepositoryId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ProjectId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("VersionCheckerApi.Persistence.Module", b =>
                {
                    b.HasOne("VersionCheckerApi.Persistence.Project", null)
                        .WithMany("Modules")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("VersionCheckerApi.Persistence.Package", b =>
                {
                    b.HasOne("VersionCheckerApi.Persistence.Module", null)
                        .WithMany("Packages")
                        .HasForeignKey("ModuleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("VersionCheckerApi.Persistence.Module", b =>
                {
                    b.Navigation("Packages");
                });

            modelBuilder.Entity("VersionCheckerApi.Persistence.Project", b =>
                {
                    b.Navigation("Modules");
                });
#pragma warning restore 612, 618
        }
    }
}
