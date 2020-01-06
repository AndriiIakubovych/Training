using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebsitesPerformanceEvaluating.Models
{
    public class RequestsSpeedEvaluatingContext : DbContext
    {
        public RequestsSpeedEvaluatingContext() : base("name = RequestsSpeedEvaluatingContext") { }

        public DbSet<Test> Tests { get; set; }
        public DbSet<Page> Pages { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Test>().HasKey(t => t.TestId);
            modelBuilder.Entity<Test>().Property(t => t.TestId).HasColumnName("Test_id");
            modelBuilder.Entity<Test>().Property(t => t.TestId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            modelBuilder.Entity<Test>().Property(t => t.Website).HasColumnType("varchar(MAX)");
            modelBuilder.Entity<Test>().Property(t => t.Website).IsRequired();
            modelBuilder.Entity<Test>().Property(t => t.TestDate).HasColumnName("Test_date");
            modelBuilder.Entity<Test>().Property(t => t.TestDate).IsRequired();
            modelBuilder.Entity<Page>().HasKey(p => p.PageId);
            modelBuilder.Entity<Page>().Property(p => p.PageId).HasColumnName("Page_id");
            modelBuilder.Entity<Page>().Property(p => p.PageId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            modelBuilder.Entity<Page>().Property(p => p.PageAddress).HasColumnName("Page_address");
            modelBuilder.Entity<Page>().Property(p => p.PageAddress).HasColumnType("varchar(MAX)");
            modelBuilder.Entity<Page>().Property(p => p.PageAddress).IsRequired();
            modelBuilder.Entity<Page>().Property(p => p.AverageTime).HasColumnName("Average_time");
            modelBuilder.Entity<Page>().Property(p => p.AverageTime).IsRequired();
            modelBuilder.Entity<Page>().Property(p => p.MinTime).HasColumnName("Min_time");
            modelBuilder.Entity<Page>().Property(p => p.MinTime).IsRequired();
            modelBuilder.Entity<Page>().Property(p => p.MaxTime).HasColumnName("Max_time");
            modelBuilder.Entity<Page>().Property(p => p.MaxTime).IsRequired();
            modelBuilder.Entity<Page>().Property(p => p.Color).HasColumnType("varchar");
            modelBuilder.Entity<Page>().Property(p => p.Color).HasMaxLength(20);
            modelBuilder.Entity<Page>().Property(p => p.TestId).HasColumnName("Test_id");
            modelBuilder.Entity<Page>().HasRequired(p => p.Test).WithMany(t => t.Pages).HasForeignKey(p => p.TestId).WillCascadeOnDelete(true);
        }
    }
}