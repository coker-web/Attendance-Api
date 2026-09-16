namespace AttendanceManagementSystem.Dtos
{
    public class ResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string RegistrationNumber { get; set; } = string.Empty;
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
