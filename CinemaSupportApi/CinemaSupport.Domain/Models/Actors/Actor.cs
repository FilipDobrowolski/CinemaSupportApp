using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using CinemaSupport.Domain.Models.Actors;
using CinemaSupport.Domain.Models.Tickets;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CinemaSupport.Domain.Models
{
    public class Actor : IdentityUser
    {

        public string Name { get; set; }

        public string Surname { get; set; }

        public ActorRoles Role { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<Actor> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }

        public string GetUserRole => "Admin";

        public ICollection<Ticket> Tickets { get; set; }
    }
}
