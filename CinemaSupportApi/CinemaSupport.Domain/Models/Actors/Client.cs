using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using CinemaSupport.Domain.Models.Tickets;
using Microsoft.AspNet.Identity;

namespace CinemaSupport.Domain.Models.Actors
{
    public class Client
    {
        public ICollection<Ticket> Tickets;

        public new ActorRoles Role
        {
            set => value = ActorRoles.Client;
        }
    }
}
