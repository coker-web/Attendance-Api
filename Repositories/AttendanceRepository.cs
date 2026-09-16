using AttendanceManagementSystem.Database;
using AttendanceManagementSystem.Dtos;
using AttendanceManagementSystem.Mapper;
using AttendanceManagementSystem.Model;
using Microsoft.AspNetCore.Authentication.BearerToken;
using Microsoft.EntityFrameworkCore;
using System.Xml;
namespace AttendanceManagementSystem.Repositories
{
    public class AttendanceRepository(ApplicationDb context)
    {
        private readonly ApplicationDb _context = context;
        public Attendance GetById(int id)
        {
            var attendance = _context.Attendances.FirstOrDefault(x => x.Id == id);
            if (attendance == null)
            {
                return null!;
            }
            return attendance;
        }
        public IEnumerable<Attendance> GetAllAttendance()
        {
            var attends = _context.Attendances.ToList();
                attends.Select(s => s.ToResponse());
            return attends;
        }
        public Attendance CreateAttendance(Attendance attends)
        {
            _context.Add(attends);
            _context.SaveChanges();
            return attends;
        }
        public Attendance UpdateAttendance(UpdateDto dto, int id)
        {
            var attendance = _context.Attendances.FirstOrDefault(x => x.Id == id);
            if (attendance == null)
            {
                return null!;
            }
            dto.ToUpdate(attendance);
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
