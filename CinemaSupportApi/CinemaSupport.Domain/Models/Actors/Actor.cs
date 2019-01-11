﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using CinemaSupport.Domain.Models.Actors;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CinemaSupport.Domain.Models
{
    public class Actor : IdentityUser
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public ActorRoles Role { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<Actor> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public string GetUserRole => "Admin";
    }
}
