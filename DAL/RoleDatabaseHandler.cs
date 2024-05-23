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
                context.SaveChanges();
            }
        }

        public void DeleteRole(RoleDTO Role)
        {
            context.Roles.Remove(Role);
            context.SaveChanges();
        }

        public IEnumerable<RoleDTO> GetAllRoles()
        {
            return context.Roles;
        }

        public RoleDTO GetRole(int RoleId)
        {
            return context.Roles.Where(t => t.Id == RoleId).FirstOrDefault();
        }
    }
}
