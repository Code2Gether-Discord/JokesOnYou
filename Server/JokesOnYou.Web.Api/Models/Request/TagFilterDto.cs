using System;
using JokesOnYou.Web.Api.Models.Request.Query;

namespace JokesOnYou.Web.Api.Models.Request
{
    public class TagFilterDto : PaginationParameters
    {
        public string OwnerId { get; set; }

        public int MinimumLikes { get; set; } = int.MinValue;

        public int MaximumLikes { get; set; } = int.MaxValue;

        public DateTime MinimumDate { get; set; } = DateTime.MinValue;

        public DateTime MaximumDate { get; set; } = DateTime.MaxValue;

        public string SearchText { get; set; } = string.Empty;
    }
}
