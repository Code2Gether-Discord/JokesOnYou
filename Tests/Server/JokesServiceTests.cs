using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using Moq;
using JokesOnYou.Web.Api.Repositories.Interfaces;
using JokesOnYou.Web.Api.Services;
using JokesOnYou.Web.Api.Models;
using JokesOnYou.Web.Api.DTOs;

namespace Tests.Server
{
    public class JokesServiceTests
    {
        [Fact]
        public void GetAllUsers_Returns_ListOfJokesDto()
        {
            var repo = new Mock<IJokesRepository>();
            var service = new JokesService(repo.Object);
            List<Joke> Jokes = new List<Joke>() {
                new Joke() { Id = 1, Premise = "1", Punchline = "1", Likes = 1, Dislikes = 0},
                new Joke() { Id = 2, Premise = "2", Punchline = "2", Likes = 2, Dislikes = 0}
            };
            repo.Setup(r => r.GetAllJokesAsync().Result).Returns(Jokes);
            List<JokeReplyDto> expected = new List<JokeReplyDto>();
            foreach (Joke joke in Jokes)
            {
                expected.Add(new JokeReplyDto() { Id = joke.Id, Premise = joke.Premise, Punchline = joke.Punchline, Likes = joke.Likes, Dislikes = joke.Dislikes });
            }

            var actualList = service.GetAllJokesAsync().Result;

            actualList.Should().Be(expected);

        }

        /*
         * These are example Tests
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
        */
    }
}
