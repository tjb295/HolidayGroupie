namespace HolidayGroupie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingMembershipTypeIdForFriend : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT MembershipTypes ON");
            AddColumn("dbo.Friends", "MembershipTypeId", c => c.Byte(nullable: false));
            Sql("INSERT INTO MembershipTypes (Id, SignUpFee, DurationInMonths, DiscountRate) VALUES (1, 0, 0, 0)");
            Sql("INSERT INTO MembershipTypes (Id, SignUpFee, DurationInMonths, DiscountRate) VALUES (2, 30, 1, 10)");
            Sql("INSERT INTO MembershipTypes (Id, SignUpFee, DurationInMonths, DiscountRate) VALUES (3, 90, 3, 15)");
            Sql("INSERT INTO MembershipTypes (Id, SignUpFee, DurationInMonths, DiscountRate) VALUES (4, 300, 12, 20)");
            Sql("SET IDENTITY_INSERT MembershipTypes OFF");
        }
        
        public override void Down()
        {
            DropColumn("dbo.Friends", "MembershipTypeId");
        }
    }
}
