namespace FullyProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edit1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CarOffers", "offerTitle", c => c.String(nullable: false));
            AlterColumn("dbo.CarOffers", "description", c => c.String(nullable: false));
            AlterColumn("dbo.CarOffers", "phoneNumber", c => c.String(nullable: false));
            AlterColumn("dbo.OnlineProjects", "name", c => c.String(nullable: false));
            AlterColumn("dbo.OnlineProjects", "description", c => c.String(nullable: false));
            AlterColumn("dbo.Services", "name", c => c.String(nullable: false));
            AlterColumn("dbo.Services", "description", c => c.String(nullable: false));
            AlterColumn("dbo.Services", "image1", c => c.String(nullable: false));
            AlterColumn("dbo.Services", "image2", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Services", "image2", c => c.String());
            AlterColumn("dbo.Services", "image1", c => c.String());
            AlterColumn("dbo.Services", "description", c => c.String());
            AlterColumn("dbo.Services", "name", c => c.String());
            AlterColumn("dbo.OnlineProjects", "description", c => c.String());
            AlterColumn("dbo.OnlineProjects", "name", c => c.String());
            AlterColumn("dbo.CarOffers", "phoneNumber", c => c.String());
            AlterColumn("dbo.CarOffers", "description", c => c.String());
            AlterColumn("dbo.CarOffers", "offerTitle", c => c.String());
        }
    }
}
