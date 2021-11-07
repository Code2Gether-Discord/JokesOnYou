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
        private readonly ITagRepository _tagRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public LikedTagsService(ILikedTagsRepository likedTagsRepo, ITagRepository tagRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _likedTagsRepo = likedTagsRepo;
            _tagRepository = tagRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<LikedTagsReplyDto> LikeTagAsync(int tagID, string userId)
        {
            Tag tagToLike = await _tagRepository.GetTagAsync(tagID);
            if (tagToLike == null)
            {
                throw new KeyNotFoundException("Tag not found");
            }


            LikedTags likedTags = await _likedTagsRepo.GetLikedTag(userId, tagID);
            if(likedTags != null)
            {
                throw new AppException("Tag already liked by user");
            }
            else
            {
                await _likedTagsRepo.AddLikedTag(new LikedTags
                {
                    UserId = userId,
                    TagId = tagID
                });
                tagToLike.Likes += 1;
            }

            if(!await _unitOfWork.SaveAsync())
            {
                throw new AppException("Failure to like tag");
            }

            var likedTagReplyDto = _mapper.Map<LikedTagsReplyDto>(tagToLike);

            return likedTagReplyDto;

        }

        public async Task UnlikeTagAsync(int tagID, string userId)
        {
            Tag tagToUnlike = await _tagRepository.GetTagAsync(tagID);
            if (tagToUnlike == null)
            {
                throw new KeyNotFoundException("Tag not found");
            }

            LikedTags likedTags = await _likedTagsRepo.GetLikedTag(userId, tagID);
            if (likedTags == null)
            {
                throw new AppException("Tag wasn't liked by user");
            }
            else
            {
                _likedTagsRepo.DeleteLikedTag(likedTags);
                tagToUnlike.Likes -= 1;
            }

            if (!await _unitOfWork.SaveAsync())
            {
                throw new AppException("Failure to unlike Tag");
            }
        }
    }
}
