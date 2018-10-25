namespace HolidayGroupie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingMembershipTypeForFriends : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MembershipTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        SignUpFee = c.Short(nullable: false),
                        DurationInMonths = c.Byte(nullable: false),
                        DiscountRate = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Friends", "MembershipType_Id", c => c.Int());
            CreateIndex("dbo.Friends", "MembershipType_Id");
            AddForeignKey("dbo.Friends", "MembershipType_Id", "dbo.MembershipTypes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Friends", "MembershipType_Id", "dbo.MembershipTypes");
            DropIndex("dbo.Friends", new[] { "MembershipType_Id" });
            DropColumn("dbo.Friends", "MembershipType_Id");
            DropTable("dbo.MembershipTypes");
        }
    }
}
