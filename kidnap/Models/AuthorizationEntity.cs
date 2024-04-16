using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace kidnap.Models
{
    public class AuthorizationEntity
    {
        [Key]
        public int id_authorization { get; set; }
        public string login { get; set; }
        public string password {  get; set; }
        public int id_person { get; set; }


        [ForeignKey("id_person")]
        public PersonEntity person { get; set; }
    }
}
