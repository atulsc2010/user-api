﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestProject.WebAPI.Commands.Users
{
    public class CreateUserResponse
    {
        public string Type => GetType().Name;
        public Guid Id { get; set; }
        public string Status { get; set; }
    }
}
