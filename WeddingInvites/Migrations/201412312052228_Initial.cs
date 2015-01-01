namespace WeddingInvites.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Invites",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Zip = c.String(),
                        Party = c.String(),
                        Type = c.String(),
                        Invitees = c.Int(nullable: false),
                        InviteSent = c.Boolean(nullable: false),
                        Confirmed = c.Boolean(nullable: false),
                        Attending = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Invites");
        }
    }
}
