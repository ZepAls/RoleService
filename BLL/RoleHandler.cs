using DTO;
using DAL;

namespace BLL
{
    public class RoleHandler
    {
        private RoleDatabaseHandler databaseHandler;
        public RoleHandler()
        {
            databaseHandler = new RoleDatabaseHandler();
        }

        public void CreateRole(RoleDTO Role)
        {
            databaseHandler.CreateRole(Role);
        }

        public void UpdateRole(RoleDTO Role)
        {
            databaseHandler.UpdateRole(Role);
        }

        public void DeleteRole(RoleDTO Role)
        {
            databaseHandler.DeleteRole(Role);
        }

        public IEnumerable<RoleDTO> GetAllRoles()
        {
            return databaseHandler.GetAllRoles();
        }

        public RoleDTO GetRole(int RoleId)
        {
            return databaseHandler.GetRole(RoleId);
        }

    }
}
