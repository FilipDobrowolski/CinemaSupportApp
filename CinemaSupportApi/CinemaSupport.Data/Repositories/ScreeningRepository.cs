using CinemaSupport.Data.Interfaces.Repositories;
using CinemaSupport.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSupport.Data.Repositories
{
    public class ScreeningRepository : IScreeningRepository
    {
        private readonly CinemaSupportContext _context;

        public ScreeningRepository(CinemaSupportContext context)
        {
            _context = context;
        }

        public List<Screening> GetScreenings()
        {
            return _context.Screenings.Include("Tickets").ToList();
        }
    }
}
