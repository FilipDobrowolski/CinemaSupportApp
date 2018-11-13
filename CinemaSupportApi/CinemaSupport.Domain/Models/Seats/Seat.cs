using CinemaSupport.Domain.Models.Tickets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSupport.Domain.Models
{
    public class Seat
    {
        public Guid ID { get; set; }

        public int Number { get; set; }

        public bool State { get; set; }

        public Guid ScreeningRoomID { get; set; }

        public ScreeningRoom ScreeningRoom { get; set; }

        public ICollection<Ticket> Tickets { get; set; }


    }
}
