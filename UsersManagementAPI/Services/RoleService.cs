using Microsoft.EntityFrameworkCore;
using UsersManagementAPI.Models;
using UsersManagementAPI.Database;

namespace UsersManagementAPI.Services
{
    public class RoleService
    {
        private readonly ApplicationDbContext _context;

        public RoleService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Role> GetRoles()
        {
            return _context.Roles.ToList();
        }

        public Role GetRoleById(int roleId)
        {
            return _context.Roles.FirstOrDefault(r => r.RoleID == roleId);
        }

        public void AddRole(Role role)
        {
            _context.Roles.Add(role);
            _context.SaveChanges();
        }

        public void UpdateRole(Role role)
        {
            _context.Entry(role).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
