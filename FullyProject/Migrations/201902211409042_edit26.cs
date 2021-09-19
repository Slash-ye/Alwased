namespace FullyProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edit26 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Role", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Role", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
    }
}
