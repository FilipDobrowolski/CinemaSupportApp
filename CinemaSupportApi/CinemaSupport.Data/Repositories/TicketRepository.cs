using CinemaSupport.Data.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using CinemaSupport.Domain.Models.Tickets;

namespace CinemaSupport.Data.Repositories
{
    public class TicketRepository : ITicketRepository
    {
        private readonly CinemaSupportContext _context;

        public TicketRepository(CinemaSupportContext context)
        {
            _context = context;
        }

        public IQueryable<Ticket> GetAllActorTickets(string actorName)
        {
            return _context.Tickets.Where(t => t.Actor == actorName);
        }

        public bool UpdateTicketValidation(int ticketId)
        {
            bool isTicketExist = _context.Tickets.Any(t => t.TicketId == ticketId);

            if (isTicketExist)
            {
                var ticket = _context.Tickets.Single(t => t.TicketId == ticketId);
                ticket.Validated = true;
                _context.SaveChanges();
                return true;
            }

            return false;
        }

        public bool AddTicket(Ticket ticket)
        {
            var nextTicketIndex = _context.Tickets.ToList().Count;
            ticket.TicketId = nextTicketIndex;
            ticket.Price = ticket.TicketType == TicketType.Normal ? 20 : 15;
            ticket.Purchased = true;
            ticket.Validated = false;

            _context.Tickets.Add(ticket);
            _context.SaveChanges();

            return true;
        }
    }
}
