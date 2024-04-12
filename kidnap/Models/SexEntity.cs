using System.ComponentModel.DataAnnotations;

namespace kidnap.Models
{
    public class SexEntity
    {
        [Key]
        public int id_sex { get; set; }
        public string sex_name { get; set; }
    }
}
