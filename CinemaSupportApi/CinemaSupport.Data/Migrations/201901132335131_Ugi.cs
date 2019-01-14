namespace CinemaSupport.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Ugi : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ScreeningRooms", "CinemaID", "dbo.Cinemas");
            DropForeignKey("dbo.Screenings", "MovieID", "dbo.Movies");
            DropForeignKey("dbo.Screenings", "ScreeningRoomID", "dbo.ScreeningRooms");
            DropForeignKey("dbo.Tickets", "ScreeningID", "dbo.Screenings");
            DropForeignKey("dbo.Seats", "ScreeningRoomID", "dbo.ScreeningRooms");
            DropForeignKey("dbo.Tickets", "Seat_ID", "dbo.Seats");
            DropIndex("dbo.ScreeningRooms", new[] { "CinemaID" });
            DropIndex("dbo.Screenings", new[] { "ScreeningRoomID" });
            DropIndex("dbo.Screenings", new[] { "MovieID" });
            DropIndex("dbo.Tickets", new[] { "ScreeningID" });
            DropIndex("dbo.Tickets", new[] { "Seat_ID" });
            DropIndex("dbo.Seats", new[] { "ScreeningRoomID" });
            RenameColumn(table: "dbo.Tickets", name: "Seat_ID", newName: "SeatId");
            DropPrimaryKey("dbo.Cinemas");
            DropPrimaryKey("dbo.ScreeningRooms");
            DropPrimaryKey("dbo.Screenings");
            DropPrimaryKey("dbo.Movies");
            DropPrimaryKey("dbo.Tickets");
            DropPrimaryKey("dbo.Seats");
            AddColumn("dbo.Cinemas", "CinemaId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.ScreeningRooms", "ScreeningRoomId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.ScreeningRooms", "Cinema_CinemaId", c => c.Int());
            AddColumn("dbo.Screenings", "ScreeningId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Screenings", "Movie_MovieId", c => c.Int());
            AddColumn("dbo.Screenings", "ScreeningRoom_ScreeningRoomId", c => c.Int());
            AddColumn("dbo.Movies", "MovieId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Tickets", "TicketId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Tickets", "TicketType", c => c.Int(nullable: false));
            AddColumn("dbo.Tickets", "Purchased", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tickets", "Validated", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tickets", "Actor", c => c.String());
            AddColumn("dbo.Tickets", "Screening_ScreeningId", c => c.Int());
            AddColumn("dbo.Tickets", "Seat_SeatId", c => c.Int());
            AddColumn("dbo.Tickets", "Actor_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Seats", "SeatId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Seats", "ScreeningRoom_ScreeningRoomId", c => c.Int());

            DropColumn("dbo.ScreeningRooms", "CinemaId");
            AddColumn("dbo.ScreeningRooms", "CinemaId", c => c.Int(nullable: false));

            DropColumn("dbo.Screenings", "ScreeningDate");
            AddColumn("dbo.Screenings", "ScreeningDate", c => c.String());

            DropColumn("dbo.Screenings", "ScreeningRoomId");
            AddColumn("dbo.Screenings", "ScreeningRoomId", c => c.Int(nullable: false));

            DropColumn("dbo.Screenings", "MovieId");
            AddColumn("dbo.Screenings", "MovieId", c => c.Int(nullable: false));

            DropColumn("dbo.Tickets", "ScreeningId");
            AddColumn("dbo.Tickets", "ScreeningId", c => c.Int(nullable: false));

            DropColumn("dbo.Tickets", "SeatId");
            AddColumn("dbo.Tickets", "SeatId", c => c.Int(nullable: false));

            DropColumn("dbo.Seats", "ScreeningRoomId");
            AddColumn("dbo.Seats", "ScreeningRoomId", c => c.Int(nullable: false));

            AddPrimaryKey("dbo.Cinemas", "CinemaId");
            AddPrimaryKey("dbo.ScreeningRooms", "ScreeningRoomId");
            AddPrimaryKey("dbo.Screenings", "ScreeningId");
            AddPrimaryKey("dbo.Movies", "MovieId");
            AddPrimaryKey("dbo.Tickets", "TicketId");
            AddPrimaryKey("dbo.Seats", "SeatId");
            CreateIndex("dbo.ScreeningRooms", "CinemaId");
            CreateIndex("dbo.ScreeningRooms", "Cinema_CinemaId");
            CreateIndex("dbo.Screenings", "ScreeningRoomId");
            CreateIndex("dbo.Screenings", "MovieId");
            CreateIndex("dbo.Screenings", "Movie_MovieId");
            CreateIndex("dbo.Screenings", "ScreeningRoom_ScreeningRoomId");
            CreateIndex("dbo.Tickets", "ScreeningId");
            CreateIndex("dbo.Tickets", "SeatId");
            CreateIndex("dbo.Tickets", "Screening_ScreeningId");
            CreateIndex("dbo.Tickets", "Seat_SeatId");
            CreateIndex("dbo.Tickets", "Actor_Id");
            CreateIndex("dbo.Seats", "ScreeningRoomId");
            CreateIndex("dbo.Seats", "ScreeningRoom_ScreeningRoomId");

            AddForeignKey("dbo.Tickets", "Seat_SeatId", "dbo.Seats", "SeatId");
            AddForeignKey("dbo.Tickets", "Actor_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.ScreeningRooms", "Cinema_CinemaId", "dbo.Cinemas", "CinemaId");
            AddForeignKey("dbo.Screenings", "Movie_MovieId", "dbo.Movies", "MovieId");
            AddForeignKey("dbo.Screenings", "ScreeningRoom_ScreeningRoomId", "dbo.ScreeningRooms", "ScreeningRoomId");
            AddForeignKey("dbo.Tickets", "Screening_ScreeningId", "dbo.Screenings", "ScreeningId");
            AddForeignKey("dbo.Seats", "ScreeningRoom_ScreeningRoomId", "dbo.ScreeningRooms", "ScreeningRoomId");

            AddForeignKey("dbo.Tickets", "SeatId", "dbo.Seats", "SeatId", cascadeDelete: true);
            AddForeignKey("dbo.ScreeningRooms", "CinemaId", "dbo.Cinemas", "CinemaId", cascadeDelete: true);
            AddForeignKey("dbo.Screenings", "ScreeningRoomId", "dbo.ScreeningRooms", "ScreeningRoomId", cascadeDelete: true);
            AddForeignKey("dbo.Seats", "ScreeningRoomId", "dbo.ScreeningRooms", "ScreeningRoomId", cascadeDelete: true);
            AddForeignKey("dbo.Tickets", "ScreeningId", "dbo.Screenings", "ScreeningId", cascadeDelete: false);
            AddForeignKey("dbo.Screenings", "MovieId", "dbo.Movies", "MovieId", cascadeDelete: true);
            DropColumn("dbo.Cinemas", "ID");
            DropColumn("dbo.ScreeningRooms", "ID");
            DropColumn("dbo.Screenings", "ID");
            DropColumn("dbo.Movies", "ID");
            DropColumn("dbo.Movies", "Created");
            DropColumn("dbo.Tickets", "ID");
            DropColumn("dbo.Tickets", "Reservation");
            DropColumn("dbo.Seats", "ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Seats", "ID", c => c.Guid(nullable: false));
            AddColumn("dbo.Tickets", "Reservation", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tickets", "ID", c => c.Guid(nullable: false));
            AddColumn("dbo.Movies", "Created", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movies", "ID", c => c.Guid(nullable: false));
            AddColumn("dbo.Screenings", "ID", c => c.Guid(nullable: false));
            AddColumn("dbo.ScreeningRooms", "ID", c => c.Guid(nullable: false));
            AddColumn("dbo.Cinemas", "ID", c => c.Guid(nullable: false));
            DropForeignKey("dbo.Screenings", "MovieId", "dbo.Movies");
            DropForeignKey("dbo.Tickets", "ScreeningId", "dbo.Screenings");
            DropForeignKey("dbo.Seats", "ScreeningRoomId", "dbo.ScreeningRooms");
            DropForeignKey("dbo.Screenings", "ScreeningRoomId", "dbo.ScreeningRooms");
            DropForeignKey("dbo.ScreeningRooms", "CinemaId", "dbo.Cinemas");
            DropForeignKey("dbo.Tickets", "SeatId", "dbo.Seats");
            DropForeignKey("dbo.Seats", "ScreeningRoom_ScreeningRoomId", "dbo.ScreeningRooms");
            DropForeignKey("dbo.Tickets", "Screening_ScreeningId", "dbo.Screenings");
            DropForeignKey("dbo.Screenings", "ScreeningRoom_ScreeningRoomId", "dbo.ScreeningRooms");
            DropForeignKey("dbo.Screenings", "Movie_MovieId", "dbo.Movies");
            DropForeignKey("dbo.ScreeningRooms", "Cinema_CinemaId", "dbo.Cinemas");
            DropForeignKey("dbo.Tickets", "Actor_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Tickets", "Seat_SeatId", "dbo.Seats");
            DropIndex("dbo.Seats", new[] { "ScreeningRoom_ScreeningRoomId" });
            DropIndex("dbo.Seats", new[] { "ScreeningRoomId" });
            DropIndex("dbo.Tickets", new[] { "Actor_Id" });
            DropIndex("dbo.Tickets", new[] { "Seat_SeatId" });
            DropIndex("dbo.Tickets", new[] { "Screening_ScreeningId" });
            DropIndex("dbo.Tickets", new[] { "SeatId" });
            DropIndex("dbo.Tickets", new[] { "ScreeningId" });
            DropIndex("dbo.Screenings", new[] { "ScreeningRoom_ScreeningRoomId" });
            DropIndex("dbo.Screenings", new[] { "Movie_MovieId" });
            DropIndex("dbo.Screenings", new[] { "MovieId" });
            DropIndex("dbo.Screenings", new[] { "ScreeningRoomId" });
            DropIndex("dbo.ScreeningRooms", new[] { "Cinema_CinemaId" });
            DropIndex("dbo.ScreeningRooms", new[] { "CinemaId" });
            DropPrimaryKey("dbo.Seats");
            DropPrimaryKey("dbo.Tickets");
            DropPrimaryKey("dbo.Movies");
            DropPrimaryKey("dbo.Screenings");
            DropPrimaryKey("dbo.ScreeningRooms");
            DropPrimaryKey("dbo.Cinemas");
            AlterColumn("dbo.Seats", "ScreeningRoomId", c => c.Guid(nullable: false));
            AlterColumn("dbo.Tickets", "SeatId", c => c.Guid());
            AlterColumn("dbo.Tickets", "ScreeningId", c => c.Guid(nullable: false));
            AlterColumn("dbo.Screenings", "MovieId", c => c.Guid(nullable: false));
            AlterColumn("dbo.Screenings", "ScreeningRoomId", c => c.Guid(nullable: false));
            AlterColumn("dbo.Screenings", "ScreeningDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ScreeningRooms", "CinemaId", c => c.Guid(nullable: false));
            DropColumn("dbo.Seats", "ScreeningRoom_ScreeningRoomId");
            DropColumn("dbo.Seats", "SeatId");
            DropColumn("dbo.Tickets", "Actor_Id");
            DropColumn("dbo.Tickets", "Seat_SeatId");
            DropColumn("dbo.Tickets", "Screening_ScreeningId");
            DropColumn("dbo.Tickets", "Actor");
            DropColumn("dbo.Tickets", "Validated");
            DropColumn("dbo.Tickets", "Purchased");
            DropColumn("dbo.Tickets", "TicketType");
            DropColumn("dbo.Tickets", "TicketId");
            DropColumn("dbo.Movies", "MovieId");
            DropColumn("dbo.Screenings", "ScreeningRoom_ScreeningRoomId");
            DropColumn("dbo.Screenings", "Movie_MovieId");
            DropColumn("dbo.Screenings", "ScreeningId");
            DropColumn("dbo.ScreeningRooms", "Cinema_CinemaId");
            DropColumn("dbo.ScreeningRooms", "ScreeningRoomId");
            DropColumn("dbo.Cinemas", "CinemaId");
            AddPrimaryKey("dbo.Seats", "ID");
            AddPrimaryKey("dbo.Tickets", "ID");
            AddPrimaryKey("dbo.Movies", "ID");
            AddPrimaryKey("dbo.Screenings", "ID");
            AddPrimaryKey("dbo.ScreeningRooms", "ID");
            AddPrimaryKey("dbo.Cinemas", "ID");
            RenameColumn(table: "dbo.Tickets", name: "SeatId", newName: "Seat_ID");
            CreateIndex("dbo.Seats", "ScreeningRoomID");
            CreateIndex("dbo.Tickets", "Seat_ID");
            CreateIndex("dbo.Tickets", "ScreeningID");
            CreateIndex("dbo.Screenings", "MovieID");
            CreateIndex("dbo.Screenings", "ScreeningRoomID");
            CreateIndex("dbo.ScreeningRooms", "CinemaID");
            AddForeignKey("dbo.Tickets", "Seat_ID", "dbo.Seats", "ID");
            AddForeignKey("dbo.Seats", "ScreeningRoomID", "dbo.ScreeningRooms", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Tickets", "ScreeningID", "dbo.Screenings", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Screenings", "ScreeningRoomID", "dbo.ScreeningRooms", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Screenings", "MovieID", "dbo.Movies", "ID", cascadeDelete: true);
            AddForeignKey("dbo.ScreeningRooms", "CinemaID", "dbo.Cinemas", "ID", cascadeDelete: true);
        }
    }
}
