namespace FullyProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edit23 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Photos", "photoOwnerId", "dbo.PhotoOwners");
            DropIndex("dbo.Photos", new[] { "photoOwnerId" });
            DropTable("dbo.PhotoOwners");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.PhotoOwners",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        objName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Photos", "photoOwnerId");
            AddForeignKey("dbo.Photos", "photoOwnerId", "dbo.PhotoOwners", "Id", cascadeDelete: true);
        }
    }
}
