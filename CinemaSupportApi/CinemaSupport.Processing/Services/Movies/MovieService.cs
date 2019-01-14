using CinemaSupport.Data.Interfaces.Repositories;
using CinemaSupport.Processing.Interfaces.Movies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaSupport.Domain.Models;

namespace CinemaSupport.Processing.Services.Movies
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public IList<Movie> GetMoviesWithScreenings()
        {
            return _movieRepository.GetMoviesWithScreenings().Cast<Movie>().ToList();
        }
    }
}
