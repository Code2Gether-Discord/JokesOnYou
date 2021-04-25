using JokesOnYou.Web.Api.DTOs;
using JokesOnYou.Web.Api.Models;
using JokesOnYou.Web.Api.Repositories;
using JokesOnYou.Web.Api.Repositories.Interfaces;
using JokesOnYou.Web.Api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JokesOnYou.Web.Api.Exceptions;
using AutoMapper;

namespace JokesOnYou.Web.Api.Services
{
    
    public class UserService : IUserService
    {
        readonly IUserRepository _userRepo;
        readonly IMapper _mapper;
        public  UserService(IUserRepository userRepo, IMapper mapper)
        {
            _userRepo = userRepo;
            _mapper = mapper;
        }
        public async Task<IEnumerable<UserReplyDTO>> GetAll()
        {
             var users = await _userRepo.GetUsersAsync();
            return _mapper.Map<List<UserReplyDTO>>(users);
        }
        
        public async Task DeleteUser(string id)
        {
            var user = await _userRepo.GetUserAsync(id);
            if (user == null)
                throw new AppException($"Cant find user of id:{id}");
            await _userRepo.DeleteUserAsync(user);
        }

        public async Task<UserReplyDTO> GetUserReplyById(string id)
        {
            return await _userRepo.GetUserReplyAsync(id);
        }

        public async Task UpdateUser(UserUpdateDTO userDTO)
        {
            var user = _mapper.Map<User>(userDTO);
            await _userRepo.UpdateUser(user); 
        }

    }
}
