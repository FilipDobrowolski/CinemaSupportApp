using CinemaSupport.Processing.Interfaces.Seats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CinemaSupportApi.Controllers
{
    [RoutePrefix("seats")]
    [Authorize]
    public class SeatController : ApiController
    {
        private readonly ISeatService _seatService;

        public SeatController(ISeatService seatService)
        {
            _seatService = seatService;
        }

        [Route("screeningseats")]
        public IHttpActionResult GetScreeningAvailableSeats(int screeningId, int screeningRoomId)
        {
            //screeningId = 7;
            //screeningRoomId = 5;
            var seats = _seatService.GetAllScreeningAvailableSeats(screeningId, screeningRoomId);

            return Ok(seats);
        }
    }
}
