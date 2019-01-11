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
        [Authorization]
        [Route("")]
        public IHttpActionResult GetAllMovies()
        {
            var availableMovies = new List<Movie>
        {
            new Movie()
            {
                ID = Guid.NewGuid(),
                Created = DateTime.Today.Date,
                Title = "Film1",
                Duration = 60
            },
            new Movie()
            {
                ID = Guid.NewGuid(),
                Created = DateTime.Today.Date,
                Title = "Film2",
                Duration = 120
            },
            new Movie()
            {
                ID = Guid.NewGuid(),
                Created = DateTime.Today.Date,
                Title = "Film3",
                Duration = 180
            },
            new Movie()
            {
                ID = Guid.NewGuid(),
                Created = DateTime.Today.Date,
                Title = "Film4",
                Duration = 20
            },
            new Movie()
            {
                ID = Guid.NewGuid(),
                Created = DateTime.Today.Date,
                Title = "Film5",
                Duration = 10
            },
        };
            return Ok(availableMovies);
        }
    }
}
