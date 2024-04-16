using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kidnap.Models
{
    public class AttendanceEntity
    {
        [Key]
        public int id_attendance { get; set; }
        public int id_child { get; set; }
        public DateTime date { get; set; }
        public string mark { get; set; } = String.Empty;
        public int? id_reason {  get; set; }


        [ForeignKey("id_child")]
        public ChildrensEntity? children { get; set; }

        [ForeignKey("id_reason")]
        public ReasonsEntity? reason { get; set; }
    }
}
