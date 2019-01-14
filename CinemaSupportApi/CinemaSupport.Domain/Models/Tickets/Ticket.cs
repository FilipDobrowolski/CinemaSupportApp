using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaSupport.Domain.Models.Actors;

namespace CinemaSupport.Domain.Models.Tickets
{
    public class Ticket
    {
        public int TicketId { get; set; }

        public int Price { get; set; }

        public TicketType TicketType { get; set; }

        public bool Purchased { get; set; }

        public bool Validated { get; set; }

        public int ScreeningId { get; set; }

        public Screening Screening { get; set; }

        public int SeatId { get; set; }

        public Seat Seat { get; set; }

        public string Actor { get; set; }

        //public string Id { get; set; } 

        //public Actor Actor { get; set; }
    }
}
