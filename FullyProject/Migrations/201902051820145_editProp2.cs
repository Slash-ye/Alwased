namespace FullyProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editProp2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PropertyOffers", "PropertyState_Id", "dbo.PropertyStates");
            DropIndex("dbo.PropertyOffers", new[] { "PropertyState_Id" });
            RenameColumn(table: "dbo.PropertyOffers", name: "PropertyState_Id", newName: "PropertyStateId");
            AlterColumn("dbo.PropertyOffers", "PropertyStateId", c => c.Int(nullable: false));
            CreateIndex("dbo.PropertyOffers", "PropertyStateId");
            AddForeignKey("dbo.PropertyOffers", "PropertyStateId", "dbo.PropertyStates", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PropertyOffers", "PropertyStateId", "dbo.PropertyStates");
            DropIndex("dbo.PropertyOffers", new[] { "PropertyStateId" });
            AlterColumn("dbo.PropertyOffers", "PropertyStateId", c => c.Int());
            RenameColumn(table: "dbo.PropertyOffers", name: "PropertyStateId", newName: "PropertyState_Id");
            CreateIndex("dbo.PropertyOffers", "PropertyState_Id");
            AddForeignKey("dbo.PropertyOffers", "PropertyState_Id", "dbo.PropertyStates", "Id");
        }
    }
}
