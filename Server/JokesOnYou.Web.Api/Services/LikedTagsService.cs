using AutoMapper;
using JokesOnYou.Web.Api.Exceptions;
using JokesOnYou.Web.Api.Models;
using JokesOnYou.Web.Api.Models.Request;
using JokesOnYou.Web.Api.Models.Response;
using JokesOnYou.Web.Api.Repositories.Interfaces;
using JokesOnYou.Web.Api.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JokesOnYou.Web.Api.Services
{
    public class LikedTagsService : ILikedTagsService
    {
        private readonly ILikedTagsRepository _likedTagsRepo;
        private readonly ITagRepository _tagRepo;
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public LikedTagsService(ILikedTagsRepository likedTagsRepo, ITagRepository tagRepository, IUserRepository userRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _likedTagsRepo = likedTagsRepo;
            _tagRepo = tagRepository;
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<LikedTagsReplyDto> LikeTagAsync(LikedTagsCreateDto likedTagCreateDto, string userId)
        {
            Tag tagToLike = await _tagRepo.GetTagAsync(likedTagCreateDto.Id);
            User userLikingTag = await _userRepository.GetUserAsync(userId);

            if (tagToLike == null)
            {
                throw new KeyNotFoundException("Cannot find tag");
            }

            if (tagToLike.Users.Contains(userLikingTag))
            {
                throw new AppException("User already liked this tag");
            }
            
            tagToLike.Likes += 1;
            tagToLike.Users.Add(userLikingTag);
            await _unitOfWork.SaveAsync();

            var likedTagReplyDto = _mapper.Map<LikedTagsReplyDto>(tagToLike);

            return likedTagReplyDto;

        }

        public async Task UnlikeTagAsync(UnlikedTagCreateDto unlikedTagCreateDto, string userId)
        {
            Tag tagToUnlike = await _tagRepo.GetTagAsync(unlikedTagCreateDto.Id);
            User userUnlikingTag = await _userRepository.GetUserAsync(userId);
            if (tagToUnlike == null)
            {
                throw new KeyNotFoundException("Tag not found");
            }

            if (!tagToUnlike.Users.Contains(userUnlikingTag))
            {
                throw new KeyNotFoundException("Tag wasn't liked user");
            }
            tagToUnlike.Likes -= 1;
            tagToUnlike.Users.Remove(userUnlikingTag);
            if (!await _unitOfWork.SaveAsync())
            {
                throw new AppException("Failure to unlike Tag");
            }
        }
    }
}
