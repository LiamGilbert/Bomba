using System.ComponentModel.DataAnnotations;

namespace kidnap.Models
{
    public class GroupTypesEntity
    {
        [Key]
        public int id_grouptype { get; set; }
        public string group_type { get; set; }
    }
}
