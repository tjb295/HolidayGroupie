namespace HolidayGroupie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembershipTypesAgain : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT Friends ON");
            Sql("INSERT INTO Friends (Id, Name, LastName) VALUES (4, 'Amber', 'Nakamura')");
            Sql("INSERT INTO Friends (Id, Name, LastName) VALUES (5, 'Paul', 'Choe')");
            Sql("INSERT INTO Friends (Id, Name, LastName) VALUES (6, 'Jessica', 'Tan')");
            Sql("SET IDENTITY_INSERT Friends OFF");
        }
        
        public override void Down()
        {
        }
    }
}
