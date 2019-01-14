using CinemaSupport.Domain.Models;
using CinemaSupport.Domain.Models.Tickets;

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


            //seats screening room a
            var seatARoomIdACinemaA = new Seat()
            {
                SeatId = 1,
                ScreeningRoomId = 1,
                State = false
            };
            var seatBRoomIdACinemaA = new Seat()
            {
                SeatId = 2,
                ScreeningRoomId = 1,
                State = false
            };
            var seatCRoomIdACinemaA = new Seat()
            {
                SeatId = 3,
                ScreeningRoomId = 1,
                State = false
            };

            var seatDRoomIdACinemaA = new Seat()
            {
                SeatId = 4,
                ScreeningRoomId = 1,
                State = false
            };
            var seatERoomIdACinemaA = new Seat()
            {
                SeatId = 5,
                ScreeningRoomId = 1,
                State = false
            };
            var seatFRoomIdACinemaA = new Seat()
            {
                SeatId = 6,
                ScreeningRoomId = 1,
                State = false
            };

            //seats screening room b
            var seatARoomIdBCinemaA = new Seat()
            {
                SeatId = 7,
                ScreeningRoomId = 2,
                State = false
            };
            var seatBRoomIdBCinemaA = new Seat()
            {
                SeatId = 8,
                ScreeningRoomId = 2,
                State = false
            };
            var seatCRoomIdBCinemaA = new Seat()
            {
                SeatId = 9,
                ScreeningRoomId = 2,
                State = false
            };

            var seatDRoomIdBCinemaA = new Seat()
            {
                SeatId = 10,
                ScreeningRoomId = 2,
                State = false
            };

            // c
            var seatARoomIdCCinemaA = new Seat()
            {
                SeatId = 11,
                ScreeningRoomId = 3,
                State = false
            };
            var seatBRoomIdCCinemaA = new Seat()
            {
                SeatId = 12,
                ScreeningRoomId = 3,
                State = false
            };
            var seatCRoomIdCCinemaA = new Seat()
            {
                SeatId = 13,
                ScreeningRoomId = 4,
                State = false
            };

            //d
            var seatARoomIdDCinemaA = new Seat()
            {
                SeatId = 14,
                ScreeningRoomId = 5,
                State = false
            };


            //movies
            var movieA = new Movie()
            {
                MovieId = 1,
                Duration = 150,
                Picture = "https://cdn.galleries.smcloud.net/t/photos/gf-hYbT-USnH-FeHt_harry-potter-zabity-przez-voldemorta-szokujaca-teoria-o-zakonczeniu-kultowej-serii.jpg",
                Title = "Harry Potter"

            };

            var movieB = new Movie()
            {
                MovieId = 2,
                Duration = 200,
                Picture = "https://is4-ssl.mzstatic.com/image/thumb/Video49/v4/0f/af/2d/0faf2dee-0f61-0da7-5a92-c460617bca80/pr_source.lsr/268x0w.png",
                Title = "Dirty Harry"
            };

            var movieC = new Movie()
            {
                MovieId = 3,
                Duration = 60,
                Picture = "https://is2-ssl.mzstatic.com/image/thumb/Music/y2004/m05/d21/h00/s05.hpejtcra.jpg/268x0w.jpg",
                Title = "E.T."
            };

            //screenings
            var screeningARoomIdACinemaA = new Screening()
            {
                ScreeningId = 1,
                ScreeningRoomId = 1,
                MovieId = 1,
                Status = false,
                ScreeningDate = "18 July 2019 - 15.00",
            };

            var screeningBRoomIdACinemaA = new Screening()
            {
                ScreeningId = 2,
                ScreeningRoomId = 1,
                MovieId = 1,
                Status = false,
                ScreeningDate = "18 July 2019 - 21.30",
            };
            var screeningCRoomIdACinemaA = new Screening()
            {
                ScreeningId = 3,
                ScreeningRoomId = 1,
                MovieId = 1,
                Status = false,
                ScreeningDate = "20 July 2019 - 9.30",
            };

            var screeningDRoomIdACinemaA = new Screening()
            {
                ScreeningId = 4,
                ScreeningRoomId = 1,
                MovieId = 2,
                Status = false,
                ScreeningDate = "18 July 2019 - 9.00",
            };

            var screeningERoomIdACinemaA = new Screening()
            {
                ScreeningId = 5,
                ScreeningRoomId = 1,
                MovieId = 2,
                Status = false,
                ScreeningDate = "19 July 2019 - 21.30",
            };
            var screeningFRoomIdACinemaA = new Screening()
            {
                ScreeningId = 6,
                ScreeningRoomId = 1,
                MovieId = 3,
                Status = false,
                ScreeningDate = "20 July 2019 - 9.30",
            };

            //screening rooms
            var screeningRoomACinemaA = new ScreeningRoom()
            {
                ScreeningRoomId = 1,
                Name = "ScreeningRoom 1",
                CinemaId = 1,
                Floor = 1,
            };

            var screeningRoomBCinemaA = new ScreeningRoom()
            {
                ScreeningRoomId = 2,
                Name = "ScreeningRoom 2",
                CinemaId = 1,
                Floor = 2,
            };

            var screeningRoomCCinemaA = new ScreeningRoom()
            {
                ScreeningRoomId = 3,
                Name = "ScreeningRoom 3",
                CinemaId = 1,
                Floor = 3,
            };

            var screeningRoomDCinemaA = new ScreeningRoom()
            {
                ScreeningRoomId = 4,
                Name = "ScreeningRoom 4",
                CinemaId = 1,
                Floor = 1,
            };

            //cinemas
            var cinemaIdA = 1;
            var cinemaA = new Cinema()
            {
                CinemaId = cinemaIdA,
                Name = "Cinema1",
            };

            // tickets
            var ticketA = new Ticket() { TicketId = 1, Actor = "Filip", Price = 20, TicketType = TicketType.Normal, Purchased = true, Validated = false, ScreeningId = 1, SeatId = 1 };
            var ticketB = new Ticket() { TicketId = 2, Actor = "Filip", Price = 15, TicketType = TicketType.Reduced, Purchased = true, Validated = false, ScreeningId = 1, SeatId = 2 };
            var ticketC = new Ticket() { TicketId = 3, Price = 20, TicketType = TicketType.Normal, Purchased = true, Validated = false, ScreeningId = 2, SeatId = 4 };

            //clients

            //cinemas          


            //adding to db
            context.Cinemas.AddOrUpdate(cinemaA);
            context.Movies.AddOrUpdate(new Movie[] { movieA, movieB, movieC });
            context.ScreeningRooms.AddOrUpdate(screeningRoomACinemaA, screeningRoomBCinemaA, screeningRoomCCinemaA, screeningRoomDCinemaA);
            context.Screenings.AddOrUpdate(new Screening[] { screeningARoomIdACinemaA, screeningBRoomIdACinemaA, screeningCRoomIdACinemaA, screeningDRoomIdACinemaA, screeningERoomIdACinemaA, screeningFRoomIdACinemaA });
            context.Seats.AddOrUpdate(new Seat[]
            {
                seatARoomIdACinemaA, seatBRoomIdACinemaA, seatCRoomIdACinemaA, seatDRoomIdACinemaA, seatERoomIdACinemaA, seatFRoomIdACinemaA,
                seatARoomIdBCinemaA, seatBRoomIdBCinemaA, seatCRoomIdBCinemaA, seatDRoomIdBCinemaA,
                seatARoomIdCCinemaA, seatBRoomIdCCinemaA, seatCRoomIdCCinemaA,
                seatARoomIdDCinemaA
            });
            context.Tickets.AddOrUpdate(new Ticket[] { ticketA, ticketB, ticketC });


        }
    }
}
