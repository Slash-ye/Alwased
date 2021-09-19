namespace FullyProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CarOffers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        offerTitle = c.String(),
                        code = c.String(),
                        carModel = c.String(),
                        carType = c.String(),
                        price = c.Decimal(precision: 18, scale: 2),
                        description = c.String(),
                        phoneNumber = c.String(),
                        addDate = c.DateTime(nullable: false),
                        finishDate = c.DateTime(nullable: false),
                        active = c.Boolean(nullable: false),
                        publish = c.Boolean(nullable: false),
                        currencyId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        CurrencyType_Id = c.Int(),
                        Manager_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CurrencyTypes", t => t.CurrencyType_Id)
                .ForeignKey("dbo.User", t => t.Manager_Id)
                .Index(t => t.CurrencyType_Id)
                .Index(t => t.Manager_Id);
            
            CreateTable(
                "dbo.CurrencyTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        currencyName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PropertyOffers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        code = c.String(),
                        country = c.String(),
                        city = c.String(),
                        address = c.String(),
                        price = c.Decimal(precision: 18, scale: 2),
                        isArgumented = c.Boolean(nullable: false),
                        distance = c.Int(),
                        addDate = c.DateTime(nullable: false),
                        doneDate = c.DateTime(nullable: false),
                        publish = c.Boolean(nullable: false),
                        phoneNumber = c.String(),
                        description = c.String(),
                        active = c.Boolean(nullable: false),
                        bedroomNumber = c.Int(),
                        bathroomNumber = c.Int(),
                        offerTypeId = c.Int(nullable: false),
                        currencyTypeId = c.Int(nullable: false),
                        distanceUnitId = c.Int(nullable: false),
                        UserId = c.String(),
                        Manager_Id = c.String(maxLength: 128),
                        PropertyState_Id = c.Int(),
                        PropertyType_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CurrencyTypes", t => t.currencyTypeId, cascadeDelete: true)
                .ForeignKey("dbo.DistanceUnits", t => t.distanceUnitId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.Manager_Id)
                .ForeignKey("dbo.OfferTypes", t => t.offerTypeId, cascadeDelete: true)
                .ForeignKey("dbo.PropertyStates", t => t.PropertyState_Id)
                .ForeignKey("dbo.PropertyTypes", t => t.PropertyType_Id)
                .Index(t => t.offerTypeId)
                .Index(t => t.currencyTypeId)
                .Index(t => t.distanceUnitId)
                .Index(t => t.Manager_Id)
                .Index(t => t.PropertyState_Id)
                .Index(t => t.PropertyType_Id);
            
            CreateTable(
                "dbo.ContactInfoMessages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        fullName = c.String(),
                        message = c.String(),
                        email = c.String(),
                        phoneNumber = c.String(),
                        codeOfInterest = c.String(),
                        propertyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PropertyOffers", t => t.propertyId, cascadeDelete: true)
                .Index(t => t.propertyId);
            
            CreateTable(
                "dbo.DistanceUnits",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        unitName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OfferTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        offerName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OnlineProjects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        dateOfStarted = c.DateTime(nullable: false),
                        description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Photos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        path = c.String(),
                        photoOwnerId = c.Int(nullable: false),
                        elementid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PhotoOwners", t => t.photoOwnerId, cascadeDelete: true)
                .Index(t => t.photoOwnerId);
            
            CreateTable(
                "dbo.PhotoOwners",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        objName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PropertyStates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StateName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PropertyTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TypeName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        description = c.String(),
                        image1 = c.String(),
                        image2 = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SubscriptionEmails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        email = c.String(),
                        active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PropertyOffers", "PropertyType_Id", "dbo.PropertyTypes");
            DropForeignKey("dbo.PropertyOffers", "PropertyState_Id", "dbo.PropertyStates");
            DropForeignKey("dbo.Photos", "photoOwnerId", "dbo.PhotoOwners");
            DropForeignKey("dbo.CarOffers", "Manager_Id", "dbo.User");
            DropForeignKey("dbo.PropertyOffers", "offerTypeId", "dbo.OfferTypes");
            DropForeignKey("dbo.PropertyOffers", "Manager_Id", "dbo.User");
            DropForeignKey("dbo.PropertyOffers", "distanceUnitId", "dbo.DistanceUnits");
            DropForeignKey("dbo.PropertyOffers", "currencyTypeId", "dbo.CurrencyTypes");
            DropForeignKey("dbo.ContactInfoMessages", "propertyId", "dbo.PropertyOffers");
            DropForeignKey("dbo.CarOffers", "CurrencyType_Id", "dbo.CurrencyTypes");
            DropIndex("dbo.Photos", new[] { "photoOwnerId" });
            DropIndex("dbo.ContactInfoMessages", new[] { "propertyId" });
            DropIndex("dbo.PropertyOffers", new[] { "PropertyType_Id" });
            DropIndex("dbo.PropertyOffers", new[] { "PropertyState_Id" });
            DropIndex("dbo.PropertyOffers", new[] { "Manager_Id" });
            DropIndex("dbo.PropertyOffers", new[] { "distanceUnitId" });
            DropIndex("dbo.PropertyOffers", new[] { "currencyTypeId" });
            DropIndex("dbo.PropertyOffers", new[] { "offerTypeId" });
            DropIndex("dbo.CarOffers", new[] { "Manager_Id" });
            DropIndex("dbo.CarOffers", new[] { "CurrencyType_Id" });
            DropTable("dbo.SubscriptionEmails");
            DropTable("dbo.Services");
            DropTable("dbo.PropertyTypes");
            DropTable("dbo.PropertyStates");
            DropTable("dbo.PhotoOwners");
            DropTable("dbo.Photos");
            DropTable("dbo.OnlineProjects");
            DropTable("dbo.OfferTypes");
            DropTable("dbo.DistanceUnits");
            DropTable("dbo.ContactInfoMessages");
            DropTable("dbo.PropertyOffers");
            DropTable("dbo.CurrencyTypes");
            DropTable("dbo.CarOffers");
        }
    }
}
