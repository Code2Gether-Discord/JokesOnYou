using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace JokesOnYou.Web.Api.Models.Interfaces
{

    //When adding a JokesFilter dont forget to Add it to the JokeFiltersDto, and JokesService.BuildFiltersList();
    public interface IFilter
    {
        public Expression<Func<Joke, bool>> Filter();
    }
}
