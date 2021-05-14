using AutoMapper;
using JokesOnYou.Web.Api.DTOs;
using JokesOnYou.Web.Api.Exceptions;
using JokesOnYou.Web.Api.Repositories.Interfaces;
using JokesOnYou.Web.Api.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JokesOnYou.Web.Api.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepo;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUserRepository userRepo, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _userRepo = userRepo;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<UserReplyDTO>> GetAll()
        {
            return await _userRepo.GetUsersAsync();
        }

        public async Task DeleteUser(string id)
        {
            var user = await _userRepo.GetUserAsync(id);
            if (user == null)
            {
                throw new AppException($"Cant find user of id:{id}");
            }
            await _userRepo.DeleteUserAsync(user);
        }

        public async Task<UserReplyDTO> GetUserReplyById(string id)
        {
            return await _userRepo.GetUserReplyAsync(id);
        }

        public async Task UpdateUser(UserUpdateDTO userDTO)
        {
            var user = await _userRepo.GetUserAsync(userDTO.Id);
            _mapper.Map(userDTO, user);
            await _unitOfWork.SaveAsync();
        }
    }
}
