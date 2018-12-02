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

        public bool Reservation { get; set; }

        public int Price { get; set; }

        public Guid ID { get; set; }

        public Guid ScreeningID { get; set; }

        public Screening Screening { get; set; }


    }
}
