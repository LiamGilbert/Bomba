using System.ComponentModel.DataAnnotations;

namespace kidnap.Models
{
    public class SexEntity
    {
        [Key]
        public int Id_sex { get; set; }
        public string Sex { get; set; }
    }
}
