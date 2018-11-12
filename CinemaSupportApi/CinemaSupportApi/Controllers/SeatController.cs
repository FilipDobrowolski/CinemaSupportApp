using CinemaSupport.Processing.Interfaces.Seats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CinemaSupportApi.Controllers
{
    public class SeatController : ApiController
    {
        private readonly ISeatService _seatService;

        public SeatController(ISeatService seatService)
        {
            _seatService = seatService;
        }
    }
}
