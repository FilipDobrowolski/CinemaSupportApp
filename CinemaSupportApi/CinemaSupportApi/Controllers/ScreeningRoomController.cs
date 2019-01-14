using CinemaSupport.Processing.Interfaces.ScreeningRooms;
using CinemaSupport.Processing.Services.ScreeningRooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CinemaSupportApi.Controllers
{
    [RoutePrefix("screeningrooms")]
    public class ScreeningRoomController : ApiController
    {
        private readonly IScreeningRoomService _screeningRoomService;

        public ScreeningRoomController(IScreeningRoomService screeningRoomService)
        {
            _screeningRoomService = screeningRoomService;
        }

        [Route("all")]
        public IHttpActionResult GetAllScreeningRoomsWithSeats(int cinemaId = 2)
        {
            cinemaId = 2;
            var screeningRooms = _screeningRoomService.GetAllScreeningRoomsWithSeats(cinemaId);
            return Ok(screeningRooms);
        }
    }
}
