using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using WhereToEat.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WhereToEat.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodTruckController : ControllerBase
    {
        // GET: api/<FoodTruckController>
        [HttpGet]
        public IEnumerable<string> Get(
            [FromQuery] double northwestLatitude, 
            [FromQuery] double northwestLongitude,
            [FromQuery] double southeastLatitude, 
            [FromQuery] double southeastLongitude)
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<FoodTruckController>/5
        /*[HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }*/

        // POST api/<FoodTruckController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<FoodTruckController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<FoodTruckController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
