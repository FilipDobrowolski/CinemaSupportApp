using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaSupport.Domain.Models.Tickets;

namespace CinemaSupport.Domain.Models.Actors
{
    public class Client : Actor
    {
        public ICollection<Ticket> Tickets;

    }
}
