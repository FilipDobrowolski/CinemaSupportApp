using CinemaSupport.Data.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSupport.Data.Repositories
{
    public class TicketRepository : ITicketRepository
    {
        private readonly CinemaSupportContext _context;

        public TicketRepository(CinemaSupportContext context)
        {
            _context = context;
        }
    }
}
