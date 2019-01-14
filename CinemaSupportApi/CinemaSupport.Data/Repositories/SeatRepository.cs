using CinemaSupport.Data.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaSupport.Domain.Models;
using Unity.Interception.Utilities;

namespace CinemaSupport.Data.Repositories
{
    public class SeatRepository : ISeatRepository
    {
        private readonly CinemaSupportContext _context;

        public SeatRepository(CinemaSupportContext context)
        {
            _context = context;
        }

        public IQueryable<Seat> GetAllScreeningAvailableSeats(int screeningId, int screeningRoomId)
        {
            List<int> ticketSeatIdTable = new List<int>();
            List<int> purchsedSeats = new List<int>();

            var screening = _context.Screenings.SingleOrDefault(x => x.ScreeningId == screeningId);

            var screeningRoomWithSeats = _context.ScreeningRooms
                .Include("Seats").SingleOrDefault(x => x.ScreeningRoomId == screening.ScreeningRoomId);

            var tickets = _context.Tickets.Where(t => t.ScreeningId == screeningId);

            tickets.ForEach(t => ticketSeatIdTable.Add(t.SeatId));
            screeningRoomWithSeats.Seats.ForEach(s => purchsedSeats.Add(s.SeatId));

            var availableSeatsIds = purchsedSeats.Except(ticketSeatIdTable);

            return _context.Seats.Where(s => availableSeatsIds.Contains(s.SeatId));
        }
    }
}
