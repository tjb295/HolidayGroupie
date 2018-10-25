namespace HolidayGroupie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEventsItemsDbs : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.EventFriends", newName: "FriendEvents");
            DropPrimaryKey("dbo.FriendEvents");
            AddPrimaryKey("dbo.FriendEvents", new[] { "Friend_Id", "Event_Id" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.FriendEvents");
            AddPrimaryKey("dbo.FriendEvents", new[] { "Event_Id", "Friend_Id" });
            RenameTable(name: "dbo.FriendEvents", newName: "EventFriends");
        }
    }
}
