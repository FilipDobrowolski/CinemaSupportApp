using CinemaSupport.Data.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaSupport.Domain.Models;
using CinemaSupport.Domain.RegisteringModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CinemaSupport.Data.Repositories
{
    public class ActorRepository : IActorRepository
    {
        private readonly CinemaSupportContext _context;

        private UserManager<Actor> _userManager;


        public ActorRepository(CinemaSupportContext context)
        {
            _context = context; //CinemaSupportContext.Create();
        }

        public async Task<IdentityResult> RegisterUser(UserRegisterModel userModel, UserManager<Actor> userManager)
        {
            Actor user = new Actor()
            {
                UserName = userModel.UserName
            };

            var result = await userManager.CreateAsync(user, userModel.Password);
            _context.SaveChanges();
            return result;
        }

        public async Task<IdentityUser> FindUser(string userName, string password)
        {
            IdentityUser user = await _userManager.FindAsync(userName, password);

            return user;
        }

        public void Dispose()
        {
            _context.Dispose();
            _userManager.Dispose();

        }
    }
}
