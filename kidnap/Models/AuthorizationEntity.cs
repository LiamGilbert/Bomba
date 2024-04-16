using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace kidnap.Models
{
    public class AuthorizationEntity
    {
        [Key]
        public int id_autorization { get; set; }
        public string login { get; set; } = String.Empty;
        public string password { get; set; } = String.Empty;
        public int id_person { get; set; }


        [ForeignKey("id_person")]
        public PersonEntity? person { get; set; }
    }
}
