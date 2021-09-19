namespace FullyProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edit16 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.CarOffers", new[] { "Manager_Id" });
            DropColumn("dbo.CarOffers", "ManagerId");
            RenameColumn(table: "dbo.CarOffers", name: "Manager_Id", newName: "ManagerId");
            AlterColumn("dbo.CarOffers", "ManagerId", c => c.String(maxLength: 128));
            CreateIndex("dbo.CarOffers", "ManagerId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.CarOffers", new[] { "ManagerId" });
            AlterColumn("dbo.CarOffers", "ManagerId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.CarOffers", name: "ManagerId", newName: "Manager_Id");
            AddColumn("dbo.CarOffers", "ManagerId", c => c.Int(nullable: false));
            CreateIndex("dbo.CarOffers", "Manager_Id");
        }
    }
}
