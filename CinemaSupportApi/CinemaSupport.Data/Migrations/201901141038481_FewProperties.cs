namespace CinemaSupport.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FewProperties : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "Picture", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "Picture");
        }
    }
}
