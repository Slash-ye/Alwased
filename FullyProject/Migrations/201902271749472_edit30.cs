namespace FullyProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edit30 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Services", "image2");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Services", "image2", c => c.String());
        }
    }
}
