using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestProject.WebAPI.Queries.Users
{
    public class ListUsersQuery : IRequest<IEnumerable<ListUsersResponse>>
    {


    }
}
