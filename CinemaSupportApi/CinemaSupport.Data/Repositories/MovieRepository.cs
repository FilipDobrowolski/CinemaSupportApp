﻿using CinemaSupport.Data.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSupport.Data.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly CinemaSupportContext _context;

        public MovieRepository(CinemaSupportContext context)
        {
            _context = context;
        }
    }
}