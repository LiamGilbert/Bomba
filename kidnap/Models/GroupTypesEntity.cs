using System.ComponentModel.DataAnnotations;

namespace kidnap.Models
{
    public class GroupTypesEntity
    {
        [Key]
        public int id_type { get; set; }
        public string type { get; set; } = String.Empty;
    }
}
