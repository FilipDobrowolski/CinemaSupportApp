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
    public class ScreeningRoomController : ApiController
    {
        private readonly IScreenigRoomService _screeningRoomService;

        public ScreeningRoomController(IScreenigRoomService screeningRoomService)
        {
            _screeningRoomService = screeningRoomService;
        }
    }
}
