﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaSupport.Domain.Models;

namespace CinemaSupport.Data.Interfaces.Repositories
{
    public interface IScreeningRoomRepository
    {
        IQueryable<ScreeningRoom> GetAllScreeningRoomsWithSeats(int cinemaId);
    }
}
