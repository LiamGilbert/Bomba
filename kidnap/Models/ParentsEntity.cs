using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kidnap.Models
{
    public class ParentsEntity
    {
        [Key]
        public int id_parent {  get; set; }
        public string mother { get; set; }
        public string father { get; set; }
        public int id_children { get; set; }


        [ForeignKey("id_children")]
        public PersonEntity children { get; set; }
    }
}
