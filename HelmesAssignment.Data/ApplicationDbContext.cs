using HelmesAssignment.Entities.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace HelmesAssignment.DataLayer
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Sector> Sectors { get; set; }
        public DbSet<Submission> Submissions { get; set; }
        public DbSet<SubmissionSector> SubmissionSectors { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sector>().HasOptional(b => b.ParentSector);

            base.OnModelCreating(modelBuilder);
        }
    }
}
