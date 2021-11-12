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
    public class LikeForTagsService : ILikeForTagsService
    {
        private readonly ILikeForTagsRepository _likeForTagsRepo;
        private readonly IUserRepository _userRepository;
        private readonly ITagRepository _tagRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public LikeForTagsService(ILikeForTagsRepository likeForTagsRepo, ITagRepository tagRepository, IUnitOfWork unitOfWork, IMapper mapper, IUserRepository userRepository)
        {
            _likeForTagsRepo = likeForTagsRepo;
            _tagRepository = tagRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<LikeForTagReplyDto> LikeTagAsync(int tagId, string userId)
        {
            Tag tagToLike = await _tagRepository.GetTagAsync(tagId);
            User user = await _userRepository.GetUserAsync(userId);
            if (tagToLike == null)
            {
                throw new KeyNotFoundException("Tag not found");
            }


            LikeForTag likedTags = await _likeForTagsRepo.GetLikedTag(userId, tagId);
            if(likedTags != null)
            {
                throw new AppException($"{tagToLike.Name} tag already liked by {user.UserName}");
            }
            else
            {
                await _likeForTagsRepo.AddLikedTag(new LikeForTag
                {
                    UserId = userId,
                    TagId = tagId
                });
                tagToLike.Likes += 1;
            }

            if(!await _unitOfWork.SaveAsync())
            {
                throw new AppException("Failure to like tag");
            }

            var likedTagReplyDto = _mapper.Map<LikeForTagReplyDto>(tagToLike);

            return likedTagReplyDto;

        }

        public async Task UnlikeTagAsync(int tagId, string userId)
        {
            Tag tagToUnlike = await _tagRepository.GetTagAsync(tagId);
            User user = await _userRepository.GetUserAsync(userId);
            if (tagToUnlike == null)
            {
                throw new KeyNotFoundException("Tag not found");
            }

            LikeForTag likeForTag = await _likeForTagsRepo.GetLikedTag(userId, tagId);
            if (likeForTag == null)
            {
                throw new AppException($"{tagToUnlike.Name} tag wasn't liked by {user.UserName}");
            }
            else
            {
                _likeForTagsRepo.DeleteLikedTag(likeForTag);
                tagToUnlike.Likes -= 1;
            }

            if (!await _unitOfWork.SaveAsync())
            {
                throw new AppException("Failure to unlike Tag");
            }
        }
    }
}
