using System.ComponentModel.DataAnnotations;

namespace kidnap.Models
{
    public class RoleEntity
    {
        [Key]
        public int id_roles { get; set; }
        public string role_name { get; set; }
    }
}
