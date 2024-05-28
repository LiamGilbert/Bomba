using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kidnap.Models
{
    public class ParentsEntity
    {
        [Key]
        public int id_parent { get; set; }
        public string? mother { get; set; }
        public string? father { get; set; }
        public int id_child { get; set; }
        public string? home_telephone { get; set; }


        [ForeignKey("id_child")]
        public PersonEntity? children { get; set; }
    }
}
