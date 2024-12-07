﻿// <auto-generated />
using System;
using BlazorApp.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BlazorApp.Migrations
{
    [DbContext(typeof(AgroContext))]
    [Migration("20241207115040_UpdateBlockField")]
    partial class UpdateBlockField
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BlazorApp.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("EmployeeId"));

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Role")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasDefaultValue("Gardener");

                    b.HasKey("EmployeeId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("BlazorApp.Models.EmployeeTask", b =>
                {
                    b.Property<int>("TaskId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("TaskId"));

                    b.Property<DateTime>("AssignedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("CompletedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("integer");

                    b.Property<int>("TreeId")
                        .HasColumnType("integer");

                    b.HasKey("TaskId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("TreeId");

                    b.ToTable("EmployeeTasks");
                });

            modelBuilder.Entity("BlazorApp.Models.Field", b =>
                {
                    b.Property<int>("FieldId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("FieldId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("EmployeId")
                        .HasColumnType("integer");

                    b.Property<int?>("EmployeeResponsibleEmployeeId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("FieldId");

                    b.HasIndex("EmployeeResponsibleEmployeeId");

                    b.ToTable("Fields");
                });

            modelBuilder.Entity("BlazorApp.Models.LocationHistory", b =>
                {
                    b.Property<int>("LocationHistoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("LocationHistoryId"));

                    b.Property<string>("ChangeDescription")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("TreeLocationId")
                        .HasColumnType("integer");

                    b.HasKey("LocationHistoryId");

                    b.HasIndex("TreeLocationId");

                    b.ToTable("LocationHistories");
                });

            modelBuilder.Entity("BlazorApp.Models.SectionField", b =>
                {
                    b.Property<int>("SectionFieldId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("SectionFieldId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("EmployeId")
                        .HasColumnType("integer");

                    b.Property<int?>("EmployeeResponsibleEmployeeId")
                        .HasColumnType("integer");

                    b.Property<int>("FieldId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("SectionFieldId");

                    b.HasIndex("EmployeeResponsibleEmployeeId");

                    b.HasIndex("FieldId");

                    b.ToTable("SectionFields");
                });

            modelBuilder.Entity("BlazorApp.Models.Tree", b =>
                {
                    b.Property<int>("TreeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("TreeId"));

                    b.Property<DateTime>("PlantedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Species")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("TreeLocationId")
                        .HasColumnType("integer");

                    b.Property<string>("TreeStatus")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("TreeId");

                    b.ToTable("Trees");
                });

            modelBuilder.Entity("BlazorApp.Models.TreeBlock", b =>
                {
                    b.Property<int>("BlockId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("BlockId"));

                    b.Property<int?>("FieldId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("SectionFieldId")
                        .HasColumnType("integer");

                    b.HasKey("BlockId");

                    b.HasIndex("FieldId");

                    b.HasIndex("SectionFieldId");

                    b.ToTable("TreeBlocks");
                });

            modelBuilder.Entity("BlazorApp.Models.TreeHistory", b =>
                {
                    b.Property<int>("TreeHistoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("TreeHistoryId"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("TreeId")
                        .HasColumnType("integer");

                    b.HasKey("TreeHistoryId");

                    b.HasIndex("TreeId");

                    b.ToTable("TreeHistories");
                });

            modelBuilder.Entity("BlazorApp.Models.TreeLocation", b =>
                {
                    b.Property<int>("TreeLocationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    b.Property<int>("BlockId")
                        .HasColumnType("integer");

                    b.Property<string>("ColId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("RowId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("TreeLocationId");

                    b.HasIndex("BlockId");

                    b.ToTable("TreeLocations");
                });

            modelBuilder.Entity("BlazorApp.Models.EmployeeTask", b =>
                {
                    b.HasOne("BlazorApp.Models.Employee", "Employee")
                        .WithMany("Tasks")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.HasOne("BlazorApp.Models.Tree", "Tree")
                        .WithMany()
                        .HasForeignKey("TreeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Tree");
                });

            modelBuilder.Entity("BlazorApp.Models.Field", b =>
                {
                    b.HasOne("BlazorApp.Models.Employee", "EmployeeResponsible")
                        .WithMany()
                        .HasForeignKey("EmployeeResponsibleEmployeeId");

                    b.Navigation("EmployeeResponsible");
                });

            modelBuilder.Entity("BlazorApp.Models.LocationHistory", b =>
                {
                    b.HasOne("BlazorApp.Models.TreeLocation", "TreeLocation")
                        .WithMany("History")
                        .HasForeignKey("TreeLocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TreeLocation");
                });

            modelBuilder.Entity("BlazorApp.Models.SectionField", b =>
                {
                    b.HasOne("BlazorApp.Models.Employee", "EmployeeResponsible")
                        .WithMany()
                        .HasForeignKey("EmployeeResponsibleEmployeeId");

                    b.HasOne("BlazorApp.Models.Field", "Field")
                        .WithMany("SectionFields")
                        .HasForeignKey("FieldId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EmployeeResponsible");

                    b.Navigation("Field");
                });

            modelBuilder.Entity("BlazorApp.Models.TreeBlock", b =>
                {
                    b.HasOne("BlazorApp.Models.Field", null)
                        .WithMany("Blocks")
                        .HasForeignKey("FieldId");

                    b.HasOne("BlazorApp.Models.SectionField", "SectionField")
                        .WithMany("TreeBlocks")
                        .HasForeignKey("SectionFieldId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SectionField");
                });

            modelBuilder.Entity("BlazorApp.Models.TreeHistory", b =>
                {
                    b.HasOne("BlazorApp.Models.Tree", "Tree")
                        .WithMany("History")
                        .HasForeignKey("TreeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tree");
                });

            modelBuilder.Entity("BlazorApp.Models.TreeLocation", b =>
                {
                    b.HasOne("BlazorApp.Models.TreeBlock", "Block")
                        .WithMany("TreeLocations")
                        .HasForeignKey("BlockId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BlazorApp.Models.Tree", "Tree")
                        .WithOne("TreeLocation")
                        .HasForeignKey("BlazorApp.Models.TreeLocation", "TreeLocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Block");

                    b.Navigation("Tree");
                });

            modelBuilder.Entity("BlazorApp.Models.Employee", b =>
                {
                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("BlazorApp.Models.Field", b =>
                {
                    b.Navigation("Blocks");

                    b.Navigation("SectionFields");
                });

            modelBuilder.Entity("BlazorApp.Models.SectionField", b =>
                {
                    b.Navigation("TreeBlocks");
                });

            modelBuilder.Entity("BlazorApp.Models.Tree", b =>
                {
                    b.Navigation("History");

                    b.Navigation("TreeLocation");
                });

            modelBuilder.Entity("BlazorApp.Models.TreeBlock", b =>
                {
                    b.Navigation("TreeLocations");
                });

            modelBuilder.Entity("BlazorApp.Models.TreeLocation", b =>
                {
                    b.Navigation("History");
                });
#pragma warning restore 612, 618
        }
    }
}
