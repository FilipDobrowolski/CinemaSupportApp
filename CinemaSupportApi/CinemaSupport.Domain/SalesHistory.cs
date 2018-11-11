using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSupport.Domain
{
    public class SalesHistory
    {
        public Guid SeatID { get; set; }

        public Guid ClientID { get; set; }

        public Guid ScreeningID { get; set; }

    }
}
