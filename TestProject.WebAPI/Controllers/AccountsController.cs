using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestProject.WebAPI.Commands.Accounts;
using TestProject.WebAPI.Domain;
using TestProject.WebAPI.Queries.Accounts;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : BaseController
    {
        [HttpGet("list")]
        public async Task<IActionResult> List()
        {
            var query = new ListAccountsQuery();
            var response = await Mediator.Send(query);

            return Ok(response);

            //return new List<Account> 
            //{   new Account { Id = Guid.NewGuid() },
            //    new Account { Id = Guid.NewGuid() }
            //};
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateAccountRequest accountRequest)
        {
            var command = new CreateAccountCommand(accountRequest);
            var response = await Mediator.Send(command);

            if (response.Status == "Success")
            {
                return Created("/accounts/create", response);
            }
            else
            {
                return BadRequest(response);
            }

        }

    }
}
