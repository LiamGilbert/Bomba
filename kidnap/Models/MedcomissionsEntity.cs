using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kidnap.Models
{
    public class MedcomissionsEntity
    {
        [Key]
        public int id_medcomission { get; set; }
        public int id_medstatus { get; set; }
        public DateTime date { get; set; }


        [ForeignKey("id_medstatus")]
        public MedstatusEntity medstatus { get; set; }
    }
}
