using kidnap.Models;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace kidnap.Data
{
    public class DataContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("Database = hornykids; Data Source = 127.0.0.1; User Id = root; Password = 7367");
        }

        public DbSet<SexEntity> sex {  get; set; }
        public DbSet<EducatorEntity> educators { get; set; }
        public DbSet<RoleEntity> roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EducatorEntity>().HasOne(x => x.SexEntity).WithMany().HasForeignKey(x=>x.Sex);
            base.OnModelCreating(modelBuilder);
        }
    }
}
