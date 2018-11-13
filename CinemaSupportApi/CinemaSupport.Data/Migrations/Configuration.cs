using CinemaSupport.Domain.Models;

namespace CinemaSupport.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CinemaSupport.Data.CinemaSupportContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CinemaSupport.Data.CinemaSupportContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            //cinemas ids
            var cinemaIdA = Guid.NewGuid();
            var cinemaIdB = Guid.NewGuid();
            var cinemaIdC = Guid.NewGuid();

            //seats ids
            var screeningRoomIdACinemaA = Guid.NewGuid();
            var screeningRoomIdBCinemaA = Guid.NewGuid();
            var screeningRoomIdCCinemaA = Guid.NewGuid();

            var screeningRoomIdACinemaB = Guid.NewGuid();
            var screeningRoomIdBCinemaB = Guid.NewGuid();
            var screeningRoomIdCCinemaB = Guid.NewGuid();

            var screeningRoomIdACinemaC = Guid.NewGuid();
            var screeningRoomIdBCinemaC = Guid.NewGuid();
            var screeningRoomIdCCinemaC = Guid.NewGuid();

            //seats 
            var seatIdARoomIdACinemaA = Guid.NewGuid();
            var seatIdBRoomIdACinemaA = Guid.NewGuid();
            var seatIdCRoomIdACinemaA = Guid.NewGuid();

            var seatIdARoomIdBCinemaA = Guid.NewGuid();
            var seatIdBRoomIdBCinemaA = Guid.NewGuid();
            var seatIdCRoomIdBCinemaA = Guid.NewGuid();

            var seatIdARoomIdCCinemaA = Guid.NewGuid();
            var seatIdBRoomIdCCinemaA = Guid.NewGuid();
            var seatIdCRoomIdCCinemaA = Guid.NewGuid();

            //screenings
            var screeningIdARoomIdACinemaA = Guid.NewGuid();
            var screeningIdBRoomIdACinemaA = Guid.NewGuid();
            var screeningIdCRoomIdACinemaA = Guid.NewGuid();

            var screeningIdARoomIdBCinemaA = Guid.NewGuid();
            var screeningIdBRoomIdBCinemaA = Guid.NewGuid();
            var screeningIdCRoomIdBCinemaA = Guid.NewGuid();

            var screeningIdARoomIdCCinemaA = Guid.NewGuid();
            var screeningIdBRoomIdCCinemaA = Guid.NewGuid();
            var screeningIdCRoomIdCCinemaA = Guid.NewGuid();

            // tickets
            var ticketIdAscreeningIdARoomIdACinemaA = Guid.NewGuid();
            var ticketIdBscreeningIdARoomIdACinemaA = Guid.NewGuid();
            var ticketIdCscreeningIdARoomIdACinemaA = Guid.NewGuid();

            var ticketIdAscreeningIdBRoomIdACinemaA = Guid.NewGuid();
            var ticketIdBscreeningIdBRoomIdACinemaA = Guid.NewGuid();
            var ticketIdCscreeningIdBRoomIdACinemaA = Guid.NewGuid();

            var ticketIdAscreeningIdCRoomIdACinemaA = Guid.NewGuid();
            var ticketIdBscreeningIdCRoomIdACinemaA = Guid.NewGuid();
            var ticketIdCscreeningIdCRoomIdACinemaA = Guid.NewGuid();

            //clients
            var clientIdA = Guid.NewGuid();
            var clientIdB = Guid.NewGuid();
            var clientIdC = Guid.NewGuid();

            //cinemas          






        }
    }
}
