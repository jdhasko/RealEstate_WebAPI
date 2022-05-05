using Microsoft.AspNetCore.Mvc;
using RealEstate_WebAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RealEstate_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // GET: api/<UserController>
        [HttpGet]
        public IEnumerable<User> GetAll()
        {
            using (var context = new realestatedbContext())
            {
                return context.Users.ToList();
            }
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            using (var context = new realestatedbContext())
            {
                User user = context.Users.Find(id);
                if (user == null) return NotFound();
                return Ok(user);
            }
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<ActionResult<User>> Post([FromBody] User user)
        {
            if(user != null) { 
                using (var context = new realestatedbContext())
                {
                    context.Users.Add(user);
                    await context.SaveChangesAsync();

                    return Ok(user);
                }
            }
            return BadRequest();
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public ActionResult<User> Put(int id, [FromBody] User user)
        {
            if (user == null) return BadRequest();

            user.Id = id;   

            using (var context = new realestatedbContext())
            {
                var existingUser = context.Users.Find(id);
                if (existingUser != null)
                {
                    existingUser = user;
                    context.SaveChanges();
                    return Ok(existingUser);
                }
                else return NotFound();

            }

        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            using (var context = new realestatedbContext())
            {
                var user = await context.Users.FindAsync(id);
                if (user == null)
                {
                    return NotFound();
                }

                context.Users.Remove(user);
                await context.SaveChangesAsync();

                return NoContent();
            }
        }
    }
}
