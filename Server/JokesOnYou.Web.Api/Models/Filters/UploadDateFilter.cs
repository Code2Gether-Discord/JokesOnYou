using JokesOnYou.Web.Api.Models.Interfaces;
using System;
using System.Linq.Expressions;

namespace JokesOnYou.Web.Api.Models.Filters
{
    public class UploadDateFilter : IFilter
    {
        public DateTime FromDate { get; set; } = DateTime.MinValue;
        public DateTime EndDate { get; set; } = DateTime.Now;

        public Expression<Func<Joke, bool>> Filter() => j => j.UploadDate >= FromDate && j.UploadDate <= EndDate;
    }
}
