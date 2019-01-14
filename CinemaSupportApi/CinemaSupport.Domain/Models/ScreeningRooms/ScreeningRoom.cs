using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSupport.Domain.Models
{
    public class ScreeningRoom
    {
        public int ScreeningRoomId { get; set; }

        public string Name { get; set; }

        public int Floor { get; set; }

        public int CinemaId { get; set; }

        public Cinema Cinema { get; set; }

        public ICollection<Seat> Seats { get; set; }

        public ICollection<Screening> Screenings { get; set; }
    }
}
