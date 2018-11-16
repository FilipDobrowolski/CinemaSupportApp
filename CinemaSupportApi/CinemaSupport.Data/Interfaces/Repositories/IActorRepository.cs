using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaSupport.Domain.RegisteringModels;
using Microsoft.AspNet.Identity;

namespace CinemaSupport.Data.Interfaces.Repositories
{
    public interface IActorRepository
    {
        Task<IdentityResult> RegisterUser(UserRegisterModel userModel);
    }
}
