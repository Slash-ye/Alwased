namespace FullyProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edit17 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Photos", "isMain", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Photos", "Main");
        }
    }
}
