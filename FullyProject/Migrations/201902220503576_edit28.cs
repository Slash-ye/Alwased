namespace FullyProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edit28 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CarOffers", "mainImage", c => c.String());
            AlterColumn("dbo.PropertyOffers", "mainImage", c => c.String());
            AlterColumn("dbo.OnlineProjects", "mainImage", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.OnlineProjects", "mainImage", c => c.String(nullable: false));
            AlterColumn("dbo.PropertyOffers", "mainImage", c => c.String(nullable: false));
            AlterColumn("dbo.CarOffers", "mainImage", c => c.String(nullable: false));
        }
    }
}
