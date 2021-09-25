using JokesOnYou.Web.Api.Models.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JokesOnYou.Web.Api.Models.Request
{
    public class JokeFiltersDto
    {
        public LikesFilter Likes { get; set; }
        public AuthorFilter Author { get; set; }
        public SearchInTextFilter SearchInText { get; set; }
        public UploadDateFilter Date { get; set; }
    }
}
