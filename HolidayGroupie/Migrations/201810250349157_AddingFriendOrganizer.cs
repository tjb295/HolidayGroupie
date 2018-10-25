namespace HolidayGroupie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingFriendOrganizer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "OrganizerId_Id", c => c.Int());
            CreateIndex("dbo.Events", "OrganizerId_Id");
            AddForeignKey("dbo.Events", "OrganizerId_Id", "dbo.Friends", "Id");
            DropColumn("dbo.Events", "OrganizerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Events", "OrganizerId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Events", "OrganizerId_Id", "dbo.Friends");
            DropIndex("dbo.Events", new[] { "OrganizerId_Id" });
            DropColumn("dbo.Events", "OrganizerId_Id");
        }
    }
}
