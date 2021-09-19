namespace FullyProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edit191 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OnlineProjects", "ManagerId", c => c.String(maxLength: 128));
            CreateIndex("dbo.OnlineProjects", "ManagerId");
            AddForeignKey("dbo.OnlineProjects", "ManagerId", "dbo.User", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OnlineProjects", "ManagerId", "dbo.User");
            DropIndex("dbo.OnlineProjects", new[] { "ManagerId" });
            DropColumn("dbo.OnlineProjects", "ManagerId");
        }
    }
}
