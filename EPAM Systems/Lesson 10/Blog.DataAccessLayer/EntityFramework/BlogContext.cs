using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNet.Identity.EntityFramework;
using Blog.DataAccessLayer.Entities;

namespace Blog.DataAccessLayer.EntityFramework
{
    public class BlogContext : IdentityDbContext<BlogUser>
    {
        public DbSet<ClientProfile> ClientProfiles { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<TestResult> TestResults { get; set; }
        public DbSet<Vote> Votes { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<ArticleTag> ArticleTags { get; set; }

        public BlogContext(string connectionString) : base(connectionString) { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Article>().HasKey(a => a.ArticleId);
            modelBuilder.Entity<Article>().Property(a => a.ArticleId).HasColumnName("Article_id");
            modelBuilder.Entity<Article>().Property(a => a.ArticleId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            modelBuilder.Entity<Article>().Property(a => a.ArticleName).HasColumnName("Article_name");
            modelBuilder.Entity<Article>().Property(a => a.ArticleName).HasColumnType("varchar");
            modelBuilder.Entity<Article>().Property(a => a.ArticleName).HasMaxLength(100);
            modelBuilder.Entity<Article>().Property(a => a.ArticleName).IsRequired();
            modelBuilder.Entity<Article>().Property(a => a.PublicationDate).HasColumnName("Publication_date");
            modelBuilder.Entity<Article>().Property(a => a.PublicationDate).HasColumnType("date");
            modelBuilder.Entity<Article>().Property(a => a.PublicationDate).IsRequired();
            modelBuilder.Entity<Article>().Property(a => a.ArticleContent).HasColumnName("Article_content");
            modelBuilder.Entity<Article>().Property(a => a.ArticleContent).HasColumnType("text");
            modelBuilder.Entity<Article>().Property(a => a.ArticleContent).IsRequired();
            modelBuilder.Entity<Comment>().HasKey(c => c.CommentId);
            modelBuilder.Entity<Comment>().Property(c => c.CommentId).HasColumnName("Comment_id");
            modelBuilder.Entity<Comment>().Property(c => c.CommentId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            modelBuilder.Entity<Comment>().Property(c => c.AuthorName).HasColumnName("Author_name");
            modelBuilder.Entity<Comment>().Property(c => c.AuthorName).HasColumnType("varchar");
            modelBuilder.Entity<Comment>().Property(c => c.AuthorName).HasMaxLength(50);
            modelBuilder.Entity<Comment>().Property(c => c.AuthorName).IsRequired();
            modelBuilder.Entity<Comment>().Property(c => c.CommentDate).HasColumnName("Publication_date");
            modelBuilder.Entity<Article>().Property(a => a.PublicationDate).IsRequired();
            modelBuilder.Entity<Comment>().Property(c => c.CommentText).HasColumnName("Comment_text");
            modelBuilder.Entity<Comment>().Property(c => c.CommentText).HasColumnType("text");
            modelBuilder.Entity<Comment>().Property(c => c.CommentText).IsRequired();
            modelBuilder.Entity<TestResult>().HasKey(r => r.ResultId);
            modelBuilder.Entity<TestResult>().Property(r => r.ResultId).HasColumnName("Result_id");
            modelBuilder.Entity<TestResult>().Property(r => r.ResultId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            modelBuilder.Entity<TestResult>().Property(r => r.RespondentName).HasColumnName("Respondent_name");
            modelBuilder.Entity<TestResult>().Property(r => r.RespondentName).HasColumnType("varchar");
            modelBuilder.Entity<TestResult>().Property(r => r.RespondentName).HasMaxLength(50);
            modelBuilder.Entity<TestResult>().Property(r => r.RespondentName).IsRequired();
            modelBuilder.Entity<TestResult>().Property(r => r.Gender).HasColumnType("varchar");
            modelBuilder.Entity<TestResult>().Property(r => r.Gender).HasMaxLength(10);
            modelBuilder.Entity<TestResult>().Property(r => r.Gender).IsRequired();
            modelBuilder.Entity<TestResult>().Property(r => r.Age).HasColumnType("varchar");
            modelBuilder.Entity<TestResult>().Property(r => r.Age).HasMaxLength(20);
            modelBuilder.Entity<TestResult>().Property(r => r.Age).IsRequired();
            modelBuilder.Entity<TestResult>().Property(r => r.Country).HasColumnType("varchar");
            modelBuilder.Entity<TestResult>().Property(r => r.Country).HasMaxLength(50);
            modelBuilder.Entity<TestResult>().Property(r => r.Country).IsRequired();
            modelBuilder.Entity<TestResult>().Property(r => r.HasComputerEducation).HasColumnName("Has_computer_education");
            modelBuilder.Entity<TestResult>().Property(r => r.HasComputerEducation).HasColumnType("varchar");
            modelBuilder.Entity<TestResult>().Property(r => r.HasComputerEducation).HasMaxLength(3);
            modelBuilder.Entity<TestResult>().Property(r => r.HasComputerEducation).IsRequired();
            modelBuilder.Entity<TestResult>().Property(r => r.FoundOutBy).HasColumnName("Found_out_by");
            modelBuilder.Entity<TestResult>().Property(r => r.FoundOutBy).HasColumnType("varchar(MAX)");
            modelBuilder.Entity<TestResult>().Property(r => r.ComputerType).HasColumnName("Computer_type");
            modelBuilder.Entity<TestResult>().Property(r => r.ComputerType).HasColumnType("varchar(MAX)");
            modelBuilder.Entity<TestResult>().Property(r => r.OperationSystem).HasColumnName("Operation_system");
            modelBuilder.Entity<TestResult>().Property(r => r.OperationSystem).HasColumnType("varchar(MAX)");
            modelBuilder.Entity<TestResult>().Property(r => r.ReadsOtherBlogs).HasColumnName("Reads_other_blogs");
            modelBuilder.Entity<TestResult>().Property(r => r.ReadsOtherBlogs).HasColumnType("varchar");
            modelBuilder.Entity<TestResult>().Property(r => r.ReadsOtherBlogs).HasMaxLength(3);
            modelBuilder.Entity<TestResult>().Property(r => r.ReadsOtherBlogs).IsRequired();
            modelBuilder.Entity<Vote>().HasKey(v => v.VoteId);
            modelBuilder.Entity<Vote>().Property(v => v.VoteId).HasColumnName("Vote_id");
            modelBuilder.Entity<Vote>().Property(v => v.VoteId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            modelBuilder.Entity<Vote>().Property(v => v.VoteName).HasColumnName("Vote_name");
            modelBuilder.Entity<Vote>().Property(v => v.VoteName).HasColumnType("varchar");
            modelBuilder.Entity<Vote>().Property(v => v.VoteName).HasMaxLength(50);
            modelBuilder.Entity<Vote>().Property(v => v.VoteName).IsRequired();
            modelBuilder.Entity<Vote>().Property(v => v.Date).IsRequired();
            modelBuilder.Entity<Tag>().HasKey(t => t.TagId);
            modelBuilder.Entity<Tag>().Property(t => t.TagId).HasColumnName("Tag_id");
            modelBuilder.Entity<Tag>().Property(t => t.TagId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            modelBuilder.Entity<Tag>().Property(t => t.TagName).HasColumnName("Tag_name");
            modelBuilder.Entity<Tag>().Property(t => t.TagName).HasColumnType("varchar");
            modelBuilder.Entity<Tag>().Property(t => t.TagName).HasMaxLength(20);
            modelBuilder.Entity<Tag>().Property(t => t.TagName).IsRequired();
            modelBuilder.Entity<ArticleTag>().HasKey(at => new { at.ArticleId, at.TagId });
            modelBuilder.Entity<ArticleTag>().HasRequired(at => at.Article).WithMany(a => a.ArticleTags).HasForeignKey(at => at.ArticleId).WillCascadeOnDelete(true);
            modelBuilder.Entity<ArticleTag>().Property(at => at.ArticleId).HasColumnName("Article_id");
            modelBuilder.Entity<ArticleTag>().Property(at => at.ArticleId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            modelBuilder.Entity<ArticleTag>().HasRequired(at => at.Tag).WithMany(t => t.ArticleTags).HasForeignKey(at => at.TagId).WillCascadeOnDelete(true);
            modelBuilder.Entity<ArticleTag>().Property(at => at.TagId).HasColumnName("Tag_id");
            modelBuilder.Entity<ArticleTag>().Property(at => at.TagId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
        }
    }
}