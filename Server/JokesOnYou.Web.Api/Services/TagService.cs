using JokesOnYou.Web.Api.Repositories.Interfaces;
using JokesOnYou.Web.Api.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JokesOnYou.Web.Api.DTOs;
using JokesOnYou.Web.Api.Exceptions;
using AutoMapper;
using JokesOnYou.Web.Api.Models;

namespace JokesOnYou.Web.Api.Services
{
    public class TagService : ITagService
    {
        private readonly ITagRepository _tagRepo;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public TagService(ITagRepository tagRepo, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _tagRepo = tagRepo;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<TagReplyDto> CreateTagAsync(TagCreateDto tagCreateDto)
        {
            var tag = _mapper.Map<Tag>(tagCreateDto);
            await _tagRepo.CreateTagAsync(tag);

            var saved = await _unitOfWork.SaveAsync();
            if (!saved)
            {
                throw new AppException("error saving tag"); 
            }

            var tagReplyDto = _mapper.Map<TagReplyDto>(tag);

            return tagReplyDto;
        }
    }
}
