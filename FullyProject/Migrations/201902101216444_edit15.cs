namespace FullyProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edit15 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ContactInfoMessages", "fullName", c => c.String(nullable: false));
            AlterColumn("dbo.ContactInfoMessages", "message", c => c.String(nullable: false));
            AlterColumn("dbo.ContactInfoMessages", "email", c => c.String(nullable: false));
            AlterColumn("dbo.ContactInfoMessages", "phoneNumber", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ContactInfoMessages", "phoneNumber", c => c.String());
            AlterColumn("dbo.ContactInfoMessages", "email", c => c.String());
            AlterColumn("dbo.ContactInfoMessages", "message", c => c.String());
            AlterColumn("dbo.ContactInfoMessages", "fullName", c => c.String());
        }
    }
}
