using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaSupport.Domain.Models.Tickets;

namespace CinemaSupport.Processing.Interfaces.Tickets
{
    public interface ITicketService
    {
        List<Ticket> GetAllActorTickets(string actorName);
        bool UpdateTicketValidation(int ticketId);
    }
}
