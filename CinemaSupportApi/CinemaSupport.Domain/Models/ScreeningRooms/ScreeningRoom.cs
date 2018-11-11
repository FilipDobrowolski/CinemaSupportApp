using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSupport.Domain.Models
{
    public class ScreeningRoom
    {
        public Guid ID { get; set; }

        public string Name { get; set; }

        public int Floor { get; set; }


        public Guid CinemaID { get; set; }

        public ICollection<Seat> Seats { get; set; }

        public ICollection<Screening> Screenings { get; set; }
    }
}
