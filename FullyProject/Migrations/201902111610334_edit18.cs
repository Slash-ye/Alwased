namespace FullyProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edit18 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Photos", "isMain");
            AddColumn("dbo.Photos", "isMain", c => c.Boolean(nullable: false));
            
        }
        
        public override void Down()
        {
            AddColumn("dbo.Photos", "Main", c => c.Boolean(nullable: false));
            DropColumn("dbo.Photos", "isMain");
        }
    }
}
