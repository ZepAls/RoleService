using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class RoleDatabaseHandler
    {
        DBContext context;
        public RoleDatabaseHandler()
        {
            context = new DBContext();
        }

        public void CreateRole(RoleDTO Role)
        {
            context.Roles.Add(Role);
            context.SaveChanges();
        }

        public void UpdateRole(RoleDTO Role)
        {
            RoleDTO DbProposal = context.Roles.Where(t => t.Id == Role.Id).FirstOrDefault();
            if (DbProposal != null)
            {
                DbProposal.Id = Role.Id;
                DbProposal.CharacterPageName = Role.CharacterPageName;
                DbProposal.RoleName = Role.RoleName;
                DbProposal.UserName = Role.UserName;
                DbProposal.UserId = Role.UserId;
                context.SaveChanges();
            }
        }

        public void DeleteRole(RoleDTO Role)
        {
            RoleDTO toDelete = GetRole(Role.Id);
            context.Roles.Remove(toDelete);
            context.SaveChanges();
        }

        public IEnumerable<RoleDTO> GetAllRoles()
        {
            return context.Roles;
        }

        public void RemoveRoleWithUserId(int userId)
        {
            context.Roles.RemoveRange(context.Roles.Where(t => t.UserId == userId));
            context.SaveChanges();
        }

        public RoleDTO GetRole(int RoleId)
        {
            return context.Roles.Where(t => t.Id == RoleId).FirstOrDefault();
        }
    }
}
