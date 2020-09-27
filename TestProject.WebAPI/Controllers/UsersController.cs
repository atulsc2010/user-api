using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestProject.WebAPI.Domain;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : BaseController
    {
        // GET: api/<UsersController>
        [HttpGet("/list")]
        public async Task<IActionResult> List()
        {
            return new User[] { "value1", "value2" };
        }
        
        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public ActionResult<User> Get([FromRoute] Guid id)
        {
            return new User { Id = Guid.NewGuid() };
        }

        // POST api/<UsersController>/create
        [HttpPost("/create")]
        public void Create([FromBody] string value)
        {
        }
    }
}
