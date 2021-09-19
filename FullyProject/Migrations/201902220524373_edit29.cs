namespace FullyProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edit29 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Photos", "isMain");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Photos", "isMain", c => c.Boolean(nullable: false));
        }
    }
}
