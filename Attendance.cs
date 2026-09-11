namespace Attendance
{
    public class Attendance
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string RegistrationNumber { get; set; } = string.Empty;
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
