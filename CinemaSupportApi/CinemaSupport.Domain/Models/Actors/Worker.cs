using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace CinemaSupport.Domain.Models.Actors
{
    public class Worker 
    {
        public new ActorRoles Role
        {
            set => value = ActorRoles.Worker;
        }
    }
}
