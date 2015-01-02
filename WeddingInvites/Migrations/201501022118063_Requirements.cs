namespace WeddingInvites.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Requirements : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Invites", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Invites", "Party", c => c.String(nullable: false));
            AlterColumn("dbo.Invites", "Type", c => c.String(nullable: false));
            AlterColumn("dbo.Invites", "Invitees", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Invites", "Invitees", c => c.Int(nullable: false));
            AlterColumn("dbo.Invites", "Type", c => c.String());
            AlterColumn("dbo.Invites", "Party", c => c.String());
            AlterColumn("dbo.Invites", "Name", c => c.String());
        }
    }
}
