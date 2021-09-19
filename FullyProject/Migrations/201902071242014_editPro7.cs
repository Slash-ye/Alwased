namespace FullyProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editPro7 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PropertyOffers", "addDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PropertyOffers", "addDate", c => c.DateTime(nullable: false));
        }
    }
}
