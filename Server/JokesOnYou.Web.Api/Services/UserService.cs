using JokesOnYou.Web.Api.DTOs;
using JokesOnYou.Web.Api.Models;
using JokesOnYou.Web.Api.Repositories.Interfaces;
using JokesOnYou.Web.Api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JokesOnYou.Web.Api.Services
{
    
    public class UserService : IUserService
    {
        readonly IUserRepository _userRepo;
        public  UserService(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }
        public void CreateUser(UserRegisterDTO registerDTO)
        {
            _userRepository = userRepository;
        }

        public async Task DeleteUser(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetUserById(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateUser(User user)
        {
            return await _userRepo.UpdateUser(user); 
        }

        public async Task<User> Authenticate(string username, string password)
        {

        }
    }
}
