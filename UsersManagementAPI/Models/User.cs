namespace UsersManagementAPI.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public int RoleID { get; set; }
        public string UserType { get; set; }
        public string UserStatus { get; set; }
    }

}
