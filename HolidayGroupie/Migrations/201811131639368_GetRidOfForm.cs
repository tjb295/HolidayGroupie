namespace HolidayGroupie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GetRidOfForm : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Friends", "MembershipTypeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Friends", "MembershipTypeId", c => c.Byte(nullable: false));
        }
    }
}
