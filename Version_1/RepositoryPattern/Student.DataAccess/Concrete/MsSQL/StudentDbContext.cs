using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Student.Entity.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.DataAccess.Concrete.MsSQL
{
    public class StudentDbContext : DbContext
    {
        //public StudentDbContext(DbContextOptions<DbContext> options) : base(options) { }

        private string _connectionStrings;

        public StudentDbContext(string connectionStrings)
        {
            _connectionStrings = connectionStrings;
        }

        public DbSet<Entity.Student.Student> Students { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Family> Families { get; set; }
        public DbSet<GuardianType> GuardianTypes { get; set; }
        public DbSet<Guardian> Guardians { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(this._connectionStrings);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Family>()
                .HasIndex(x=>x.Code)
                .IsUnique();

        }
    }
}
