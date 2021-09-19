namespace FullyProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edit21 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PropertyOffers", "OfferType_Id", "dbo.OfferTypes");
            DropIndex("dbo.PropertyOffers", new[] { "OfferType_Id" });
            DropColumn("dbo.PropertyOffers", "OfferType_Id");
            DropTable("dbo.OfferTypes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.OfferTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        offerName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.PropertyOffers", "OfferType_Id", c => c.Int());
            CreateIndex("dbo.PropertyOffers", "OfferType_Id");
            AddForeignKey("dbo.PropertyOffers", "OfferType_Id", "dbo.OfferTypes", "Id");
        }
    }
}
