namespace FullyProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edit14 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.SubscriptionEmails", "email", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SubscriptionEmails", "email", c => c.String());
        }
    }
}
