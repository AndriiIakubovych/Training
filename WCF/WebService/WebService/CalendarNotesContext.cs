using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebService
{
    public class CalendarNotesContext : DbContext
    {
        public CalendarNotesContext() : base("name = CalendarNotesContext") { }

        public DbSet<Note> Notes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Note>().HasKey(k => k.NoteId);
            modelBuilder.Entity<Note>().Property(p => p.NoteId).HasColumnName("Note_id");
            modelBuilder.Entity<Note>().Property(p => p.NoteId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            modelBuilder.Entity<Note>().Property(p => p.NoteName).HasColumnName("Note_name");
            modelBuilder.Entity<Note>().Property(p => p.NoteName).HasColumnType("varchar");
            modelBuilder.Entity<Note>().Property(p => p.NoteName).HasMaxLength(40);
            modelBuilder.Entity<Note>().Property(p => p.NoteName).IsRequired();
            modelBuilder.Entity<Note>().Property(p => p.BeginningTime).HasColumnName("Beginning_date");
            modelBuilder.Entity<Note>().Property(p => p.BeginningTime).IsRequired();
            modelBuilder.Entity<Note>().Property(p => p.EndTime).HasColumnName("End_date");
            modelBuilder.Entity<Note>().Property(p => p.EndTime).IsRequired();
            modelBuilder.Entity<Note>().Property(p => p.Description).HasColumnType("varchar");
            modelBuilder.Entity<Note>().Property(p => p.Description).HasMaxLength(255);
            modelBuilder.Entity<Note>().Property(p => p.Done).IsRequired();
        }
    }
}