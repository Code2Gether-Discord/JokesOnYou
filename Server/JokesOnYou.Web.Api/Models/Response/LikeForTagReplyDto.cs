using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace JokesOnYou.Web.Api.Models.Response
{
    public class LikeForTagReplyDto
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public int Likes { get; set; }
    }
}
