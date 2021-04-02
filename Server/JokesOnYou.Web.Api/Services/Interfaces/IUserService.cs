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
        Task DeleteUser(User user);
        Task<User> CreateUser(UserRegisterDTO registerDTO);
        Task<User> GetUserById(string id);
        Task UpdateUser(User user);
        Task<User> Authenticate(string username, string password);
        Task<IEnumerable<User>> GetAll();
    }
}
