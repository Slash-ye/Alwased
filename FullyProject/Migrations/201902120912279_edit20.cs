namespace FullyProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edit20 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Services", "image1", c => c.String());
            AlterColumn("dbo.Services", "image2", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Services", "image2", c => c.String(nullable: false));
            AlterColumn("dbo.Services", "image1", c => c.String(nullable: false));
        }
    }
}
