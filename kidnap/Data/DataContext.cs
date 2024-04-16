using kidnap.Models;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace kidnap.Data
{
    public class DataContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("Database = kids; Data Source = 127.0.0.1; User Id = root; Password = pwd");
        }

        public DbSet<AddressEntity> address { get; set; } = null!;
        public DbSet<AttendanceEntity> attendance { get; set; } = null!;
        public DbSet<AuthorizationEntity> authorization { get; set; } = null!;
        public DbSet<ChildrensEntity> childrens { get; set; } = null!;
        public DbSet<GroupEntity> groups { get; set; } = null!;
        public DbSet<GroupTypesEntity> group_types { get; set; } = null!;
        public DbSet<ParentsEntity> parents { get; set; } = null!;
        public DbSet<PersonEntity> persons { get; set; } = null!;
        public DbSet<ReasonsEntity> reasons { get; set; } = null!;
        public DbSet<RoleEntity> roles { get; set; } = null!;

    }
}
