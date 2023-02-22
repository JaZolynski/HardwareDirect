using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HardwareDirect.Entities
{
    public class ExerciseDbContext : DbContext
    {
        private string _connectionString = "Server=(LocalDB)\\MSSQLLocalDB;Database=HardwareDirectExercise;Trusted_Connection=true;";
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeTask> EmplooyeesTasks { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<StatusTask> TaskStatuses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(25);

            modelBuilder.Entity<EmployeeTask>()
                .Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(25);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
