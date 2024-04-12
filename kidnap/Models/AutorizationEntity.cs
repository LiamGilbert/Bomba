using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kidnap.Models
{
    public class AutorizationEntity
    {
        [Key]
        public int id_autorization { get; set; }
        public int id_person { get; set; }
        public string login { get; set; }
        public string password {  get; set; }


        [ForeignKey("id_person")]
        public PersonEntity person { get; set; }
    }
}
