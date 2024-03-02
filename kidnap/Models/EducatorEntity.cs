using System.ComponentModel.DataAnnotations;

namespace kidnap.Models
{
    public class EducatorEntity
    {
        [Key]
        public int Id_educator {  get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public int Sex { get; set; }
        public SexEntity SexEntity { get; set; }

    }
}
