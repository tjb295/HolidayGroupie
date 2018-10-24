namespace HolidayGroupie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplyAnnotationsToFriendName : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Friends", "Name", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Friends", "Name", c => c.String());
        }
    }
}
