using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JokesOnYou.Web.Api.Models.Request.Query
{
    public abstract class PaginationQuery : IValidatableObject
    {
        const int maxPageSize = 50;
        private int _pageSize = 10;

        public int PageNumber { get; set; } = 1;
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

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {

            if (PageNumber < 1)
            {
                yield return new ValidationResult(
                $"Parameter cannot be zero or negative.",
                new[] { nameof(PageNumber) });
            }
            else if(PageSize < 1)
            {
                yield return new ValidationResult(
                $"Parameter cannot be zero or negative.",
                new[] { nameof(PageSize) });
            }
        }
    }
}
