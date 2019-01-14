using CinemaSupport.Processing.Interfaces.Tickets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Routing;
using CinemaSupport.Domain.Models.Tickets;

namespace CinemaSupportApi.Controllers
{
    [RoutePrefix("tickets")]
    public class TicketController : ApiController
    {
        private readonly ITicketService _ticketService;

        public TicketController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        [Route("getallbyactoruniquename")]  
        public IHttpActionResult GetAllActorTickets(string actorName)
        {
            actorName = "Filip";
            var actorTickets = _ticketService.GetAllActorTickets(actorName);
            return Ok(actorTickets);
        }

        [Route("validateticket")]
        [HttpPut]
        public IHttpActionResult ValidateTicket([FromBody]TicketIdModel ticketModel)
        {
            var isValidated = _ticketService.UpdateTicketValidation(ticketModel.TicketId);
            if (!isValidated)
            {
                return NotFound();
            }

            return Ok();
        }

        [Route("buyticket")]
        [HttpPost]
        public IHttpActionResult BuyTicket([FromBody] Ticket ticket)
        {
            var isBought = _ticketService.AddTicket(ticket);
            if(!isBought)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
