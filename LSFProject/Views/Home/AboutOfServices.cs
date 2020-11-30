using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LSFProject.Views.Home
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutOfServices : ControllerBase
    {
        // GET: api/<AboutOfServices>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<AboutOfServices>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AboutOfServices>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AboutOfServices>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AboutOfServices>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
