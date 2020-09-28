using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TestProject.WebAPI.Commands.Users;
using TestProject.WebAPI.Domain;
using TestProject.WebAPI.Models;

namespace TestProject.WebAPI.Handlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CreateUserResponse>
    {
        private readonly ApiDbContext _db;
        
        public CreateUserCommandHandler(ApiDbContext db)
        {
            _db = db;
        }

        public async Task<CreateUserResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {

            try
            {
                if (_db.Users.Any(u => u.Email == request.Request.Email)) 
                {
                    throw new Exception("Email Address already exists, User cannot be created");   
                }

                var user = new User
                {
                    Id = Guid.NewGuid(),
                    Email = request.Request.Email,
                    Name = request.Request.Name,
                    Salary = request.Request.Salary,
                    Expenses = request.Request.Expenses
                };

                _db.Users.Add(user);
                await _db.SaveChangesAsync();

                return await Task.FromResult(new CreateUserResponse { Id = user.Id });
                 
            }
            catch (Exception e)
            {

                throw e;
            }

        }
    }
}
