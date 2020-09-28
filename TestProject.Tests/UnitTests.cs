using System;
using System.Threading;
using System.Threading.Tasks;
using TestProject.WebAPI.Handlers;
using TestProject.WebAPI.Queries.Users;
using FluentAssertions;
using Xunit;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TestProject.WebAPI.Models;
using TestProject.WebAPI.Domain;
using System.Collections.Generic;

namespace TestProject.Tests
{
    public class UnitTests
    {
        [Fact]
        public async Task GetUserQueryHandler_returns_a_user_when_available()
        {

            //Arrange
            var userId1 = Guid.NewGuid();
            var userId2 = Guid.NewGuid();
            GetUserResponse response;

            using (var db = MockDbContext())
            {
                db.Users.RemoveRange(db.Users);
                db.Users.Add(new User { Id = userId1, Name = "Tester1", Email = "email1@email.com" });
                db.Users.Add(new User { Id = userId2, Name = "Tester2", Email = "email2@email.com" });
                db.SaveChanges();
            }

            using (var db = MockDbContext())
            {
                // run your test here
                var request = new GetUserQuery(userId1);
                var handler = new GetUserQueryHandler(db);

                //Act
                response = await handler.Handle(request, CancellationToken.None);
            }

            //Assert
            response.Id.ToString().Should().Be(userId1.ToString());

        }

        [Fact]
        public async Task GetUserQueryHandler_does_not_return_a_user_when_not_available()
        {

            //Arrange
            var userId1 = Guid.NewGuid();
            var userId2 = Guid.NewGuid();
            GetUserResponse response;

            using (var db = MockDbContext())
            {
                db.Users.RemoveRange(db.Users);
                db.Users.Add(new User { Id = userId1, Name = "Tester1", Email = "email1@email.com" });
                db.Users.Add(new User { Id = userId2, Name = "Tester2", Email = "email2@email.com" });
                db.SaveChanges();
            }

            using (var db = MockDbContext())
            {
                // run your test here
                var request = new GetUserQuery(Guid.NewGuid());
                var handler = new GetUserQueryHandler(db);

                //Act
                response = await handler.Handle(request, CancellationToken.None);
            }

            //Assert
            response.Should().Be(null);

        }

        [Fact]
        public async Task ListUsersQueryHandler_returns_a_list_of_users_when_available()
        {
            //Arrange
            var userId1 = Guid.NewGuid();
            var userId2 = Guid.NewGuid();
            var userId3 = Guid.NewGuid();
            IEnumerable<ListUsersResponse> response;

            using (var db = MockDbContext())
            {
                db.Users.RemoveRange(db.Users);
                db.Users.Add(new User { Id = userId1, Name = "Tester1", Email = "email1@email.com" });
                db.Users.Add(new User { Id = userId2, Name = "Tester2", Email = "email2@email.com" });
                db.Users.Add(new User { Id = userId3, Name = "Tester3", Email = "email3@email.com" });
                db.SaveChanges();
            }

            using (var db = MockDbContext())
            {
                var request = new ListUsersQuery();
                var handler = new ListUsersQueryHandler(db);

                //Act
                response = await handler.Handle(request, CancellationToken.None);
            }

            //Assert
            response.Count().Should().Be(3);
        }

        [Fact]
        public async Task ListUsersQueryHandler_returns_a_blanklist_when_table_is_empty()
        {
            //Arrange
            IEnumerable<ListUsersResponse> response;

            using (var db = MockDbContext())
            {
                db.Users.RemoveRange(db.Users);
                db.SaveChanges();

                var request = new ListUsersQuery();
                var handler = new ListUsersQueryHandler(db);

                //Act
                response = await handler.Handle(request, CancellationToken.None);
            }

            //Assert
            response.Count().Should().Be(0);
        }

        private static ApiDbContext MockDbContext()
        {

            var options = new DbContextOptionsBuilder<ApiDbContext>()
                .UseInMemoryDatabase(databaseName: "InMemory")
                .Options;

            return new ApiDbContext(options);

        }
    }
}