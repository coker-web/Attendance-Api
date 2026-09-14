using Microsoft.EntityFrameworkCore;
using ManagementSystem.Model;
namespace ManagementSystem.Database
{
    public class ApplicationDb : DbContext
    {
        DbContextOptions _options;
        public ApplicationDb(DbContextOptions options) : base(options)
        {
            _options = options;
        }
        public DbSet<Attendance> Attendances { get; set; }
    }
}


