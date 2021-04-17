using JokesOnYou.Web.Api.DTOs;
using JokesOnYou.Web.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

namespace JokesOnYou.Web.Api.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAll();
        Task<User> GetUserById(string id);
        Task UpdateUser(UserUpdateDTO updateDTO);
        Task DeleteUser(string id);
        Task<UserReplyDTO> LoginUser(UserLoginDTO userLoginDTO);
    }
}
