using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealEstate_WebAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RealEstate_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstateTypeController : ControllerBase
    {
        // GET: api/<EstateTypeController>
        [HttpGet]
        public IEnumerable<EstateType> GetAll()
        {
            using (var context = new realestatedbContext())
            {
                return context.EstateTypes.ToList();
            }
        }

        // GET api/<EstateTypeController>/5
        [HttpGet("{id}")]
        public ActionResult<EstateType> Get(int id)
        {
            using (var context = new realestatedbContext())
            {
                EstateType estateType = context.EstateTypes.Find(id);
                if(estateType == null) return NotFound();
                return Ok(estateType);
            }
        }

        // POST api/<EstateTypeController>
        [HttpPost]
        public async Task<ActionResult<EstateType>> Post([FromBody] EstateType estateType)
        {
            using (var context = new realestatedbContext())
            {
                context.EstateTypes.Add(estateType);
                await context.SaveChangesAsync();

                return Ok(estateType);
            }
        }

        // PUT api/<EstateTypeController>/5
        [HttpPut("{id}")]
        public ActionResult<EstateType> Put(int id, [FromBody] string estateTypeName)
        {
            if (estateTypeName == null) return BadRequest();
            using (var context = new realestatedbContext())
            {
                var existingEstateType = context.EstateTypes.Find(id);
                if (existingEstateType != null)
                {
                    existingEstateType.Name = estateTypeName;
                    context.SaveChanges();
                    return Ok(existingEstateType);
                }
                else return NotFound();

            }

        }

        // DELETE api/<EstateTypeController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            using (var context = new realestatedbContext())
            {
                var estateType = await context.EstateTypes.FindAsync(id);
                if (estateType == null)
                {
                    return NotFound();
                }

                context.EstateTypes.Remove(estateType);
                await context.SaveChangesAsync();

                return NoContent();
            }
        }
    }
}
