using JokesOnYou.Web.Api.DTOs;
using JokesOnYou.Web.Api.Models;
using JokesOnYou.Web.Api.Repositories.Interfaces;
using JokesOnYou.Web.Api.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JokesOnYou.Web.Api.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task DeleteUser(string id)
        {
            var user = await _userRepository.GetUserAsync(id);
            //TODO Add error check for user.
            await _userRepository.DeleteUserAsync(user);
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetUserById(string id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateUser(UserUpdateDTO updateDTO)
        {
            throw new NotImplementedException();
        }
    }
}
