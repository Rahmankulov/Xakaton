using BlazorApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
namespace BlazorApp.Database
{   
    public class AgroContext : DbContext
    {
        public DbSet<Tree> Trees { get; set; }
        public DbSet<TreeLocation> TreeLocations { get; set; }
        public DbSet<TreeBlock> TreeBlocks { get; set; }
        public DbSet<Field> Fields { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeTask> EmployeeTasks { get; set; }
        public DbSet<TreeHistory> TreeHistories { get; set; }
        public DbSet<LocationHistory> LocationHistories { get; set; }
        public DbSet<SectionField> SectionFields { get; set; }

        string connectionStr = "";

        public AgroContext(string _connection)
        {
            connectionStr = _connection;
        }


        public AgroContext(DbContextOptions<AgroContext> options) : base(options) { }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(connectionStr);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Связь Tree и TreeLocation (один-ко-многим)
            modelBuilder.Entity<Tree>().HasKey(p => p.TreeId);
            modelBuilder.Entity<TreeBlock>().HasKey(p => p.BlockId);
            modelBuilder.Entity<TreeLocation>().HasKey(p => p.TreeLocationId);
            modelBuilder.Entity<TreeHistory>().HasKey(p => p.TreeHistoryId);
            modelBuilder.Entity<Field>().HasKey(p => p.FieldId);
            modelBuilder.Entity<Employee>().HasKey(p => p.EmployeeId);
            modelBuilder.Entity<EmployeeTask>().HasKey(p => p.TaskId);
            modelBuilder.Entity<LocationHistory>().HasKey(p => p.LocationHistoryId);

            modelBuilder.Entity<Tree>()
        .Property(t => t.TreeId)
        .ValueGeneratedOnAdd();

            modelBuilder.Entity<TreeBlock>()
                .Property(tb => tb.BlockId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<TreeLocation>()
                .Property(tl => tl.TreeLocationId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<TreeHistory>()
                .Property(th => th.TreeHistoryId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Field>()
                .Property(f => f.FieldId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Employee>()
                .Property(e => e.EmployeeId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<EmployeeTask>()
                .Property(t => t.TaskId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<LocationHistory>()
                .Property(lh => lh.LocationHistoryId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Tree>()
                .HasOne(t => t.TreeLocation)
                .WithOne(p => p.Tree).HasForeignKey<TreeLocation>(tl => tl.TreeLocationId);


            modelBuilder.Entity<Tree>().HasMany(p => p.History).WithOne(p => p.Tree).HasForeignKey(p => p.TreeId);

            // Связь TreeLocation и TreeBlock (один-ко-многим)
            modelBuilder.Entity<TreeLocation>()
                .HasOne(l => l.Block)
                .WithMany(b => b.TreeLocations)
                .HasForeignKey(l => l.BlockId)
                .OnDelete(DeleteBehavior.Cascade);

           

            // Настройка TreeBlock

            modelBuilder.Entity<TreeBlock>()
                .HasOne(tb => tb.SectionField)
                .WithMany(sf => sf.TreeBlocks)
                .HasForeignKey(tb => tb.SectionFieldId);


            // Связь Task и Tree (один-ко-многим)
            modelBuilder.Entity<EmployeeTask>()
                .HasOne(t => t.Tree)
                .WithMany()
                .HasForeignKey(t => t.TreeId)
                .OnDelete(DeleteBehavior.Restrict);

            // Связь Task и Employee (один-ко-многим)
            modelBuilder.Entity<EmployeeTask>()
                .HasOne(t => t.Employee)
                .WithMany(e => e.Tasks)
                .HasForeignKey(t => t.EmployeeId)
                .OnDelete(DeleteBehavior.SetNull);

            // Связь TreeHistory и Tree (один-ко-многим)
            modelBuilder.Entity<TreeHistory>()
                .HasOne(th => th.Tree)
                .WithMany(t => t.History)
                .HasForeignKey(th => th.TreeId)
                .OnDelete(DeleteBehavior.Cascade);

            // Связь LocationHistory и TreeLocation (один-ко-многим)
            modelBuilder.Entity<LocationHistory>()
                .HasOne(lh => lh.TreeLocation)
                .WithMany(tl => tl.History)
                .HasForeignKey(lh => lh.TreeLocationId)
                .OnDelete(DeleteBehavior.Cascade);

            //// Ограничение уникальности для координат в TreeLocation
            //modelBuilder.Entity<TreeLocation>()
            //    .HasIndex(tl => new { tl.Latitude, tl.Longitude })
            //    .IsUnique();

            // Установка значения по умолчанию для Enum (Role)
            modelBuilder.Entity<Employee>()
                .Property(e => e.Role)
                .HasDefaultValue(Role.Gardener);

            // Настройка SectionField
            modelBuilder.Entity<SectionField>().HasKey(sf => sf.SectionFieldId);

            modelBuilder.Entity<SectionField>()
                .HasOne(sf => sf.Field)
                .WithMany(f => f.SectionFields)
                .HasForeignKey(sf => sf.FieldId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SectionField>()
                .HasMany(sf => sf.TreeBlocks)
                .WithOne(tb => tb.SectionField)
                .HasForeignKey(tb => tb.SectionFieldId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Role)
                .HasConversion<string>(); // Enum stored as string

            modelBuilder.Entity<Tree>()
               .Property(e => e.TreeStatus)
               .HasConversion<string>(); // Enum stored as string

            modelBuilder.Entity<TreeLocation>()
               .Property(e => e.LocationTreeStatus)
               .HasConversion<string>(); // Enum stored as string
        }




        // Роли сотрудников
        public enum Role
        {
            Director,
            ChiefAgronomist,
            Agronomist,
            Gardener
        }

        public enum StatusTree
        {
            Planted,// Посажено
            Growing,// Растёт
            FruitBearing, //Плодоносит
            Dormant, //В состоянии покоя\
            Diseased, //Болеет
            Dead, //Мёртвое
            Harvested, //Собран урожай
            Removed, // Удален

        }


        public enum LocationTreeStatus
        {
            Occupied,        // Занято деревом
            Available,     // Свободно
            Damaged,         // Повреждено
            UnderMaintenance,// На обслуживании

        }

    }
}
