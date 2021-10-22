using JokesOnYou.Web.Api.Models.Request;
using JokesOnYou.Web.Api.Models.Request.Query;
using JokesOnYou.Web.Api.Models.Response;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JokesOnYou.Web.Api.Services.Interfaces
{
    public interface IUserService
    {
        Task DeleteUser(String id);
        //Task<User> CreateUser(UserRegisterDTO registerDTO);
        Task<UserReplyDto> GetUserReplyById(string id);
        Task UpdateUser(UserUpdateDto user);
        //Task<User> Authenticate(string username, string password);
        Task<IEnumerable<UserReplyDto>> GetAll(UserPaginationQueryParameters parameters);
        Task<UserReplyDto> LoginUser(UserLoginDTO userLoginDTO);
        Task RegisterUser(UserRegisterDto userRegisterDTO);
    }
}
