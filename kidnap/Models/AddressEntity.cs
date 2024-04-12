using System.ComponentModel.DataAnnotations;

namespace kidnap.Models
{
    public class AddressEntity
    {
        [Key]
        public int id_address { get; set; }
        public string town { get; set; }
        public string street { get; set; }
        public string house_number { get; set; }
    }
}
