using CinemaSupport.Processing.Interfaces.Screenings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CinemaSupport.Data.Interfaces.Repositories;

namespace CinemaSupportApi.Controllers
{
    [RoutePrefix("screenings")]
    public class ScreeningController : ApiController
    {
        private readonly IScreeningService _screeningService;
        private readonly IScreeningRepository _screeningRepository;

        public ScreeningController(IScreeningService screeningService, IScreeningRepository screeningRepository)
        {
            _screeningService = screeningService;
            _screeningRepository = screeningRepository;
        }

        [Route("")]
        public IHttpActionResult GetScreenings()
        {
            var t = _screeningRepository.GetScreenings();
            return Ok(t);
        }

    }
}
