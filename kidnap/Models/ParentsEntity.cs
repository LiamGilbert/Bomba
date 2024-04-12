using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kidnap.Models
{
    public class ParentsEntity
    {
        [Key]
        public int id_parent {  get; set; }
        public int id_mother { get; set; }
        public int id_father { get; set; }


        [ForeignKey("id_mother")]
        public PersonEntity mother { get; set; }

        [ForeignKey("id_father")]
        public PersonEntity father { get; set; }
    }
}
