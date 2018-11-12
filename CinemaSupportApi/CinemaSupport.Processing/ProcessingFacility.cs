using CinemaSupport.Processing.Interfaces.Actors;
using CinemaSupport.Processing.Services.Actors;
using CinemaSupport.Processing.Interfaces.Cinemas;
using CinemaSupport.Processing.Services.Cinemas;
using CinemaSupport.Processing.Interfaces.Movies;
using CinemaSupport.Processing.Services.Movies;
using CinemaSupport.Processing.Interfaces.ScreeningRooms;
using CinemaSupport.Processing.Services.ScreeningRooms;
using CinemaSupport.Processing.Interfaces.Screenings;
using CinemaSupport.Processing.Services.Screenings;
using CinemaSupport.Processing.Interfaces.Seats;
using CinemaSupport.Processing.Services.Seats;
using CinemaSupport.Processing.Interfaces.Tickets;
using CinemaSupport.Processing.Services.Tickets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Lifetime;

namespace CinemaSupport.Processing
{
    public class ProcessingFacility
    {
        public static void Register(IUnityContainer container)
        {
            container.RegisterType<IActorService, ActorService>(new HierarchicalLifetimeManager());
            container.RegisterType<ICinemaService, CinemaService>(new HierarchicalLifetimeManager());
            container.RegisterType<IMovieService, MovieService>(new HierarchicalLifetimeManager());
            container.RegisterType<IScreeningRoomService, ScreeningRoomService>(new HierarchicalLifetimeManager());
            container.RegisterType<IScreeningService, ScreeningService>(new HierarchicalLifetimeManager());
            container.RegisterType<ISeatService, SeatService>(new HierarchicalLifetimeManager());
            container.RegisterType<ITicketService, TicketService>(new HierarchicalLifetimeManager());
        }
    }
}
