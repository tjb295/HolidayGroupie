namespace HolidayGroupie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BringerWasFriend : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Items", "Bringer_Id", c => c.Int());
            CreateIndex("dbo.Items", "Bringer_Id");
            AddForeignKey("dbo.Items", "Bringer_Id", "dbo.Friends", "Id");
            DropColumn("dbo.Items", "Bringer");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Items", "Bringer", c => c.Int(nullable: false));
            DropForeignKey("dbo.Items", "Bringer_Id", "dbo.Friends");
            DropIndex("dbo.Items", new[] { "Bringer_Id" });
            DropColumn("dbo.Items", "Bringer_Id");
        }
    }
}
