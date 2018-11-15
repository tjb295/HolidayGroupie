namespace HolidayGroupie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RequiredForLocation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Events", "Location", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Events", "Location", c => c.String());
        }
    }
}
