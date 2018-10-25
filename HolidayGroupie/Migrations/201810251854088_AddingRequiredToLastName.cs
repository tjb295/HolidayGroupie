namespace HolidayGroupie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingRequiredToLastName : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Friends", "LastName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Friends", "LastName", c => c.String());
        }
    }
}
