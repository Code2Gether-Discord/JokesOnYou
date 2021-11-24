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
        private readonly ILikeForTagsRepository _likeForTagsRepoitory;
        private readonly IUserRepository _userRepository;
        private readonly ITagRepository _tagRepository;
        private readonly IUserJokeTagRepository _userJokeTagRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public LikeForTagsService(ILikeForTagsRepository likeForTagsRepository, ITagRepository tagRepository, IUnitOfWork unitOfWork, IMapper mapper, IUserRepository userRepository, IUserJokeTagRepository userJokeTagRepository)
        {
            _likeForTagsRepoitory = likeForTagsRepository;
            _tagRepository = tagRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userRepository = userRepository;
            _userJokeTagRepository = userJokeTagRepository;
        }

        public async Task<TagReplyDto> ToggleLikeForTag(UserJokeTag userJokeTag, string userId)
        {
            User user = await _userRepository.GetUserAsync(userId);
            LikeForTag likeForTag = await _likeForTagsRepoitory.GetLikedTag(userId, userJokeTag.Id); // check to see if user already like user joketag
            Tag tag = await _tagRepository.GetTagAsync(userJokeTag.TagId);
            if(likeForTag == null)
            {
                // liking UserJokeTag
                likeForTag = new LikeForTag
                {
                    UserId = userId,
                    UserJokeTagId = userJokeTag.Id
                };

                await _likeForTagsRepoitory.AddLikedTag(likeForTag);
                userJokeTag.Likes += 1;
                tag.Likes += 1;


                var saved = await _unitOfWork.SaveAsync();
                if (!saved)
                {
                    throw new AppException($"Error: Failed liking {nameof(userJokeTag)} for User: {user.UserName}");
                }
            }
            else
            {
                // unliking UserJokeTag
                _likeForTagsRepoitory.DeleteLikedTag(likeForTag);
                userJokeTag.Likes -= 1;
                tag.Likes -= 1;

                if(userJokeTag.Likes == 0) // we delete user JokeTag since likes reaches 0
                {
                    _userJokeTagRepository.DeleteUserJokeTag(userJokeTag);
                }

                var saved = await _unitOfWork.SaveAsync();
                if (!saved)
                {
                    throw new AppException($"Error: Failed unliking {nameof(userJokeTag)} for User: {user.UserName}");
                }
            }

            var tagReplyDto = _mapper.Map<TagReplyDto>(tag);
            tagReplyDto.Likes = userJokeTag.Likes;

            return tagReplyDto;
        }
    }
}
