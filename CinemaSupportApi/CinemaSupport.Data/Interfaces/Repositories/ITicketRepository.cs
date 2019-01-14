using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaSupport.Domain.Models.Tickets;

namespace CinemaSupport.Data.Interfaces.Repositories
{
    public interface ITicketRepository
    {
        IQueryable<Ticket> GetAllActorTickets(string actorName);

        bool UpdateTicketValidation(int ticketId);

        bool AddTicket(Ticket ticket);

    }
}
