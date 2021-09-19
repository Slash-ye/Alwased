namespace FullyProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edit27 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CarOffers", "mainImage", c => c.String(nullable: false));
            AddColumn("dbo.PropertyOffers", "mainImage", c => c.String(nullable: false));
            AddColumn("dbo.OnlineProjects", "mainImage", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.OnlineProjects", "mainImage");
            DropColumn("dbo.PropertyOffers", "mainImage");
            DropColumn("dbo.CarOffers", "mainImage");
        }
    }
}
