using System.ComponentModel.DataAnnotations;

namespace kidnap.Models
{
    public class ReasonsEntity
    {
        [Key]
        public int id_reason {  get; set; }
        public string reason { get; set; }
    }
}
