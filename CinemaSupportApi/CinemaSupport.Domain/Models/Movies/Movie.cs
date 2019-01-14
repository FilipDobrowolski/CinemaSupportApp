using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSupport.Domain.Models
{
    public class Movie
    {
        public int MovieId { get; set; }

        public string Title { get; set; }

        public int Duration { get; set; }

        public string Picture { get; set; }

        public ICollection<Screening> Screenings { get; set; }
    }
}
