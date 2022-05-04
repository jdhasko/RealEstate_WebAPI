using Microsoft.AspNetCore.Mvc;
using RealEstate_WebAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RealEstate_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        // GET: api/<AuthController>
        [HttpGet]
        public IEnumerable<Auth> GetAll()
        {
            using (var context = new realestatedbContext())
            {
                return context.Auths.ToList();
            }
        }

        // GET api/<AuthController>/5
        [HttpGet("{id}")]
        public ActionResult<Auth> Get(int id)
        {
            using (var context = new realestatedbContext())
            {
                Auth auth = context.Auths.Find(id);
                if(auth == null) return NotFound();
                return Ok(auth);
            }
        }

        // POST api/<AuthController>
        [HttpPost]
        public async Task<ActionResult<Auth>> Post([FromBody] Auth auth)
        {
            using (var context = new realestatedbContext())
            {
                context.Auths.Add(auth);
                await context.SaveChangesAsync();

                return Ok(auth);
            }
        }

        // PUT api/<AuthController>/5
        [HttpPut("{id}")]
        public ActionResult<Auth> Put(int id, [FromBody] Auth auth)
        {
            if (auth == null) return BadRequest();
            using (var context = new realestatedbContext())
            {
                var existingAuth = context.Auths.Find(id);
                if (existingAuth != null)
                {
                    existingAuth.Email = auth.Email;
                    context.SaveChanges();
                    return Ok(existingAuth);
                }
                else return NotFound();

            }

        }

        // DELETE api/<AuthController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            using (var context = new realestatedbContext())
            {
                var auth = await context.Auths.FindAsync(id);
                if (auth == null)
                {
                    return NotFound();
                }

                context.Auths.Remove(auth);
                await context.SaveChangesAsync();

                return NoContent();
            }
        }
    }
}
