namespace FullyProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editPro3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PropertyOffers", "offerTypeId", "dbo.OfferTypes");
            DropForeignKey("dbo.PropertyOffers", "PropertyType_Id", "dbo.PropertyTypes");
            DropIndex("dbo.PropertyOffers", new[] { "offerTypeId" });
            DropIndex("dbo.PropertyOffers", new[] { "PropertyType_Id" });
            RenameColumn(table: "dbo.PropertyOffers", name: "offerTypeId", newName: "OfferType_Id");
            RenameColumn(table: "dbo.PropertyOffers", name: "PropertyType_Id", newName: "PropertyTypeId");
            AlterColumn("dbo.PropertyOffers", "OfferType_Id", c => c.Int());
            AlterColumn("dbo.PropertyOffers", "PropertyTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.PropertyOffers", "PropertyTypeId");
            CreateIndex("dbo.PropertyOffers", "OfferType_Id");
            AddForeignKey("dbo.PropertyOffers", "OfferType_Id", "dbo.OfferTypes", "Id");
            AddForeignKey("dbo.PropertyOffers", "PropertyTypeId", "dbo.PropertyTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PropertyOffers", "PropertyTypeId", "dbo.PropertyTypes");
            DropForeignKey("dbo.PropertyOffers", "OfferType_Id", "dbo.OfferTypes");
            DropIndex("dbo.PropertyOffers", new[] { "OfferType_Id" });
            DropIndex("dbo.PropertyOffers", new[] { "PropertyTypeId" });
            AlterColumn("dbo.PropertyOffers", "PropertyTypeId", c => c.Int());
            AlterColumn("dbo.PropertyOffers", "OfferType_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.PropertyOffers", name: "PropertyTypeId", newName: "PropertyType_Id");
            RenameColumn(table: "dbo.PropertyOffers", name: "OfferType_Id", newName: "offerTypeId");
            CreateIndex("dbo.PropertyOffers", "PropertyType_Id");
            CreateIndex("dbo.PropertyOffers", "offerTypeId");
            AddForeignKey("dbo.PropertyOffers", "PropertyType_Id", "dbo.PropertyTypes", "Id");
            AddForeignKey("dbo.PropertyOffers", "offerTypeId", "dbo.OfferTypes", "Id", cascadeDelete: true);
        }
    }
}
