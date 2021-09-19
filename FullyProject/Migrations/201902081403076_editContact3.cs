namespace FullyProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editContact3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ContactInfoMessages", "active", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ContactInfoMessages", "active");
        }
    }
}
