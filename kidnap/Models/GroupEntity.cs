using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kidnap.Models
{
    public class GroupEntity
    {
        [Key]
        public int id_group { get; set; }
        public string group_name { get; set; }
        public int id_educator { get; set; }
        public int id_grouptype { get; set; }


        [ForeignKey("id_educator")]
        public PersonEntity person { get; set; }

        [ForeignKey("id_grouptype")]
        public GroupTypesEntity type { get; set; }
    }
}
