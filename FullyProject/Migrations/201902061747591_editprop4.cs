namespace FullyProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editprop4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PropertyOffers", "currencyTypeId", "dbo.CurrencyTypes");
            DropForeignKey("dbo.PropertyOffers", "distanceUnitId", "dbo.DistanceUnits");
            DropForeignKey("dbo.PropertyOffers", "PropertyStateId", "dbo.PropertyStates");
            DropForeignKey("dbo.PropertyOffers", "PropertyTypeId", "dbo.PropertyTypes");
            DropIndex("dbo.PropertyOffers", new[] { "PropertyTypeId" });
            DropIndex("dbo.PropertyOffers", new[] { "currencyTypeId" });
            DropIndex("dbo.PropertyOffers", new[] { "distanceUnitId" });
            DropIndex("dbo.PropertyOffers", new[] { "PropertyStateId" });
            AlterColumn("dbo.PropertyOffers", "PropertyTypeId", c => c.Int());
            AlterColumn("dbo.PropertyOffers", "currencyTypeId", c => c.Int());
            AlterColumn("dbo.PropertyOffers", "distanceUnitId", c => c.Int());
            AlterColumn("dbo.PropertyOffers", "PropertyStateId", c => c.Int());
            CreateIndex("dbo.PropertyOffers", "PropertyTypeId");
            CreateIndex("dbo.PropertyOffers", "currencyTypeId");
            CreateIndex("dbo.PropertyOffers", "distanceUnitId");
            CreateIndex("dbo.PropertyOffers", "PropertyStateId");
            AddForeignKey("dbo.PropertyOffers", "currencyTypeId", "dbo.CurrencyTypes", "Id");
            AddForeignKey("dbo.PropertyOffers", "distanceUnitId", "dbo.DistanceUnits", "Id");
            AddForeignKey("dbo.PropertyOffers", "PropertyStateId", "dbo.PropertyStates", "Id");
            AddForeignKey("dbo.PropertyOffers", "PropertyTypeId", "dbo.PropertyTypes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PropertyOffers", "PropertyTypeId", "dbo.PropertyTypes");
            DropForeignKey("dbo.PropertyOffers", "PropertyStateId", "dbo.PropertyStates");
            DropForeignKey("dbo.PropertyOffers", "distanceUnitId", "dbo.DistanceUnits");
            DropForeignKey("dbo.PropertyOffers", "currencyTypeId", "dbo.CurrencyTypes");
            DropIndex("dbo.PropertyOffers", new[] { "PropertyStateId" });
            DropIndex("dbo.PropertyOffers", new[] { "distanceUnitId" });
            DropIndex("dbo.PropertyOffers", new[] { "currencyTypeId" });
            DropIndex("dbo.PropertyOffers", new[] { "PropertyTypeId" });
            AlterColumn("dbo.PropertyOffers", "PropertyStateId", c => c.Int(nullable: false));
            AlterColumn("dbo.PropertyOffers", "distanceUnitId", c => c.Int(nullable: false));
            AlterColumn("dbo.PropertyOffers", "currencyTypeId", c => c.Int(nullable: false));
            AlterColumn("dbo.PropertyOffers", "PropertyTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.PropertyOffers", "PropertyStateId");
            CreateIndex("dbo.PropertyOffers", "distanceUnitId");
            CreateIndex("dbo.PropertyOffers", "currencyTypeId");
            CreateIndex("dbo.PropertyOffers", "PropertyTypeId");
            AddForeignKey("dbo.PropertyOffers", "PropertyTypeId", "dbo.PropertyTypes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PropertyOffers", "PropertyStateId", "dbo.PropertyStates", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PropertyOffers", "distanceUnitId", "dbo.DistanceUnits", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PropertyOffers", "currencyTypeId", "dbo.CurrencyTypes", "Id", cascadeDelete: true);
        }
    }
}
