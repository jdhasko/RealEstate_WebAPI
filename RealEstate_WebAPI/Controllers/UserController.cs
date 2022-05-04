using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealEstate_WebAPI.Models;
using System.Reflection.Metadata.Ecma335;

namespace RealEstate_WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {

        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<User> GetAll()
        {
            using(var context = new realestatedbContext())
            {
                return context.Users.ToList();
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(int id)
        {
            using (var context = new realestatedbContext())
            {
                var user = await context.Users.FindAsync(id);
                if (user == null) return NotFound();
                return user;
            }
        }

        // POST: api/User
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<User>> PostCheckout([FromBody] User user)
        {
            using (var context = new realestatedbContext())
            {
                context.Users.Add(user);
                await context.SaveChangesAsync();

                return CreatedAtAction("User", new { id = user.Id }, user);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
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

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, User newUser)
        {
            if(id != newUser.Id) {
                return BadRequest();
            }

            using (var context = new realestatedbContext())
            {
                var user = await context.Users.FindAsync(id);
                if (user == null)
                {
                    return NotFound();
                }

               // context.Users.Update(newUser);
                context.Entry(newUser).State = EntityState.Modified;
                //  await context.SaveChangesAsync();

                try
                {
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }


                return Ok(user);
            }
        }
    }
}