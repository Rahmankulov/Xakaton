using BlazorApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace BlazorApp.Database
{
    public class DbXContext:DbContext
    {
        string connectionStr = "";
        public DbXContext(string _connection)
        {
            connectionStr = _connection;
        }

        DbSet<Items> Items { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(connectionStr);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Items>().HasKey(p=>p.Id);
        }
    }
}
