using System;
using System.Threading;
using System.Threading.Tasks;
using TestProject.WebAPI.Handlers;
using TestProject.WebAPI.Queries.Users;
using FluentAssertions;
using Xunit;
using System.Linq;

namespace TestProject.Tests
{
    public class UnitTests
    {
        [Fact]
        public async Task GetUserQueryHandler_returns_a_user()
        {
            //Arrange
            var userId = Guid.NewGuid();
            var request = new GetUserQuery(userId);
            var handler = new GetUserQueryHandler();

            //Act
            var response = await handler.Handle(request, CancellationToken.None);

            //Assert
            response.Id.ToString().Should().Be(userId.ToString());
            
        }

        [Fact]
        public async Task ListUsersQueryHandler_returns_a_list_of_users()
        {
            //Arrange
            var request = new ListUsersQuery();
            var handler = new ListUsersQueryHandler();

            //Act
            var response = await handler.Handle(request, CancellationToken.None);

            //Assert
            response.Count().Should().BeGreaterThan(0);
        }
    }
}