using CinemaSupport.Data;
using CinemaSupport.Processing;
using CinemaSupportApi.Authentication;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Web;
using CinemaSupport.Domain.Models;
using Unity;
using Unity.Injection;
using Microsoft.AspNet.Identity.EntityFramework;
using Unity.Lifetime;
using CinemaSupportApi.Controllers;
using CinemaSupport.Data.Interfaces.Repositories;
using System.Data.Entity;
using CinemaSupport.Data.Repositories;

namespace CinemaSupportApi
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below.
            // Make sure to add a Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your type's mappings here.
            // container.RegisterType<IProductRepository, ProductRepository>();
            DataFacility.Register(container);
            container.RegisterType<DbContext, CinemaSupportContext>(new TransientLifetimeManager());
            container.RegisterType<IUserStore<Actor>, UserStore<Actor>>(new TransientLifetimeManager());
            container.RegisterType<ApplicationUserManager>(new TransientLifetimeManager()); 
            container.RegisterType<AccountController>(new TransientLifetimeManager(), new InjectionConstructor(typeof(IActorRepository), typeof(ApplicationUserManager)));

            //container.RegisterType<IAuthenticationManager>(
            //    new InjectionFactory(c => HttpContext.Current.GetOwinContext().Authentication));

            //container.RegisterType<IUserStore<Actor>, UserStore<Actor>>(new HierarchicalLifetimeManager());
            //container.RegisterType<ApplicationSignInManager>(new HierarchicalLifetimeManager());
            //container.RegisterType<ApplicationUserManager>(new HierarchicalLifetimeManager());

            ProcessingFacility.Register(container);

        }

        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }
    }
}