using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaSupport.Domain.Models;
using Microsoft.AspNet.Identity;

namespace CinemaSupport.Data.Repositories
{
    public class CustomUserStore : IUserStore<Actor>, IUserPasswordStore<Actor>
    {
        private IDbSet<Actor> _users;
        private CinemaSupportContext _context;

        public CustomUserStore(CinemaSupportContext context)
        {
            _users = context.Users;
            _context = context;
        }
        public System.Threading.Tasks.Task CreateAsync(Actor user)
        {
            user.Id = Guid.NewGuid().ToString();
            _users.Add(user);
            return _context.SaveChangesAsync();
        }

        public System.Threading.Tasks.Task DeleteAsync(Actor user)
        {
            _users.Remove(user);
            return _context.SaveChangesAsync();
        }

        public System.Threading.Tasks.Task<Actor> FindByIdAsync(string userId)
        {
            return _users.FirstOrDefaultAsync(x => x.Id == userId);
        }

        public System.Threading.Tasks.Task<Actor> FindByNameAsync(string userName)
        {
            return _users.FirstOrDefaultAsync(x => x.UserName == userName);
        }

        public System.Threading.Tasks.Task UpdateAsync(Actor user)
        {
            var current = _users.Find(user.Id);
            _context.Entry<Actor>(current).CurrentValues.SetValues(user);
            return _context.SaveChangesAsync();
        }
        public Task AddToRoleAsync(Actor user, string roleName)
        {
            var roleToAdd = _context.Roles.FirstOrDefault(r => r.Name == roleName);
            //user.Roles.Add(roleToAdd);
            return _context.SaveChangesAsync();
        }

        public Task RemoveFromRoleAsync(Actor user, string roleName)
        {
            throw new NotImplementedException();
        }

        public Task<IList<string>> GetRolesAsync(Actor user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsInRoleAsync(Actor user, string roleName)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _users = null;
            _context.Dispose();
        }

        public Task SetPasswordHashAsync(Actor user, string passwordHash)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetPasswordHashAsync(Actor user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> HasPasswordAsync(Actor user)
        {
            throw new NotImplementedException();
        }
    }
}
