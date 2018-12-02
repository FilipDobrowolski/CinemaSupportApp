namespace CinemaSupport.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TicketRefactor : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Tickets", "ClientID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tickets", "ClientID", c => c.Guid(nullable: false));
        }
    }
}
