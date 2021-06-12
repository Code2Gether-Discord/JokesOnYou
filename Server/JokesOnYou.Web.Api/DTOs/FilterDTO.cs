using System;

namespace JokesOnYou.Web.Api.DTOs
{
    public enum ComparisonMode
    {
        Equals,
        Greather,
        Lower,
        GreatherEquals,
        LowerEquals,
        NotEquals
    }

    public class FilterDTO
    {
        public JokeAuthorDto Author { get; set; }
        public int Likes { get; set; } = -1;
        public ComparisonMode ComparisonModeLikes { get; set; }
        public int Dislikes { get; set; } = -1;
        public ComparisonMode ComparisonModeDislikes { get; set; }
        public DateTime UploadDate { get; set; }
        public ComparisonMode ComparisonModeUploadDate { get; set; }
    }
}
