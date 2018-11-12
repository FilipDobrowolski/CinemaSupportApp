using CinemaSupport.Data.Interfaces.Repositories;
using CinemaSupport.Processing.Interfaces.Seats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSupport.Processing.Services.Seats
{
    public class SeatService : ISeatService
    {
        private readonly ISeatRepository _seatRepository;

        public SeatService(ISeatRepository seatRepository)
        {
            _seatRepository = seatRepository;
        }
    }
}
