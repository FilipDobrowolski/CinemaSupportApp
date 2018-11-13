namespace CinemaSupport.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Actors",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Name = c.String(),
                        Surname = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Cinemas",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Name = c.String(),
                        City = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ScreeningRooms",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Name = c.String(),
                        Floor = c.Int(nullable: false),
                        CinemaID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Cinemas", t => t.CinemaID, cascadeDelete: true)
                .Index(t => t.CinemaID);
            
            CreateTable(
                "dbo.Screenings",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Status = c.Boolean(nullable: false),
                        ScreeningDate = c.DateTime(nullable: false),
                        ScreeningRoomID = c.Guid(nullable: false),
                        MovieID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Movies", t => t.MovieID, cascadeDelete: true)
                .ForeignKey("dbo.ScreeningRooms", t => t.ScreeningRoomID, cascadeDelete: true)
                .Index(t => t.ScreeningRoomID)
                .Index(t => t.MovieID);
            
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Created = c.DateTime(nullable: false),
                        Title = c.String(),
                        Duration = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Reservation = c.Boolean(nullable: false),
                        Price = c.Int(nullable: false),
                        ScreeningID = c.Guid(nullable: false),
                        ClientID = c.Guid(nullable: false),
                        Seat_ID = c.Guid(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Clients", t => t.ClientID)
                .ForeignKey("dbo.Screenings", t => t.ScreeningID, cascadeDelete: true)
                .ForeignKey("dbo.Seats", t => t.Seat_ID)
                .Index(t => t.ScreeningID)
                .Index(t => t.ClientID)
                .Index(t => t.Seat_ID);
            
            CreateTable(
                "dbo.Seats",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Number = c.Int(nullable: false),
                        State = c.Boolean(nullable: false),
                        ScreeningRoomID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ScreeningRooms", t => t.ScreeningRoomID, cascadeDelete: true)
                .Index(t => t.ScreeningRoomID);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Actors", t => t.ID)
                .Index(t => t.ID);
            
            CreateTable(
                "dbo.Workers",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Actors", t => t.ID)
                .Index(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Workers", "ID", "dbo.Actors");
            DropForeignKey("dbo.Clients", "ID", "dbo.Actors");
            DropForeignKey("dbo.Tickets", "Seat_ID", "dbo.Seats");
            DropForeignKey("dbo.Seats", "ScreeningRoomID", "dbo.ScreeningRooms");
            DropForeignKey("dbo.Tickets", "ScreeningID", "dbo.Screenings");
            DropForeignKey("dbo.Tickets", "ClientID", "dbo.Clients");
            DropForeignKey("dbo.Screenings", "ScreeningRoomID", "dbo.ScreeningRooms");
            DropForeignKey("dbo.Screenings", "MovieID", "dbo.Movies");
            DropForeignKey("dbo.ScreeningRooms", "CinemaID", "dbo.Cinemas");
            DropIndex("dbo.Workers", new[] { "ID" });
            DropIndex("dbo.Clients", new[] { "ID" });
            DropIndex("dbo.Seats", new[] { "ScreeningRoomID" });
            DropIndex("dbo.Tickets", new[] { "Seat_ID" });
            DropIndex("dbo.Tickets", new[] { "ClientID" });
            DropIndex("dbo.Tickets", new[] { "ScreeningID" });
            DropIndex("dbo.Screenings", new[] { "MovieID" });
            DropIndex("dbo.Screenings", new[] { "ScreeningRoomID" });
            DropIndex("dbo.ScreeningRooms", new[] { "CinemaID" });
            DropTable("dbo.Workers");
            DropTable("dbo.Clients");
            DropTable("dbo.Seats");
            DropTable("dbo.Tickets");
            DropTable("dbo.Movies");
            DropTable("dbo.Screenings");
            DropTable("dbo.ScreeningRooms");
            DropTable("dbo.Cinemas");
            DropTable("dbo.Actors");
        }
    }
}
