using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using JokesOnYou.Web.Api.Repositories.Interfaces;
using JokesOnYou.Web.Api.Services;
using Moq;
using JokesOnYou.Web.Api.Repositories;
using JokesOnYou.Web.Api.Models;

namespace Tests.Server
{
    public class UserServiceTests
    {
        private readonly Mock<IUserRepository> _Repo;

        public UserServiceTests()
        {
            //_Repo = new UserService();
        }

        [Fact]
        public void GetUserByID_Given_ExistingId_Returns_User()
        {
            var repo = new Mock<IUserRepository>();
            var service = new UserService(repo.Object);
            User ExpectedUser = new User() { Id = "1", Email = "a@a.a" };
            repo.Setup(r => r.GetUserAsync("1").Result).Returns(ExpectedUser);

            var actualUser = service.GetUserById("1").Result;

            actualUser.Should().Be(ExpectedUser);

        }

        [Fact]
        public void GetUserById_Given_NonExistingId_Throws()
        {
            //Arrange
            var repo = new Mock<IUserRepository>();
            var service = new UserService(repo.Object);
            User ExpectedUser = new User();
            repo.Setup(r => r.GetUserAsync("").Result).Returns((User)null);

            //Act
            Func<Task> act = async () => { await service.GetUserById(""); };

            //Assert
            act.Should().ThrowAsync<Exception>().WithMessage($"No user found with id: 1");
        }
    }
}
