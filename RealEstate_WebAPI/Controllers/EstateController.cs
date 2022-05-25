using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealEstate_WebAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RealEstate_WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EstateController : ControllerBase
    {
        // GET: api/<EstateController>
        [HttpGet]
        public IEnumerable<Estate> GetAll()
        {
            using (var context = new realestatedbContext())
            {
                return context.Estates.ToList();
            }
        }

        // GET api/<EstateController>/5
        [HttpGet("{id}")]
        public ActionResult<Estate> Get(int id)
        {
            using (var context = new realestatedbContext())
            {
                Estate estate = context.Estates.Find(id);
                if(estate == null) return NotFound();
                return Ok(estate);
            }
        }

        // POST api/<EstateController>
        [HttpPost]
        public async Task<ActionResult<Estate>> Post([FromBody] Estate estate)
        {
            using (var context = new realestatedbContext())
            {
                context.Estates.Add(estate);
                await context.SaveChangesAsync();

                return Ok(estate);
            }
        }

        // PUT api/<EstateController>/5
        [HttpPut("{id}")]
        public ActionResult<Estate> Put(int id, [FromBody] Estate estate) 
        {
            estate.Id = id;

            if (estate == null) return BadRequest();
            using (var context = new realestatedbContext())
            {
                var existingEstate = context.Estates.Find(id);
                if (existingEstate != null)
                {
                    existingEstate = estate;
                    context.SaveChanges();
                    return Ok(existingEstate);
                }
                else return NotFound();

            }

        }

        // DELETE api/<EstateController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            using (var context = new realestatedbContext())
            {
                var estate = await context.Estates.FindAsync(id);
                if (estate == null)
                {
                    return NotFound();
                }

                context.Estates.Remove(estate);
                await context.SaveChangesAsync();

                return NoContent();
            }
        }
    }
}
