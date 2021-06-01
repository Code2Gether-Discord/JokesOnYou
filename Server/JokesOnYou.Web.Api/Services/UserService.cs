using AutoMapper;
using JokesOnYou.Web.Api.Exceptions;
using JokesOnYou.Web.Api.Models;
using JokesOnYou.Web.Api.Models.Request;
using JokesOnYou.Web.Api.Models.Response;
using JokesOnYou.Web.Api.Repositories.Interfaces;
using JokesOnYou.Web.Api.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace JokesOnYou.Web.Api.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly SignInManager<User> _signInManager;
        private readonly ITokenService _tokenService;

        public UserService(IUserRepository userRepo, IMapper mapper, IUnitOfWork unitOfWork, SignInManager<User> signInManager, ITokenService tokenService)
        {
            _userRepository = userRepo;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        public async Task<IEnumerable<UserReplyDto>> GetAll()
        {
            return await _userRepository.GetUsersAsync();
        }

        public async Task DeleteUser(string id)
        {
            var user = await _userRepository.GetUserAsync(id);
            if (user == null)
            {
                throw new AppException($"Cant find user of id:{id}");
            }
            await _userRepository.DeleteUserAsync(user);
        }

        public async Task<UserReplyDto> GetUserReplyById(string id)
        {
            return await _userRepository.GetUserReplyAsync(id);
        }

        public async Task UpdateUser(UserUpdateDto userDto)
        {
            var user = await _userRepository.GetUserAsync(userDto.Id);
            _mapper.Map(userDto, user);
            await _unitOfWork.SaveAsync();
        }

        public async Task<User> GetUserById(string id)
        {
            return await _userRepository.GetUserAsync(id);
        }

        public async Task<UserReplyDto> LoginUser(UserLoginDTO userLogin)
        {
            var user = new EmailAddressAttribute().IsValid(userLogin.LoginName) ? await _userRepository.GetUserByEmailAsync(userLogin.LoginName) :
                await _userRepository.GetUserByUsernameAsync(userLogin.LoginName);

            if (user != null)
            {
                var signInResult = await _signInManager.CheckPasswordSignInAsync(user, userLogin.Password, false);

                if (!signInResult.Succeeded)
                {
                    throw new AppException("Sign in failed");
                }
                else
                {
                    var userReplyDto = _mapper.Map<UserReplyDto>(user);
                    userReplyDto.Token = _tokenService.GetToken(user);

                    return userReplyDto;
                }
            }
            else
            {
                throw new AppException("User not found");
            }
        }

        public async Task RegisterUser(UserRegisterDto userRegisterDTO)
        {
            if (new EmailAddressAttribute().IsValid(userRegisterDTO.UserName))
            {
                throw new UserRegisterException("Cannot use an email as username");
            }

            var user = await _userRepository.CreateUserAsync(userRegisterDTO);

            if (user == null)
            {
                throw new AppException("Failed to find user in the Database.");
            }
        }
    }
}
