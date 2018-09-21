namespace HelmesAssignment.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BaseTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Sectors",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        Name = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        ParentSector_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Sectors", t => t.ParentSector_ID)
                .Index(t => t.ParentSector_ID);
            
            CreateTable(
                "dbo.Submissions",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Name = c.String(),
                        SessionId = c.String(),
                        AgreeToTerms = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sectors", "ParentSector_ID", "dbo.Sectors");
            DropIndex("dbo.Sectors", new[] { "ParentSector_ID" });
            DropTable("dbo.Submissions");
            DropTable("dbo.Sectors");
        }
    }
}
