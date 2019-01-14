using CinemaSupport.Data.Interfaces.Repositories;
using CinemaSupport.Processing.Interfaces.Seats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaSupport.Domain.Models;

namespace CinemaSupport.Processing.Services.Seats
{
    public class SeatService : ISeatService
    {
        private readonly ISeatRepository _seatRepository;

        public SeatService(ISeatRepository seatRepository)
        {
            _seatRepository = seatRepository;
        }

        public List<Seat> GetAllScreeningAvailableSeats(int screeningId, int screeningRoomId)
        {
            var seats = _seatRepository.GetAllScreeningAvailableSeats(screeningId, screeningRoomId).Cast<Seat>().ToList();

            return seats;
        }
    }
}
