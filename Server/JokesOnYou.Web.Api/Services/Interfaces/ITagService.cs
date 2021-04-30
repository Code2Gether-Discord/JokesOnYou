using JokesOnYou.Web.Api.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JokesOnYou.Web.Api.Services.Interfaces
{
    public interface ITagService
    {
        Task<bool> DeleteTag(TagCreateDto tag);
        Task<bool> DeleteTag(int tagId);
        Task<bool> DeleteMultipleTag(List<TagCreateDto> tags);
        Task<bool> DeleteMultipleTag(int[] tagId);

    }
}
