using System.Security.Principal;

namespace Attendance
{
    public class AttendanceList
    {
        List<Attendance> _attendance = new List<Attendance>();

        public int NextId { get; set; } = 1;

        public Attendance GetById(int id)
        {
            var attendance = _attendance.FirstOrDefault(x => x.Id == id);
            if (attendance == null)
            {
                return null!;
            }
            return attendance;
        }
        public List<Attendance> GetAllAttendance()
        {
            return _attendance.ToList();
           
        }
        public Attendance CreateAttendance(Attendance attends)
        {
            attends.Id = NextId++;
           _attendance.Add(attends);
            return attends;
        }
        public Attendance UpdateAttendance(Attendance attends, int id)
        {
            var attendance = _attendance.FirstOrDefault(x => x.Id == id);
            if (attendance == null)
            {
                return null!;
            }
            attendance.Name = attends.Name;
            attendance.RegistrationNumber = attends.RegistrationNumber;
            attendance.Date = attends.Date;

            return attendance;
        }
        public bool Remove(int id)
        {
            var attendance = _attendance.FirstOrDefault(x => x.Id == id);
            if (attendance == null)
            {
                return false;
            }
            _attendance.Remove(attendance);
            return true;

        }
    }
}
