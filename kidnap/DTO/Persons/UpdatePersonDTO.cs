namespace kidnap.DTO.Persons
{
    public class UpdatePersonDTO
    {
        public int id_person { get; set; }
        public int id_sex { get; set; }
        public string lastname { get; set; }
        public string name { get; set; }
        public string patronymic { get; set; }
        public DateTime birth_date { get; set; }
        public int id_address { get; set; }

        public int id_role { get; set; }
    }
}
