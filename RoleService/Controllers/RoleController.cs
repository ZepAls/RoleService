using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using BLL;
using DTO;

namespace RoleService.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class RoleController : ControllerBase
    {
        // GET: api/<RoleController>
        [HttpGet]
        public ActionResult Get()
        {
            RoleHandler handler = new RoleHandler();
            IEnumerable<RoleDTO> Rolelist = handler.GetAllRoles();
            int amount = Rolelist.Count();
            if (amount != 0)
            {
                return Ok(Rolelist);
            }
            return NotFound("There are no Roles found");
        }

        // GET api/<RoleController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            RoleHandler handler = new RoleHandler();
            RoleDTO returnRole = handler.GetRole(id);
            if (returnRole != null)
            {
                return Ok(returnRole);
            }
            return NotFound($"Role could not be found: There is no Role with id : {id}");
        }

        // POST api/<ProposalController>
        [HttpPost]
        public ActionResult Post(RoleDTO Role)
        {
            if (Role.Id == 0)
            {
                RoleHandler handler = new RoleHandler();
                handler.CreateRole(Role);
                return Ok("Role created succesfully");
            }
            return BadRequest($"Role could not be created: Id was expected to be 0 but was {Role.Id}");
        }

        // PUT api/<RoleController>/5
        [HttpPut]
        public ActionResult Put(RoleDTO Role)
        {
            RoleHandler handler = new RoleHandler();
            if (handler.GetRole(Role.Id) != null)
            {
                handler.UpdateRole(Role);
                return Ok("Role updated succesfully");
            }
            return BadRequest($"Role could not be updated: There is no Role with id {Role.Id}");

        }

        // DELETE api/<RoleController>/5
        [HttpDelete]
        public ActionResult Delete(RoleDTO Role)
        {
            RoleHandler handler = new RoleHandler();
            if (handler.GetRole(Role.Id) != null)
            {
                handler.DeleteRole(Role);
                return Ok("Role Deleted succesfully");
            }
            return BadRequest($"Role could not be deleted: There is no Role with id {Role.Id}");
        }
    }

}
