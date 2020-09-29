using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestProject.WebAPI.Commands.Accounts
{
    public class CreateAccountResponse
    {
        public string Type => GetType().Name;
        public Guid Id { get; set; }
        public string Status { get; set; }
    }
}
