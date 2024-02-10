using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UsersManagementAPI.Models;
using UsersManagementAPI.Services;

namespace UsersManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly ReportService _reportService;

        public ReportController(ReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Report>> GetAllReports()
        {
            var reports = _reportService.GetReports();
            return Ok(reports);
        }

        [HttpGet("{reportId}")]
        public ActionResult<Report> GetReportById(int reportId)
        {
            var report = _reportService.GetReportById(reportId);

            if (report == null)
            {
                return NotFound();
            }

            return Ok(report);
        }

        [HttpPost]
        public ActionResult<Report> AddReport(Report report)
        {
            _reportService.AddReport(report);
            return CreatedAtAction(nameof(GetReportById), new { reportId = report.ReportID }, report);
        }

        [HttpPut("{reportId}")]
        public IActionResult UpdateReport(int reportId, Report updatedReport)
        {
            var existingReport = _reportService.GetReportById(reportId);

            if (existingReport == null)
            {
                return NotFound();
            }

            existingReport.ReportURL = updatedReport.ReportURL;
            existingReport.ReportName = updatedReport.ReportName;

            _reportService.UpdateReport(existingReport);

            return NoContent();
        }
    }
}
