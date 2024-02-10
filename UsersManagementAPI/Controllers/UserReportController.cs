using Microsoft.AspNetCore.Mvc;
using UsersManagementAPI.Models;
using UsersManagementAPI.Services;

namespace UsersManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserReportController : ControllerBase
    {
        private readonly UserReportService _userReportService;

        public UserReportController(UserReportService userReportService)
        {
            _userReportService = userReportService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<UserReport>> GetAllUserReports()
        {
            var userReports = _userReportService.GetUserReports();
            return Ok(userReports);
        }

        [HttpGet("{userReportId}")]
        public ActionResult<UserReport> GetUserReportById(int userReportId)
        {
            var userReport = _userReportService.GetUserReportById(userReportId);

            if (userReport == null)
            {
                return NotFound();
            }

            return Ok(userReport);
        }

        [HttpPost]
        public ActionResult<UserReport> AddUserReport(UserReport userReport)
        {
            _userReportService.AddUserReport(userReport);
            return CreatedAtAction(nameof(GetUserReportById), new { userReportId = userReport.UserReportID }, userReport);
        }

        [HttpPut("{userReportId}")]
        public IActionResult UpdateUserReport(int userReportId, UserReport updatedUserReport)
        {
            var existingUserReport = _userReportService.GetUserReportById(userReportId);

            if (existingUserReport == null)
            {
                return NotFound();
            }

            existingUserReport.UserID = updatedUserReport.UserID;
            existingUserReport.ReportID = updatedUserReport.ReportID;
            existingUserReport.HasAccess = updatedUserReport.HasAccess;

            _userReportService.UpdateUserReport(existingUserReport);

            return NoContent();
        }
    }
}

