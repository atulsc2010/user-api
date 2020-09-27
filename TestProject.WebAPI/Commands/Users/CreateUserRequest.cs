﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestProject.WebAPI.Commands.Users
{
    public class CreateUserRequest
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public decimal Salary { get; set; }
        public decimal Expenses { get; set; }
    }
}
