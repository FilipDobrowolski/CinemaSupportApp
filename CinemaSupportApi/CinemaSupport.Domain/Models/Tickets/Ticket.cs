using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSupport.Domain.Models.Tickets
{
    public class Ticket
    {

        public bool Reservation { get; set; }

        public int Price { get; set; }

        public Guid ID { get; set; }

        public Guid ScreeningID { get; set; }

        public Guid CinemaID { get; set; }

        public Guid ScreeningRoomID { get; set; }

        public Guid SeatID { get; set; }

        public Guid ClientID { get; set; }

        

    }
}
