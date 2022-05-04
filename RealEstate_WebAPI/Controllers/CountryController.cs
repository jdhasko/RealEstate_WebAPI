using Microsoft.AspNetCore.Mvc;
using RealEstate_WebAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RealEstate_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        // GET: api/<CountryController>
        [HttpGet]
        public IEnumerable<Country> GetAll()
        {
            using (var context = new realestatedbContext())
            {
                return context.Countries.ToList();
            }
        }

        // GET api/<CountryController>/5
        [HttpGet("{id}")]
        public ActionResult<Country> Get(int id)
        {
            using (var context = new realestatedbContext())
            {
                var Country = context.Countries.Find(id);
                if(Country == null) return NotFound();
                return Ok(Country);
            }
        }

        // POST api/<CountryController>
        [HttpPost]
        public async Task<ActionResult<Country>> Post([FromBody] Country country)
        {
            using (var context = new realestatedbContext())
            {
                context.Countries.Add(country);
                await context.SaveChangesAsync();

                return Ok(country);
            }
        }

        // PUT api/<CountryController>/5
        [HttpPut("{id}")]
        public ActionResult<Country> Put(int id, [FromBody] string countryName)
        {
            if (countryName == null) return BadRequest();
            using (var context = new realestatedbContext())
            {
                var existingCountry = context.Countries.Find(id);
                if (existingCountry != null)
                {
                    existingCountry.Name = countryName;
                    context.SaveChanges();
                    return Ok(existingCountry);
                }
                else return NotFound();

            }

        }

        // DELETE api/<CountryController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            using (var context = new realestatedbContext())
            {
                var country = await context.Countries.FindAsync(id);
                if (country == null)
                {
                    return NotFound();
                }

                context.Countries.Remove(country);
                await context.SaveChangesAsync();

                return NoContent();
            }
        }
    }
}
