using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSupport.Domain.Models
{
    public class Cinema
    {
        public int CinemaId { get; set; }

        public string Name { get; set; }

        public string City { get; set; }

        public ICollection<ScreeningRoom> ScreeningRooms { get; set; }


    }
}
