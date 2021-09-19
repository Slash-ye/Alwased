namespace FullyProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editContact1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ContactInfoMessages", "propertyId", "dbo.PropertyOffers");
            DropIndex("dbo.ContactInfoMessages", new[] { "propertyId" });
            RenameColumn(table: "dbo.ContactInfoMessages", name: "propertyId", newName: "PropertyOffer_Id");
            AddColumn("dbo.ContactInfoMessages", "isRead", c => c.Boolean(nullable: false));
            AlterColumn("dbo.ContactInfoMessages", "PropertyOffer_Id", c => c.Int());
            CreateIndex("dbo.ContactInfoMessages", "PropertyOffer_Id");
            AddForeignKey("dbo.ContactInfoMessages", "PropertyOffer_Id", "dbo.PropertyOffers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ContactInfoMessages", "PropertyOffer_Id", "dbo.PropertyOffers");
            DropIndex("dbo.ContactInfoMessages", new[] { "PropertyOffer_Id" });
            AlterColumn("dbo.ContactInfoMessages", "PropertyOffer_Id", c => c.Int(nullable: false));
            DropColumn("dbo.ContactInfoMessages", "isRead");
            RenameColumn(table: "dbo.ContactInfoMessages", name: "PropertyOffer_Id", newName: "propertyId");
            CreateIndex("dbo.ContactInfoMessages", "propertyId");
            AddForeignKey("dbo.ContactInfoMessages", "propertyId", "dbo.PropertyOffers", "Id", cascadeDelete: true);
        }
    }
}
