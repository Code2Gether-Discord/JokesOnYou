﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JokesOnYou.Web.Api.Models.Request
{
    public class JokesFilterDto
    {
        public string AuthorId { get; set; }
        public string Text { get; set; }
        public int MinimumLikes { get; set; } = int.MinValue;
        public int MaximumLikes { get; set; } = int.MaxValue;
        public DateTime MinimumDate { get; set; } = DateTime.MinValue;
        public DateTime MaximumDate { get; set; } = DateTime.MaxValue;
    }
}