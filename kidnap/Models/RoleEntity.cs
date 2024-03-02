using System.ComponentModel.DataAnnotations;

namespace kidnap.Models
{
    public class RoleEntity
    {
        [Key]
        public int Id_role { get; set; }
        public string Role { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
