using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JokesOnYou.Web.Api.Models.Request.Query
{
    public class PaginationParameters //: IValidatableObject
    {
        const int maxPageSize = 50;
        private int _pageSize = 10;

        [Range(1, UInt16.MaxValue, ErrorMessage = "PageNumber cannot be zero/negative or more than 65535")]
        public int PageNumber { get; set; } = 1;

        [Range(1, UInt16.MaxValue, ErrorMessage = "PageSize cannot be zero/negative or more than 65535")]
        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }
    }
}
