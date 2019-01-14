using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaSupport.Domain.Models;

namespace CinemaSupport.Processing.Interfaces.Movies
{
    public interface IMovieService
    {
        IList<Movie> GetMoviesWithScreenings();
    }
}
