using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProject.WebAPI.Models;

namespace TestProject.WebAPI.Commands.Users
{
    public class CreateUserCommand : IRequest<CreateUserResponse>
    {
        public CreateUserRequest Request { get; private set; }

        public CreateUserCommand(CreateUserRequest request)
        {
            Request = request;
        }

    }
}
