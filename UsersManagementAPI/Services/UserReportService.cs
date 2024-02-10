using Microsoft.EntityFrameworkCore;
using UsersManagementAPI.Database;
using UsersManagementAPI.Models;

namespace UsersManagementAPI.Services
{
    public class UserReportService
    {
        private readonly ApplicationDbContext _context;

        public UserReportService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<UserReport> GetUserReports()
        {
            return _context.UsersReports.ToList();
        }

        public UserReport GetUserReportById(int userReportId)
        {
            return _context.UsersReports.FirstOrDefault(ur => ur.UserReportID == userReportId);
        }

        public void AddUserReport(UserReport userReport)
        {
            _context.UsersReports.Add(userReport);
            _context.SaveChanges();
        }

        public void UpdateUserReport(UserReport userReport)
        {
            _context.Entry(userReport).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}


