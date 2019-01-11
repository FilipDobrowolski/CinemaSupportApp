using CinemaSupport.Processing.Interfaces.Cinemas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CinemaSupportApi.Controllers
{

    public class CinemaController : ApiController
    {
        private readonly ICinemaService _cinemaService;
        
        public CinemaController(ICinemaService cinemaService)
        {
            _cinemaService = cinemaService;
        }
    }
}
