using System.ComponentModel.DataAnnotations;

namespace kidnap.Models
{
    public class AddressEntity
    {
        [Key]
        public int id_address { get; set; }
        public string town { get; set; } = String.Empty;
        public string street { get; set; } = String.Empty;
        public string house_number { get; set; } = String.Empty;
    }
}
