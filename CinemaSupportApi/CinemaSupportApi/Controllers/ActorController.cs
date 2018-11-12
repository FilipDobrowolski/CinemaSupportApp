using CinemaSupport.Processing.Services.Actors;
using CinemaSupport.Processing.Interfaces.Actors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CinemaSupportApi.Controllers
{
    public class ActorController : ApiController
    {
        private readonly IActorService _actorService;

        public ActorController(IActorService actorService)
        {
            _actorService = actorService;
        }
    }
}
