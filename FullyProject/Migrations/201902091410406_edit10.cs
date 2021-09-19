namespace FullyProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edit10 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.PropertyOffers", "doneDate");
            DropColumn("dbo.PropertyOffers", "active");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PropertyOffers", "active", c => c.Boolean(nullable: false));
            AddColumn("dbo.PropertyOffers", "doneDate", c => c.DateTime());
        }
    }
}
