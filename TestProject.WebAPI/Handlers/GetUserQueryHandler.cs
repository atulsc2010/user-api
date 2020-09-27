using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TestProject.WebAPI.Queries.Users;

namespace TestProject.WebAPI.Handlers
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, GetUserResponse>
    {
        public async Task<GetUserResponse> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(
                new GetUserResponse
                {
                    Id = request.Id,
                    Name = "Tester",
                    Email = "email@email.com"
                }
            );
        }
    }
}
