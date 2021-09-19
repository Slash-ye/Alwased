namespace FullyProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editModel : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.PropertyOffers", name: "Manager_Id", newName: "ManagerId");
            RenameIndex(table: "dbo.PropertyOffers", name: "IX_Manager_Id", newName: "IX_ManagerId");
            AddColumn("dbo.CarOffers", "ManagerId", c => c.Int(nullable: false));
            DropColumn("dbo.CarOffers", "UserId");
            DropColumn("dbo.PropertyOffers", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PropertyOffers", "UserId", c => c.String());
            AddColumn("dbo.CarOffers", "UserId", c => c.Int(nullable: false));
            DropColumn("dbo.CarOffers", "ManagerId");
            RenameIndex(table: "dbo.PropertyOffers", name: "IX_ManagerId", newName: "IX_Manager_Id");
            RenameColumn(table: "dbo.PropertyOffers", name: "ManagerId", newName: "Manager_Id");
        }
    }
}
