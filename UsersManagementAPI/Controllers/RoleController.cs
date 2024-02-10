using Microsoft.AspNetCore.Mvc;
using UsersManagementAPI.Services;
using UsersManagementAPI.Models;

namespace UsersManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class RoleController : ControllerBase
    {
        private readonly RoleService _roleService;

        public RoleController(RoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Role>> Get()
        {
            var roles = _roleService.GetRoles();
            return Ok(roles);
        }

        [HttpGet("{roleId}")]
        public ActionResult<Role> GetRoleById(int roleId)
        {
            var role = _roleService.GetRoleById(roleId);

            if (role == null)
            {
                return NotFound();
            }

            return Ok(role);
        }

        [HttpPost]
        public ActionResult<Role> AddRole(Role role)
        {
            _roleService.AddRole(role);
            return CreatedAtAction(nameof(GetRoleById), new { roleId = role.RoleID }, role);
        }

        [HttpPut("{roleId}")]
        public IActionResult UpdateRole(int roleId, Role updatedRole)
        {
            var existingRole = _roleService.GetRoleById(roleId);

            if (existingRole == null)
            {
                return NotFound();
            }

            existingRole.RoleName = updatedRole.RoleName;
            existingRole.RoleDescription = updatedRole.RoleDescription;

            _roleService.UpdateRole(existingRole);

            return NoContent();
        }
    }

}
