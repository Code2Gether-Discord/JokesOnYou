using JokesOnYou.Web.Api.DTOs;
using JokesOnYou.Web.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JokesOnYou.Web.Api.Services.Interfaces
{
    interface IUserService
    {
        IEnumerable<User> GetAll();
        User GetUserById(string id);
        void CreateUser(UserRegisterDTO registerDTO);
        void UpdateUser(UserUpdateDTO updateDTO);
        void DeleteUser(string id);
    }
}
