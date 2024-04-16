using System.ComponentModel.DataAnnotations;

namespace kidnap.Models
{
    public class RoleEntity
    {
        [Key]
        public int id_role { get; set; }
        public string role { get; set; }
    }
}
