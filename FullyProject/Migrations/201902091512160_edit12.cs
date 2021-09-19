namespace FullyProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edit12 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ContactInfoMessages", "addDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ContactInfoMessages", "addDate");
        }
    }
}
