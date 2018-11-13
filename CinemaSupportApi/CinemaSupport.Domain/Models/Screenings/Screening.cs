using CinemaSupport.Domain.Models.Tickets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSupport.Domain.Models
{
    public class Screening
    {
        public Guid ID { get; set; }

        public bool Status { get; set; }

        public DateTime ScreeningDate { get; set; }


        public Guid ScreeningRoomID { get; set; }

        public ScreeningRoom ScreeningRoom { get; set; }

        public Guid MovieID { get; set; }

        public Movie Movie { get; set; }

        public ICollection<Ticket> Tickets { get; set; }

    }
}
