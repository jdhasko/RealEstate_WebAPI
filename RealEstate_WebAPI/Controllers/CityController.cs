using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealEstate_WebAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RealEstate_WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        // GET: api/<CityController>
        [HttpGet]
        public IEnumerable<City> GetAll()
        {
            using (var context = new realestatedbContext())
            {
                return context.Cities.ToList();
            }
        }

        // GET api/<CityController>/5
        [HttpGet("{id}")]
        public ActionResult<City> Get(int id)
        {
            using (var context = new realestatedbContext())
            {
                City city = context.Cities.Find(id);
                if(city == null) return NotFound();
                return Ok(city);
            }
        }

        // POST api/<CityController>
        [HttpPost]
        public async Task<ActionResult<City>> Post([FromBody] City city)
        {
            using (var context = new realestatedbContext())
            {
                context.Cities.Add(city);
                await context.SaveChangesAsync();

                return Ok(city);
            }
        }

        // PUT api/<CityController>/5
        [HttpPut("{id}")]
        public ActionResult<City> Put(int id, [FromBody] string cityName) 
        {
            if (cityName == null) return BadRequest();
            using (var context = new realestatedbContext())
            {
                var existingCity = context.Cities.Find(id);
                if (existingCity != null)
                {
                    existingCity.Name = cityName;
                    context.SaveChanges();
                    return Ok(existingCity);
                }
                else return NotFound();

            }

        }

        // DELETE api/<CityController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            using (var context = new realestatedbContext())
            {
                var city = await context.Cities.FindAsync(id);
                if (city == null)
                {
                    return NotFound();
                }

                context.Cities.Remove(city);
                await context.SaveChangesAsync();

                return NoContent();
            }
        }
    }
}
