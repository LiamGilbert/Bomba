using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kidnap.Models
{
    public class GroupEntity
    {
        [Key]
        public int id_group { get; set; }
        public string group_name { get; set; }
        public int id_type { get; set; }
        public int id_person { get; set; }


        [ForeignKey("id_person")]
        public PersonEntity person { get; set; }

        [ForeignKey("id_type")]
        public GroupTypesEntity type { get; set; }
    }
}
