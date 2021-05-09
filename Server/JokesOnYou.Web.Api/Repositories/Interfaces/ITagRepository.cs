using System;//unnecessary?
using System.Collections.Generic;
using System.Linq; //unnecessary?
using System.Threading.Tasks;
using JokesOnYou.Web.Api.DTOs;
using JokesOnYou.Web.Api.Models;


namespace JokesOnYou.Web.Api.Repositories.Interfaces
{
    public interface ITagRepository
    {
        Task CreateTagAsync(Tag tag); 
    }
}
