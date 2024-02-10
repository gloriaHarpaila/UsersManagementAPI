namespace UsersManagementAPI.Models
{
    public class UserReport
    {
        public int UserReportID { get; set; }
        public int UserID { get; set; }
        public int ReportID { get; set; }
        public bool HasAccess { get; set; }
    }

}
