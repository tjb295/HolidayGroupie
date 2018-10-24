namespace HolidayGroupie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembershipType : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT Friends ON");
            Sql("INSERT INTO Friends (Id, Name, LastName) VALUES (1, 'Kairey', 'Lee')");
            Sql("INSERT INTO Friends (Id, Name, LastName) VALUES (2, 'Jasmine', 'Tan')");
            Sql("INSERT INTO Friends (Id, Name, LastName) VALUES (3, 'Sean', 'Francisco')");
            Sql("SET IDENTITY_INSERT Friends OFF");
            AddColumn("dbo.Events", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Events", "Description");
        }
    }
}
