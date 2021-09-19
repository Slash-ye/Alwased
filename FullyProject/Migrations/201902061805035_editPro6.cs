namespace FullyProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editPro6 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PropertyOffers", "doneDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PropertyOffers", "doneDate", c => c.DateTime(nullable: false));
        }
    }
}
