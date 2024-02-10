using Microsoft.AspNetCore.Mvc;
using UsersManagementAPI.Models;
using UsersManagementAPI.Services;

namespace UsersManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> GetAllUsers()
        {
            var users = _userService.GetUsers();
            return Ok(users);
        }

        [HttpGet("{userId}")]
        public ActionResult<User> GetUserById(int userId)
        {
            var user = _userService.GetUserById(userId);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        public ActionResult<User> AddUser(User user)
        {
            _userService.AddUser(user);
            return CreatedAtAction(nameof(GetUserById), new { userId = user.UserID }, user);
        }

        [HttpPut("{userId}")]
        public IActionResult UpdateUser(int userId, User updatedUser)
        {
            var existingUser = _userService.GetUserById(userId);

            if (existingUser == null)
            {
                return NotFound();
            }

            existingUser.Username = updatedUser.Username;
            existingUser.RoleID = updatedUser.RoleID;
            existingUser.UserType = updatedUser.UserType;
            existingUser.UserStatus = updatedUser.UserStatus;

            _userService.UpdateUser(existingUser);

            return NoContent();
        }
    }
}
