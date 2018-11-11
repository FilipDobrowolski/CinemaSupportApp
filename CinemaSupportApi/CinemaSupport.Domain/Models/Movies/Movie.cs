using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSupport.Domain.Models
{
    public class Movie
    {
        public Guid ID { get; set; }

        public DateTime Created { get; set; }

        public string Title { get; set; }

        public int Duration { get; set; }

        public ICollection<Screening> Screenings { get; set; }
    }
}
