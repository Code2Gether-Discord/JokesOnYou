using AutoMapper;
using AutoMapper.QueryableExtensions;
using JokesOnYou.Web.Api.Exceptions;
using JokesOnYou.Web.Api.Helpers;
using JokesOnYou.Web.Api.Models;
using JokesOnYou.Web.Api.Models.Request;
using JokesOnYou.Web.Api.Models.Request.Query;
using JokesOnYou.Web.Api.Models.Response;
using JokesOnYou.Web.Api.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JokesOnYou.Web.Api.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<User> _userManager;
        readonly IMapper _mapper;

        public UserRepository(UserManager<User> userManager, IMapper mapper)
        {
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<User> CreateUserAsync(UserRegisterDto userRegisterDto)
        {
            var userCreationResult = await _userManager.CreateAsync(new User()
            {
                Email = userRegisterDto.Email,
                UserName = userRegisterDto.UserName,
                Nsfw = userRegisterDto.NsfwEnabled
            }, userRegisterDto.Password);
            if (userCreationResult.Succeeded)
            {
                return await _userManager.FindByEmailAsync(userRegisterDto.Email);
            }
            else
            {
                StringBuilder message = new();
                foreach (var error in userCreationResult.Errors)
                {
                    message.AppendLine(error.Description);
                }

                throw new UserRegisterException(message.ToString(), new ArgumentException());
            }
        }

        public async Task<User> GetUserByUsernameAsync(string username) =>
            await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == username);

        public async Task<UserReplyDto> GetUserReplyAsync(string id) =>
            await _userManager.Users.ProjectTo<UserReplyDto>(_mapper.ConfigurationProvider)
                                    .FirstOrDefaultAsync(user => user.Id == id);


        public Task DeleteUserAsync(User user) => _userManager.DeleteAsync(user);


        public async Task<User> GetUserAsync(string id) => await _userManager.FindByIdAsync(id);


        public async Task<User> GetUserByEmailAsync(string email) => await _userManager.FindByEmailAsync(email);

        public async Task<PaginatedList<UserReplyDto>> GetUsersReplyDtoAsync(UserParameters parameters)
        {
            var users = _userManager.Users.AsNoTracking();

            if (string.IsNullOrEmpty(parameters.SearchText) == false || string.IsNullOrWhiteSpace(parameters.SearchText) == false)
            {
                users = users.Where(x => x.Email.Contains(parameters.SearchText) || 
                x.UserName.Contains(parameters.SearchText));
            }

            var result = await PaginatedList<UserReplyDto>.ToPaginatedListAsync(
                users.ProjectTo<UserReplyDto>(_mapper.ConfigurationProvider),
                parameters.PageNumber,
                parameters.PageSize);

            return result;
        }
    }
}