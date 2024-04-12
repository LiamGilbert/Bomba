namespace kidnap.DTO.Attendance
{
    public class CreateAttendanceDTO
    {
        public int id_child { get; set; }
        public DateTime date { get; set; }
        public string mark { get; set; }
        public int id_reason { get; set; }
    }
}
