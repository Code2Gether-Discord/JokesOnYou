using System.Collections.Generic;
using System.Threading.Tasks;
using JokesOnYou.Web.Api.Models.Request;
using JokesOnYou.Web.Api.Exceptions;
using JokesOnYou.Web.Api.Models;
using JokesOnYou.Web.Api.Repositories.Interfaces;
using JokesOnYou.Web.Api.Services.Interfaces;
using AutoMapper;
using JokesOnYou.Web.Api.Models.Response;

namespace JokesOnYou.Web.Api.Services
{
    public class TagService : ITagService
    {
        private readonly ITagRepository _tagRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserJokeTagRepository _userJokeTagRepository;
        private readonly ILikeForTagsService _likeForTagsService;


        public TagService(ITagRepository tagRepo, IMapper mapper, IUnitOfWork unitOfWork, IUserJokeTagRepository userJokeTagRepository, ILikeForTagsService likeForTagsService)
        {
            _tagRepository = tagRepo;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _userJokeTagRepository = userJokeTagRepository;
            _likeForTagsService = likeForTagsService;
        }

        public async Task<TagReplyDto> CreateTagAsync(TagCreateDto tagCreateDto, string userId)
        {
            TagReplyDto tagReplyDto;
            Tag tag = await _tagRepository.GetTagByNameAsync(tagCreateDto.Name);
            if(tag == null)//Tag does not exist.
            {
                tag = _mapper.Map<Tag>(tagCreateDto);
                tag.OwnerId = userId;
                tag.Likes = 0;

                await _tagRepository.CreateTagAsync(tag);
                var tagSaved = await _unitOfWork.SaveAsync();
                if (!tagSaved)
                {
                    throw new AppException($"error: Failed saving the {nameof(tag)}: \"{tagCreateDto.Name}\" when it did not exist.");
                }
            }

            UserJokeTag userJokeTag = new()
            {
                UserId = userId,
                JokeId = tagCreateDto.JokeId,
                TagId = tag.Id,
                Likes = 0
            };

            var existingUserJokeTag = await _userJokeTagRepository.GetUserJokeTagAsync(userJokeTag);
            if (existingUserJokeTag == null)
            {
                await _userJokeTagRepository.CreateUserJokeTagAsync(userJokeTag);
                var saved = await _unitOfWork.SaveAsync();
                if (!saved)
                {
                    throw new AppException($"error: Failed saving {nameof(userJokeTag)} for the {nameof(tag)}: {tagCreateDto.Name}");
                }

                tagReplyDto = await _likeForTagsService.ToggleLikeForTag(userJokeTag, userId); // add initial like to LikeForTag
            }
            else
            {
                userJokeTag = existingUserJokeTag;

                tagReplyDto = await _likeForTagsService.ToggleLikeForTag(userJokeTag, userId);
                
            }

            tagReplyDto.Likes = userJokeTag.Likes;

            return tagReplyDto;
        }

        public async Task<IEnumerable<TagReplyDto>> GetAllTagDtosAsync() => await _tagRepository.GetAllTagDtosAsync();
        public async Task<TagReplyDto> GetTagDtoAsync(int id) => await _tagRepository.GetTagDtoAsync(id);

        public async Task<Tag> GetTagAsync(int id)
        {
            var tag = await _tagRepository.GetTagAsync(id);

            if (tag == null)
            {
                throw new AppException($"No Tag with Id:\"{id}\" has been found.");
            }
            return tag;
        }

        /// <summary>
        /// Deletes given <paramref name="tag"/>
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        public async Task DeleteTagAsync(Tag tag)
        {
            _tagRepository.Delete(tag);
            if (!await _unitOfWork.SaveAsync())
            {
                throw new AppException($"Something wend wrong when trying to save the database after Deleting the Tag: {tag}");
            }
        }

    }
}
