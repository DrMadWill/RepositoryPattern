using Microsoft.EntityFrameworkCore;
using Student.Entity.Student;

namespace Student.DataAccess.Concrete.MsSql
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options)
        {
        }

        public DbSet<Entity.Student.Student> Students { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Family> Families { get; set; }
        public DbSet<GuardianType> GuardianTypes { get; set; }
        public DbSet<Guardian> Guardians { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Family>()
                .HasIndex(x => x.Code)
                .IsUnique();
        }
    }
}