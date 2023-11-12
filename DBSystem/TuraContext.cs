using DBEntities.Entities.Drivers;
using DBEntities.Entities.Planner;
using DBEntities.Entities.Tours;
using DBEntities.Entities.Users;
using DBEntities.Entities.Vehicles;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DBSystem
{
    public class TuraContext : DbContext
    {
        public DbSet<Drivers> Drivers { get; set; }
        public DbSet<Planner> Planners { get; set; }
        public DbSet<Tours> Tours { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure your entities here (e.g., primary keys, relationships)
            modelBuilder.Entity<Drivers>()
            .HasKey(d => new { d.DriverID, d.DriverCompanyID });

            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql(@"Host=localhost;Username=postgres;Password=dem$2012;Database=transport");
    }
}
