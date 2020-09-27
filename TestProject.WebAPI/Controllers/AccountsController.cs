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
    public class AccountsController : BaseController
    {
        [HttpGet("/list/{id}")]
        public ActionResult<IEnumerable<Account>> List()
        {
            return new List<Account> 
            {   new Account { Id = Guid.NewGuid() },
                new Account { Id = Guid.NewGuid() }
            };
        }

        // POST api/<AccountsController>
        [HttpPost("/create")]
        public void Create([FromBody] string value)
        {
        }

    }
}
