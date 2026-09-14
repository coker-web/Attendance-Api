using AttendanceManagementSystem.Model;
using AttendanceManagementSystem.Database;
namespace AttendanceManagementSystem.AttendanceRepositories
{
    public class AttendanceRepository
    {
        private readonly ApplicationDb _context;
        public AttendanceRepository(ApplicationDb context)
        {
            _context = context;
        }
        public Attendance GetById(int id)
        {
            var attendance = _context.Attendances.FirstOrDefault(x => x.Id == id);
            if (attendance == null)
            {
                return null!;
            }
            return attendance;
        }
        public List<Attendance> GetAllAttendance()
        {
            return _context.Attendances.ToList();
        }
        public Attendance CreateAttendance(Attendance attends)
        {
            _context.Add(attends);
            _context.SaveChanges();
            return attends;
        }
        public Attendance UpdateAttendance(Attendance attends, int id)
        {
            var attendance = _context.Attendances.FirstOrDefault(x => x.Id == id);
            if (attendance == null)
            {
                return null!;
            }
            attendance.Name = attends.Name;
            attendance.RegistrationNumber = attends.RegistrationNumber;
            attendance.Date = attends.Date;
            _context.SaveChanges();
            return attendance;
        }
        public bool Remove(int id)
        {
            var attendance = _context.Attendances.FirstOrDefault(x => x.Id == id);
            if (attendance == null)
            {
                return false;
            }
            _context.Attendances.Remove(attendance);
            _context.SaveChanges();
            return true;

        }
    }
}
