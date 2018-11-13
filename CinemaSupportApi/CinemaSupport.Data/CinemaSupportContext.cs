using CinemaSupport.Domain;
using CinemaSupport.Domain.Models;
using CinemaSupport.Domain.Models.Actors;
using CinemaSupport.Domain.Models.Tickets;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaSupport.Data
{
    [DbConfigurationType(typeof(CinemaSupportDbConfig))]

    public class CinemaSupportContext : DbContext
    {
        public CinemaSupportContext() { }

        public CinemaSupportContext(string connectionString) : base(connectionString) { }

        public DbSet<Actor> Actors { get; set; }

        public DbSet<Client> Clients { get; set; }

        public DbSet<Worker> Workers { get; set; }

        public DbSet<Artist> Artists { get; set; }

        public DbSet<Cinema> Cinemas { get; set; }

        public DbSet<Movie> Movies { get; set; }

        public DbSet<ScreeningRoom> ScreeningRooms { get; set; }

        public DbSet<Screening> Screenings { get; set; }

        public DbSet<Seat> Seats { get; set; }

        public DbSet<Ticket> Tickets { get; set; }

        public DbSet<SalesHistory> SalesHistories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //initializer todo
            Database.SetInitializer<CinemaSupportContext>(new DropCreateDatabaseIfModelChanges<CinemaSupportContext>());

            #region Actors
            modelBuilder.Entity<Actor>().ToTable("Actors");
            #endregion

            #region Clients
            modelBuilder.Entity<Client>().ToTable("Clients");
            #endregion

            #region Workers
            modelBuilder.Entity<Worker>().ToTable("Workers");
            #endregion

            #region Artists
            modelBuilder.Entity<Artist>().ToTable("Artists");
            #endregion

            #region Cinemas

            modelBuilder.Entity<Cinema>().ToTable("Cinemas");

            modelBuilder.Entity<Cinema>()
                .HasMany(c => c.ScreeningRooms)
                .WithRequired()
                .HasForeignKey(sr => sr.CinemaID);

            #endregion

            #region Movies
            modelBuilder.Entity<Movie>().ToTable("Movies");
            #endregion

            #region ScreeningRooms
            modelBuilder.Entity<ScreeningRoom>().ToTable("ScreeningRooms");

            //modelBuilder.Entity<ScreeningRoom>()
            //    .HasMany(sc => sc.Seats)
            //    .WithRequired()
            //    .HasForeignKey(s => s.ScreeningRoomID);
            #endregion

            #region Screenings
            modelBuilder.Entity<Screening>().ToTable("Screenings");

            //modelBuilder.Entity<Screening>()
            //    .HasMany(s => s.Tickets)
            //    .WithOptional()
            //    .HasForeignKey(t => t.ScreeningID);
            #endregion
            
            #region Seats
            modelBuilder.Entity<Seat>().ToTable("Seats");

            //modelBuilder.Entity<Seat>()
            //    .HasMany(s => s.Tickets)
            //    .WithOptional()
            //    .HasForeignKey(t => t.SeatID);

            #endregion

            #region Tickets
            modelBuilder.Entity<Ticket>().ToTable("Tickets");
            #endregion


            base.OnModelCreating(modelBuilder);
        }
    }
}
