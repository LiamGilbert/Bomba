using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kidnap.Models
{
    public class ChildrensEntity
    {
        [Key]
        public int id_children { get; set; }
        public int id_person {  get; set; }
        public int id_group {  get; set; }


        [ForeignKey("id_person")]
        public PersonEntity person { get; set; }

        [ForeignKey("id_group")]
        public GroupEntity group { get; set; }
    }
}
