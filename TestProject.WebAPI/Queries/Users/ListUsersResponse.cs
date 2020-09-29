﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestProject.WebAPI.Queries.Users
{
    public class ListUsersResponse
    {
        public string Type => GetType().Name;
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
