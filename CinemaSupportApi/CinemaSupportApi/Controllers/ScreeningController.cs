using CinemaSupport.Processing.Interfaces.Screenings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CinemaSupportApi.Controllers
{
    public class ScreeningController : ApiController
    {
        private readonly IScreeningService _screeningService;

        public ScreeningController(IScreeningService screeningService)
        {
            _screeningService = screeningService;
        }
    }
}
