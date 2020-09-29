﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestProject.WebAPI.Commands.Users;
using TestProject.WebAPI.Domain;
using TestProject.WebAPI.Queries.Users;

namespace TestProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : BaseController
    {

        [HttpGet]
        public ActionResult<string> Get()
        {
            return Ok("Api is running.");
        }

        [HttpGet("list")]
        public async Task<IActionResult> List()
        {
            var query = new ListUsersQuery();
            var response = await Mediator.Send(query);

            return Ok(response);
        }
        
        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser([FromRoute] Guid id)
        {
            var query = new GetUserQuery(id);
            var response = await Mediator.Send(query);

            if (response != null)
            {
                return Ok(response);
            }
            else 
            {
                return NotFound($"{{error : User {id} Not found }}");          
            }
        }

        // POST api/<UsersController>/create
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateUserRequest userRequest)
        {
            var command = new CreateUserCommand(userRequest);
            var response = await Mediator.Send(command);

            if (response.Status == "Success")
            {
                return Created("/create", response);
            }
            else
            {
                return BadRequest(response);
            }
        }
    }
}
