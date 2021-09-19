namespace FullyProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editProp : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PropertyOffers", "offerTitle", c => c.String(nullable: false));
            AlterColumn("dbo.PropertyOffers", "country", c => c.String(nullable: false));
            AlterColumn("dbo.PropertyOffers", "city", c => c.String(nullable: false));
            AlterColumn("dbo.PropertyOffers", "description", c => c.String(nullable: false));
            DropColumn("dbo.PropertyOffers", "isArgumented");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PropertyOffers", "isArgumented", c => c.Boolean(nullable: false));
            AlterColumn("dbo.PropertyOffers", "description", c => c.String());
            AlterColumn("dbo.PropertyOffers", "city", c => c.String());
            AlterColumn("dbo.PropertyOffers", "country", c => c.String());
            DropColumn("dbo.PropertyOffers", "offerTitle");
        }
    }
}
