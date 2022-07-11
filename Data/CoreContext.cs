using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class CoreContext : DbContext
    {
        public CoreContext(DbContextOptions<CoreContext> options)
            : base(options) 
        {
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>(p =>
            {
                p.HasKey(e => e.Id);
            });

            modelBuilder.Entity<Departament>(p =>
            {
                p.HasKey(e => e.Id);
                p.HasOne(e => e.Company).WithMany(e => e.Departments).HasForeignKey(e => e.CompanyId);
                p.HasMany(e => e.Divisions).WithMany(e => e.Departaments);
            });

            modelBuilder.Entity<Division>(p =>
            {
                p.HasKey(e => e.Id);
                p.HasMany(e => e.Departaments).WithMany(e => e.Divisions);
            });
        }

        public DbSet<Departament> Departaments { get; set; }
        public DbSet<Division> Divisions { get; set; }
        public DbSet<Company> Companies { get; set; }
    }
}
