namespace kidnap.DTO.Persons
{
    public class UpdatePersonDTO
    {
        public int id_person { get; set; }
        public string lastname { get; set; }
        public string firstname { get; set; }
        public string? patronymic { get; set; }
        public bool sex { get; set; }
        public int id_address { get; set; }
        public int id_role { get; set; }
    }
}
