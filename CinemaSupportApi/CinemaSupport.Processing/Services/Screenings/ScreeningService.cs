using CinemaSupport.Data.Interfaces.Repositories;
using CinemaSupport.Processing.Interfaces.Screenings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSupport.Processing.Services.Screenings
{
    public class ScreeningService : IScreeningService
    {
        private readonly IScreeningRepository _screeningRepository;

        public ScreeningService(IScreeningRepository screeningRepository)
        {
            _screeningRepository = screeningRepository;
        }
    }
}
