using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using Phonebook.Server.Models.Entities;

namespace Phonebook.Server.Models.EntityFramework
{
    public class PhonebookContext : DbContext
    {
        public PhonebookContext() : base("name = PhonebookContext") { }

        public DbSet<Subject> Subjects { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Subject>().HasKey(s => s.Id);
            modelBuilder.Entity<Subject>().Property(s => s.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            modelBuilder.Entity<Subject>().Property(s => s.Name).HasColumnType("varchar");
            modelBuilder.Entity<Subject>().Property(s => s.Name).HasMaxLength(100);
            modelBuilder.Entity<Subject>().Property(s => s.Name).IsRequired();
            modelBuilder.Entity<Subject>().Property(s => s.Type).HasColumnType("varchar");
            modelBuilder.Entity<Subject>().Property(s => s.Type).HasMaxLength(50);
            modelBuilder.Entity<Subject>().Property(s => s.Type).IsRequired();
            modelBuilder.Entity<Subject>().Property(s => s.Address).HasColumnType("varchar(MAX)");
            modelBuilder.Entity<Subject>().Property(s => s.Telephone).HasColumnType("varchar");
            modelBuilder.Entity<Subject>().Property(s => s.Telephone).HasMaxLength(20);
            modelBuilder.Entity<Subject>().Property(s => s.Telephone).IsRequired();
        }
    }
}