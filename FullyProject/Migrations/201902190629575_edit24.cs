namespace FullyProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edit24 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CurrencyTypes", "currencyName", c => c.String(nullable: false));
            AlterColumn("dbo.DistanceUnits", "unitName", c => c.String(nullable: false));
            AlterColumn("dbo.PropertyStates", "StateName", c => c.String(nullable: false));
            AlterColumn("dbo.PropertyTypes", "TypeName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PropertyTypes", "TypeName", c => c.String());
            AlterColumn("dbo.PropertyStates", "StateName", c => c.String());
            AlterColumn("dbo.DistanceUnits", "unitName", c => c.String());
            AlterColumn("dbo.CurrencyTypes", "currencyName", c => c.String());
        }
    }
}
