using JokesOnYou.Web.Api.DTOs;
using JokesOnYou.Web.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JokesOnYou.Web.Api.Services.Interfaces
{
    public interface IAuthService
    {
        Task<UserReplyDTO> LoginAsync(UserLoginDTO userLoginDTO);
        Task RegisterAsync(UserRegisterDTO userRegisterDTO);
    }
}
