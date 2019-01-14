using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaSupport.Domain.Models;

namespace CinemaSupport.Processing.Interfaces.Seats
{
    public interface ISeatService
    {
        List<Seat> GetAllScreeningAvailableSeats(int screeningId, int screeningRoomId);
    }
}
