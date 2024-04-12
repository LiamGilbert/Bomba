using System.ComponentModel.DataAnnotations;

namespace kidnap.Models
{
    public class MedstatusEntity
    {
        [Key]
        public int id_medstatus {  get; set; }
        public string status_name { get; set; }
    }
}
