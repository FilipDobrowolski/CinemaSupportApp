using CinemaSupport.Processing.Interfaces.Movies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CinemaSupport.Domain.Models;
using CinemaSupportApi.Authentication;

namespace CinemaSupportApi.Controllers
{
    [RoutePrefix("movies")]
    public class MovieController : ApiController
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }
        //[Authorization]
        [Route("")]
        public IHttpActionResult GetAllMovies()
        {
            var availableMovies = _movieService.GetMoviesWithScreenings();
            return Ok(availableMovies);
        }
    }
}
