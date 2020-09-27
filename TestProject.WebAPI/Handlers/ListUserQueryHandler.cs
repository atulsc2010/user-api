using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TestProject.WebAPI.Queries.Users;

namespace TestProject.WebAPI.Handlers
{
    public class ListUserQueryHandler : IRequestHandler<ListUsersQuery, IEnumerable<ListUsersResponse>>
    {
        public async Task<IEnumerable<ListUsersResponse>> Handle(ListUsersQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(new List<ListUsersResponse>()
            {
                new ListUsersResponse
                {
                    Id = Guid.NewGuid(),
                    Name = "Tester",
                    Email = "email@email.com"
                }
            });
        }
    }
}
