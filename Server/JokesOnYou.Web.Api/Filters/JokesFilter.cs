using System;

namespace JokesOnYou.Web.Api.Filters
{
    public class JokesFilter
    {
        private int minLikes = 0;
        private int maxLikes = int.MaxValue;
        private int minDislikes = 0;
        private int maxDislikes = int.MaxValue;
        private DateTime maxUploadDate = DateTime.MinValue;
        private DateTime minUploadDate = DateTime.MaxValue;

        public string AuthorId { get; set; }
        public int Likes { get; set; }
        public int MinLikes { get => minLikes; set => minLikes = (value > MaxLikes) ? MaxLikes : value; }
        public int MaxLikes { get => maxLikes; set => maxLikes = (value < MinLikes) ? MinLikes : value; }
        public int Dislikes { get; set; } = 0;
        public int MinDislikes { get => minDislikes; set => minDislikes = (value > MaxDislikes) ? MaxDislikes : value; }
        public int MaxDislikes { get => maxDislikes; set => maxDislikes = (value < MinDislikes) ? MinDislikes : value; }
        public DateTime UploadDate { get; set; }
        public DateTime MinUploadDate { get => minUploadDate; set => minUploadDate = (value > MaxUploadDate) ? MaxUploadDate : value; }
        public DateTime MaxUploadDate { get => maxUploadDate; set => maxUploadDate = (value < MinUploadDate) ? MinUploadDate : value; }
    }
}
