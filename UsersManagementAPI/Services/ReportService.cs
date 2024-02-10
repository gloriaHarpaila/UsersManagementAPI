using Microsoft.EntityFrameworkCore;
using UsersManagementAPI.Models;
using UsersManagementAPI.Database;

namespace UsersManagementAPI.Services
{
    public class ReportService
    {
        private readonly ApplicationDbContext _context;

        public ReportService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Report> GetReports()
        {
            return _context.Reports.ToList();
        }

        public Report GetReportById(int reportId)
        {
            return _context.Reports.FirstOrDefault(r => r.ReportID == reportId);
        }

        public void AddReport(Report report)
        {
            _context.Reports.Add(report);
            _context.SaveChanges();
        }

        public void UpdateReport(Report report)
        {
            _context.Entry(report).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
