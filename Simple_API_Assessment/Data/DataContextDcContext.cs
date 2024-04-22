using Microsoft.EntityFrameworkCore;
using Simple_API_Assessment.Models;

namespace Simple_API_Assessment.Data
{
    public class DataContextDcContext : DbContext
    {

        public DataContextDcContext (DbContextOptions<DataContextDcContext> options) : base(options) { }


        public DbSet<Applicant> Applicants { get; set; }
        public DbSet<Skill> Skills { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Skill>()
                .HasOne(s => s.Applicant)
                .WithMany(a => a.Skills)
                .HasForeignKey(s => s.ApplicantId);
        }
    }
}
