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

        [RegularExpression(@"^\d*[1-9]\d*$", ErrorMessage = "PageNumber cannot be zero or negative")]
        public int PageNumber { get; set; } = 1;

        [RegularExpression(@"^\d*[1-9]\d*$", ErrorMessage = "PageSize cannot be zero or negative")]
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
