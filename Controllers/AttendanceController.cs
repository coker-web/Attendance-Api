using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace Attendance.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AttendanceController : ControllerBase
    {
        private readonly AttendanceList _attendance;
        public AttendanceController(AttendanceList attendance)
        {
            _attendance = attendance;
        }
        [HttpGet]
        public IEnumerable<Attendance> GetAll()
        {
            var attendance = _attendance.GetAllAttendance();
            return attendance;
        }
        [HttpGet("{id:int}")]
        public Attendance GetStudentById(int id)
        {
            var attendance = _attendance.GetById(id);
            if (attendance == null)
                return null!;
            return attendance;
        }
        [HttpPost]
        public Attendance Create(Attendance attends)
        {
            return _attendance.CreateAttendance(attends);
        }
        [HttpPut("{id:int}")]
        public Attendance Update(Attendance attends, int id)
        {
            var attendance = _attendance.UpdateAttendance(attends, id);
            if (attendance == null)
                return null!;
            return attendance;
        }
        [HttpDelete("{id:int}")]
        public bool Delete(int id)
        {
            if (_attendance.Remove(id) == true)

                return true!;
            return false;
        }
    }
}
