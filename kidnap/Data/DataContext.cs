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

        public DbSet<AddressEntity> address { get; set; }
        public DbSet<AttendanceEntity> attendance { get; set; }
        public DbSet<AutorizationEntity> autorization { get; set; }
        public DbSet<ChildrensEntity> childrens { get; set; }
        public DbSet<GroupEntity> groups { get; set; }
        public DbSet<GroupTypesEntity> grouptypes { get; set; }
        public DbSet<MedcomissionsEntity> medcomissions { get; set;}
        public DbSet<MedstatusEntity> medstatus { get; set; }
        public DbSet<ParentsEntity> parents { get; set; }
        public DbSet<PersonEntity> persons { get; set; }
        public DbSet<ReasonsEntity> reasons { get; set; }
        public DbSet<RoleEntity> roles { get; set; }
        public DbSet<SexEntity> sex { get; set; }
        
    }
}
