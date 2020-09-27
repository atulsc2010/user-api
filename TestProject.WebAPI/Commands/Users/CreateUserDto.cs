using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestProject.WebAPI.Commands.Users
{
    public class CreateUserDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
    }
}
