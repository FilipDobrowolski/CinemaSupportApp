using CinemaSupport.Data.Interfaces.Repositories;
using CinemaSupport.Processing.Interfaces.Tickets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaSupport.Domain.Models.Tickets;

namespace CinemaSupport.Processing.Services.Tickets
{
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository _ticketRepository;

        public TicketService(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public List<Ticket> GetAllActorTickets(string actorName)
        {
            return _ticketRepository.GetAllActorTickets(actorName).Cast<Ticket>().ToList();
        }

        public bool UpdateTicketValidation(int ticketId)
        {
            return _ticketRepository.UpdateTicketValidation(ticketId);
        }
    }    
}
