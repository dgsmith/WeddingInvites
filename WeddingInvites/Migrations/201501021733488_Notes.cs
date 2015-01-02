namespace WeddingInvites.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Notes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Invites", "AttendingCount", c => c.Int());
            AddColumn("dbo.Invites", "Notes", c => c.String());
            AlterColumn("dbo.Invites", "State", c => c.String(maxLength: 2));
            AlterColumn("dbo.Invites", "Zip", c => c.String(maxLength: 5));
            DropColumn("dbo.Invites", "Attending");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Invites", "Attending", c => c.Int(nullable: false));
            AlterColumn("dbo.Invites", "Zip", c => c.String());
            AlterColumn("dbo.Invites", "State", c => c.String());
            DropColumn("dbo.Invites", "Notes");
            DropColumn("dbo.Invites", "AttendingCount");
        }
    }
}
