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
        public int ScreeningId { get; set; }

        public bool Status { get; set; }

        public string ScreeningDate { get; set; }

        public int ScreeningRoomId { get; set; }

        public ScreeningRoom ScreeningRoom { get; set; }

        public int MovieId { get; set; }

        public Movie Movie { get; set; }

        public ICollection<Ticket> Tickets { get; set; }

    }
}
