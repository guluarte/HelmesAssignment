namespace HelmesAssignment.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SubmissionSector : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SubmissionSectors",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Sector_ID = c.Int(),
                        Submission_ID = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sectors", t => t.Sector_ID)
                .ForeignKey("dbo.Submissions", t => t.Submission_ID)
                .Index(t => t.Sector_ID)
                .Index(t => t.Submission_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SubmissionSectors", "Submission_ID", "dbo.Submissions");
            DropForeignKey("dbo.SubmissionSectors", "Sector_ID", "dbo.Sectors");
            DropIndex("dbo.SubmissionSectors", new[] { "Submission_ID" });
            DropIndex("dbo.SubmissionSectors", new[] { "Sector_ID" });
            DropTable("dbo.SubmissionSectors");
        }
    }
}
