using JokesOnYou.Web.Api.DTOs;
using JokesOnYou.Web.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JokesOnYou.Web.Api.Services.Interfaces
{
    public interface IUserService
    {
        IEnumerable<User> GetAll();
        User GetUserById(string id);
        void CreateUser(UserRegisterDTO registerDTO);
        Task<bool> UpdateUser(User user);
        void DeleteUser(string id);
        Task<User> Authenticate(string username, string password);
    }
}
