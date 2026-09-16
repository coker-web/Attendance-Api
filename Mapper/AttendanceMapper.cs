using AttendanceManagementSystem.Dtos;
using AttendanceManagementSystem.Model;

namespace AttendanceManagementSystem.Mapper
{
    public static class AttendanceMapper
    {
        public static Attendance ToEntity(this CreateRequestDto dto)
        {
            return new Attendance
            {
                Name = dto.Name,
                RegistrationNumber = dto.RegistrationNumber,
            };
        }
        public static ResponseDto ToResponse(this Attendance attends)
        {
            return new ResponseDto
            {
                Id = attends.Id,
                Name = attends.Name,
                RegistrationNumber = attends.RegistrationNumber,
                Date = attends.Date,
            };
        }
        public static void ToUpdate(this UpdateDto update, Attendance existingAttendance)
        {

            existingAttendance.Name = update.Name;
            existingAttendance.RegistrationNumber = update.RegistrationNumber;

        }

    }
}
