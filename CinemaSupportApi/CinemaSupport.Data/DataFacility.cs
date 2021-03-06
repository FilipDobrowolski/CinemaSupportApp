﻿using CinemaSupport.Data.Interfaces.Repositories;
using CinemaSupport.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaSupport.Domain.Models;
using Microsoft.AspNet.Identity;
using Unity;
using Unity.Injection;
using Unity.Lifetime;

namespace CinemaSupport.Data
{
    public class DataFacility
    {
        public static void Register(IUnityContainer container)
        {
            container.RegisterType<CinemaSupportContext>(new TransientLifetimeManager(),
                new InjectionFactory(unity => new CinemaSupportContext()));
            container.RegisterType<IActorRepository, ActorRepository>(new TransientLifetimeManager());
            container.RegisterType<ICinemaRepository, CinemaRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IMovieRepository, MovieRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IScreeningRepository, ScreeningRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IScreeningRoomRepository, ScreeningRoomRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<ISeatRepository, SeatRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<ITicketRepository, TicketRepository>(new HierarchicalLifetimeManager());
            //container.RegisterType<UserManager<Actor>>(new SingletonLifetimeManager());
            container.RegisterType<CustomUserStore>(new HierarchicalLifetimeManager());
        }
    }
}
