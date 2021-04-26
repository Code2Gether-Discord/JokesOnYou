using AutoMapper;
using JokesOnYou.Web.Api.DTOs;
using JokesOnYou.Web.Api.Exceptions;
using JokesOnYou.Web.Api.Repositories.Interfaces;
using JokesOnYou.Web.Api.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JokesOnYou.Web.Api.Services
{
    public class JokesService : IJokesService
    {
        private readonly IJokesRepository _jokesRepo;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public JokesService(IJokesRepository jokesRepo, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _jokesRepo = jokesRepo;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<JokeReplyDto>> GetAllJokeDtosAsync()
        {
            var jokeDtos = await _jokesRepo.GetAllJokeDtosAsync();

            return jokeDtos;
        }

        public async Task RemoveJokeAsync(int id)
        {
            var joke = await _jokesRepo.GetJokeByIdAsync(id);
            if (joke == null)
            {
                throw new KeyNotFoundException("Cant find joke");
            }
            _jokesRepo.DeleteJoke(joke);
            if (!await _unitOfWork.SaveAsync())
            {
                throw new AppException("Failed to remove joke");
            }
        }
    }
}
