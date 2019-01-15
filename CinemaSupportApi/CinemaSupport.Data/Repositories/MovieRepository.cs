using CinemaSupport.Data.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using CinemaSupport.Domain.Models;

namespace CinemaSupport.Data.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly CinemaSupportContext _context;

        public MovieRepository(CinemaSupportContext context)
        {
            _context = context;
        }

        [Route("all")]
        public IQueryable<Movie> GetMoviesWithScreenings()
        {
            return _context.Movies.Include(m => m.Screenings);
        }

    }
}
