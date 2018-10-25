namespace HolidayGroupie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EventUpcomingAdd : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FriendEvents", "Friend_Id", "dbo.Friends");
            DropForeignKey("dbo.FriendEvents", "Event_Id", "dbo.Events");
            DropIndex("dbo.FriendEvents", new[] { "Friend_Id" });
            DropIndex("dbo.FriendEvents", new[] { "Event_Id" });
            AddColumn("dbo.Events", "Friend_Id", c => c.Int());
            AddColumn("dbo.Friends", "UpcomingEvent_Id", c => c.Int());
            AddColumn("dbo.Friends", "Event_Id", c => c.Int());
            CreateIndex("dbo.Events", "Friend_Id");
            CreateIndex("dbo.Friends", "UpcomingEvent_Id");
            CreateIndex("dbo.Friends", "Event_Id");
            AddForeignKey("dbo.Events", "Friend_Id", "dbo.Friends", "Id");
            AddForeignKey("dbo.Friends", "UpcomingEvent_Id", "dbo.Events", "Id");
            AddForeignKey("dbo.Friends", "Event_Id", "dbo.Events", "Id");
            DropColumn("dbo.Friends", "UpcomingEvent");
            DropTable("dbo.FriendEvents");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.FriendEvents",
                c => new
                    {
                        Friend_Id = c.Int(nullable: false),
                        Event_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Friend_Id, t.Event_Id });
            
            AddColumn("dbo.Friends", "UpcomingEvent", c => c.Int(nullable: false));
            DropForeignKey("dbo.Friends", "Event_Id", "dbo.Events");
            DropForeignKey("dbo.Friends", "UpcomingEvent_Id", "dbo.Events");
            DropForeignKey("dbo.Events", "Friend_Id", "dbo.Friends");
            DropIndex("dbo.Friends", new[] { "Event_Id" });
            DropIndex("dbo.Friends", new[] { "UpcomingEvent_Id" });
            DropIndex("dbo.Events", new[] { "Friend_Id" });
            DropColumn("dbo.Friends", "Event_Id");
            DropColumn("dbo.Friends", "UpcomingEvent_Id");
            DropColumn("dbo.Events", "Friend_Id");
            CreateIndex("dbo.FriendEvents", "Event_Id");
            CreateIndex("dbo.FriendEvents", "Friend_Id");
            AddForeignKey("dbo.FriendEvents", "Event_Id", "dbo.Events", "Id", cascadeDelete: true);
            AddForeignKey("dbo.FriendEvents", "Friend_Id", "dbo.Friends", "Id", cascadeDelete: true);
        }
    }
}
