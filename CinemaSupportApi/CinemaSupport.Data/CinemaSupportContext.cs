using CinemaSupport.Domain;
using CinemaSupport.Domain.Models;
using CinemaSupport.Domain.Models.Actors;
using CinemaSupport.Domain.Models.Tickets;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CinemaSupport.Data
{
    [DbConfigurationType(typeof(CinemaSupportDbConfig))]

    public class CinemaSupportContext : IdentityDbContext<Actor>
    {
        public CinemaSupportContext() : base(ConfigurationManager.ConnectionStrings["CinemaSupportContext"].ConnectionString){ }

        public CinemaSupportContext(string connectionString) : base(connectionString) { }


        public DbSet<Cinema> Cinemas { get; set; }

        public DbSet<Movie> Movies { get; set; }

        public DbSet<ScreeningRoom> ScreeningRooms { get; set; }

        public DbSet<Screening> Screenings { get; set; }

        public DbSet<Seat> Seats { get; set; }

        public DbSet<Ticket> Tickets { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            //initializer todo
            Database.SetInitializer<CinemaSupportContext>(new DropCreateDatabaseIfModelChanges<CinemaSupportContext>());
            modelBuilder.Conventions.Add<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Add<OneToManyCascadeDeleteConvention>();
            #region Actors
            //modelBuilder.Entity<Artist>().ToTable("Artists");
            //modelBuilder.Entity<Actor>()
            //    .HasMany(a => a.Tickets)
            //    .WithOptional()
            //    .HasForeignKey(t => t.Id);
            #endregion

            #region Cinemas

            modelBuilder.Entity<Cinema>().ToTable("Cinemas");

            modelBuilder.Entity<Cinema>()
                .HasMany(c => c.ScreeningRooms)
                .WithRequired()
                .HasForeignKey(sr => sr.CinemaId);
               

            #endregion

            #region Movies
            modelBuilder.Entity<Movie>().ToTable("Movies");

            modelBuilder.Entity<Movie>()
                .HasMany(m => m.Screenings)
                .WithRequired()
                .HasForeignKey(sc => sc.MovieId);


            #endregion

            #region ScreeningRooms
            modelBuilder.Entity<ScreeningRoom>().ToTable("ScreeningRooms");

            modelBuilder.Entity<ScreeningRoom>()
                .HasMany(sc => sc.Seats)
                .WithRequired()
                .HasForeignKey(s => s.ScreeningRoomId)
                .WillCascadeOnDelete(true); ;

            modelBuilder.Entity<ScreeningRoom>()
                .HasMany(sc => sc.Screenings)
                .WithRequired()
                .HasForeignKey(s => s.ScreeningRoomId)
                .WillCascadeOnDelete(true); ;


            #endregion

            #region Screenings
            modelBuilder.Entity<Screening>().ToTable("Screenings");

            modelBuilder.Entity<Screening>()
                .HasMany(s => s.Tickets)
                .WithRequired()
                .HasForeignKey(t => t.ScreeningId)
                .WillCascadeOnDelete(true); ;
            #endregion

            #region Seats
            modelBuilder.Entity<Seat>().ToTable("Seats");

            modelBuilder.Entity<Seat>()
                .HasMany(s => s.Tickets)
                .WithRequired()
                .HasForeignKey(t => t.SeatId)
                .WillCascadeOnDelete(true); ;

            #endregion

            #region Tickets
            modelBuilder.Entity<Ticket>().ToTable("Tickets");
            #endregion


            base.OnModelCreating(modelBuilder);
        }

        public static CinemaSupportContext Create()
        {
            return new CinemaSupportContext(ConfigurationManager.ConnectionStrings["CinemaSupportContext"]
                .ConnectionString);
        }
    }
}
