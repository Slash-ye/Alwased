namespace FullyProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editCar1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CarOffers", "addDate", c => c.DateTime());
            AlterColumn("dbo.CarOffers", "finishDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CarOffers", "finishDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.CarOffers", "addDate", c => c.DateTime(nullable: false));
        }
    }
}
