namespace FullyProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edit11 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.CarOffers", "finishDate");
            DropColumn("dbo.CarOffers", "active");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CarOffers", "active", c => c.Boolean(nullable: false));
            AddColumn("dbo.CarOffers", "finishDate", c => c.DateTime());
        }
    }
}
