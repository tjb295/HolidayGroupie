namespace HolidayGroupie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEventData : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT Events ON");
            Sql("INSERT INTO Events (Id, Name, Description, Date, OrganizerId) VALUES (3, 'Seans Birthday', 'Celebrating sean being alive for 25 years', '2018-11-1', 1)");
            Sql("INSERT INTO Events (Id, Name, Description, Date, OrganizerId) VALUES (4, 'Halloween Bash', 'Celebration of halloween the weekend before', '2018-10-31', 2)");
            Sql("SET IDENTITY_INSERT Events OFF");
        }
        
        public override void Down()
        {
        }
    }
}
