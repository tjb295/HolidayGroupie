namespace HolidayGroupie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FriendMigrationAddingAttendeesList : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        OrganizerId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Location = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Bringer = c.Int(nullable: false),
                        EventId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Events", t => t.EventId, cascadeDelete: true)
                .Index(t => t.EventId);
            
            CreateTable(
                "dbo.EventFriends",
                c => new
                    {
                        Event_Id = c.Int(nullable: false),
                        Friend_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Event_Id, t.Friend_Id })
                .ForeignKey("dbo.Events", t => t.Event_Id, cascadeDelete: true)
                .ForeignKey("dbo.Friends", t => t.Friend_Id, cascadeDelete: true)
                .Index(t => t.Event_Id)
                .Index(t => t.Friend_Id);
            
            AddColumn("dbo.Friends", "Friend_Id", c => c.Int());
            CreateIndex("dbo.Friends", "Friend_Id");
            AddForeignKey("dbo.Friends", "Friend_Id", "dbo.Friends", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Friends", "Friend_Id", "dbo.Friends");
            DropForeignKey("dbo.Items", "EventId", "dbo.Events");
            DropForeignKey("dbo.EventFriends", "Friend_Id", "dbo.Friends");
            DropForeignKey("dbo.EventFriends", "Event_Id", "dbo.Events");
            DropIndex("dbo.EventFriends", new[] { "Friend_Id" });
            DropIndex("dbo.EventFriends", new[] { "Event_Id" });
            DropIndex("dbo.Items", new[] { "EventId" });
            DropIndex("dbo.Friends", new[] { "Friend_Id" });
            DropColumn("dbo.Friends", "Friend_Id");
            DropTable("dbo.EventFriends");
            DropTable("dbo.Items");
            DropTable("dbo.Events");
        }
    }
}
