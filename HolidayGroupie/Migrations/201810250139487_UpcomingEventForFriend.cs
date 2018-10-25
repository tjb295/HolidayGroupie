namespace HolidayGroupie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpcomingEventForFriend : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Friends", "UpcomingEvent", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Friends", "UpcomingEvent");
        }
    }
}
