using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kidnap.Models
{
    public class PersonEntity
    {
        [Key]
        public int id_person { get; set; }
        public int id_sex { get; set; }
        public string lastname { get; set; }
        public string name { get; set; }
        public string patronymic { get; set; }
        public DateTime birth_date { get; set; }
        public int id_address { get; set; }

        public int id_role { get; set; }

        [ForeignKey("id_role")]
        public RoleEntity role { get; set; }

        [ForeignKey("id_sex")]
        public SexEntity sex {  get; set; }

        [ForeignKey("id_address")]
        public AddressEntity address { get; set; }
    }
}
