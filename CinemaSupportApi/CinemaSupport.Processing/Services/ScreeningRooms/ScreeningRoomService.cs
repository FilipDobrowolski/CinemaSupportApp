using CinemaSupport.Data.Interfaces.Repositories;
using CinemaSupport.Processing.Interfaces.ScreeningRooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSupport.Processing.Services.ScreeningRooms
{
    public class ScreeningRoomService : IScreeningRoomService
    {
        private readonly IScreeningRoomRepository _screeningRepository;

        public ScreeningRoomService(IScreeningRoomRepository screeningRepository)
        {
            _screeningRepository = screeningRepository;
        }
    }
}
