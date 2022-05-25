using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealEstate_WebAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RealEstate_WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        // GET: api/<RoleController>
        [HttpGet]
        public IEnumerable<Role> GetAll()
        {
            using (var context = new realestatedbContext())
            {
                return context.Roles.ToList();
            }
        }

        // GET api/<RoleController>/5
        [HttpGet("{id}")]
        public ActionResult<Role> Get(int id)
        {
            using (var context = new realestatedbContext())
            {
                Role role = context.Roles.Find(id);
                if(role == null) return NotFound();
                return Ok(role);
            }
        }

        // POST api/<RoleController>
        [HttpPost]
        public async Task<ActionResult<Role>> Post([FromBody] Role role)
        {
            using (var context = new realestatedbContext())
            {
                context.Roles.Add(role);
                await context.SaveChangesAsync();

                return Ok(role);
            }
        }

        // PUT api/<RoleController>/5
        [HttpPut("{id}")]
        public ActionResult<Role> Put(int id, [FromBody] string roleName)
        {
            if (roleName == null) return BadRequest();
            using (var context = new realestatedbContext())
            {
                var existingRole = context.Roles.Find(id);
                if (existingRole != null)
                {
                    existingRole.Name = roleName;
                    context.SaveChanges();
                    return Ok(existingRole);
                }
                else return NotFound();

            }

        }

        // DELETE api/<RoleController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            using (var context = new realestatedbContext())
            {
                var role = await context.Roles.FindAsync(id);
                if (role == null)
                {
                    return NotFound();
                }

                context.Roles.Remove(role);
                await context.SaveChangesAsync();

                return NoContent();
            }
        }
    }
}
