using CinemaSupport.Data.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaSupport.Domain.Models;

namespace CinemaSupport.Data.Repositories
{
    public class ScreeningRoomRepository : IScreeningRoomRepository
    {
        private readonly CinemaSupportContext _context;

        public ScreeningRoomRepository(CinemaSupportContext context)
        {
            _context = context;
        }

        public IQueryable<ScreeningRoom> GetAllScreeningRoomsWithSeats(int cinemaId)
        {

            var screeningRooms = _context.ScreeningRooms.Where(sc => sc.CinemaId == cinemaId).Include("Seats"); // iqueryable

            return screeningRooms;
        }
    }
}
