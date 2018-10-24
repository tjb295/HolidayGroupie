namespace HolidayGroupie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TestForFriendMigrate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Friends", "LastName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Friends", "LastName");
        }
    }
}
