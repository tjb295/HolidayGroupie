namespace HolidayGroupie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingEmailToFriendModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Friends", "Email", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Friends", "Email");
        }
    }
}
