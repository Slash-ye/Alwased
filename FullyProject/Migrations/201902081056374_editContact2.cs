namespace FullyProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editContact2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ContactInfoMessages", "PropertyOffer_Id", "dbo.PropertyOffers");
            DropIndex("dbo.ContactInfoMessages", new[] { "PropertyOffer_Id" });
            DropColumn("dbo.ContactInfoMessages", "PropertyOffer_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ContactInfoMessages", "PropertyOffer_Id", c => c.Int());
            CreateIndex("dbo.ContactInfoMessages", "PropertyOffer_Id");
            AddForeignKey("dbo.ContactInfoMessages", "PropertyOffer_Id", "dbo.PropertyOffers", "Id");
        }
    }
}
