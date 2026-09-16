using Microsoft.AspNetCore.Mvc;
using AttendanceManagementSystem.Model;
using AttendanceManagementSystem.Repositories;
using AttendanceManagementSystem.Dtos;
using AttendanceManagementSystem.Mapper;

namespace AttendanceManagementSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AttendanceController(AttendanceRepository attendance) : ControllerBase
    {
        private readonly AttendanceRepository _attendance = attendance;
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
        public Attendance Create([FromBody] CreateRequestDto dto)
        {
            var attendanceEntity = dto.ToEntity();
            return _attendance.CreateAttendance(attendanceEntity);
        }
        [HttpPut("{id:int}")]
        public Attendance Update(UpdateDto dto, int id)
        {
            var attendance = _attendance.UpdateAttendance(dto, id);
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