using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentsActivity
{
    public class ActivityContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Olympiad> Olympiads { get; set; }
        public DbSet<Competition> Competitions { get; set; }
        public DbSet<OlympiadStudentParticipation> OlympiadStudentParticipations { get; set; }
        public DbSet<CompetitionStudentParticipation> CompetitionStudentParticipations { get; set; }

        public ActivityContext() : base("name = ActivityContext") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Student>().HasKey(s => s.StudentId);
            modelBuilder.Entity<Student>().Property(s => s.StudentId).HasColumnName("Student_id");
            modelBuilder.Entity<Student>().Property(s => s.StudentId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            modelBuilder.Entity<Student>().Property(s => s.StudentName).HasColumnName("Student_name");
            modelBuilder.Entity<Student>().Property(s => s.StudentName).HasMaxLength(50);
            modelBuilder.Entity<Student>().Property(s => s.StudentName).IsRequired();
            modelBuilder.Entity<Student>().Property(s => s.Birthdate).IsRequired();
            modelBuilder.Entity<Student>().Property(s => s.Address).HasMaxLength(255);
            modelBuilder.Entity<Student>().Property(s => s.Telephone).HasMaxLength(20);
            modelBuilder.Entity<Student>().Property(s => s.University).HasMaxLength(100);
            modelBuilder.Entity<Olympiad>().HasKey(o => o.OlympiadId);
            modelBuilder.Entity<Olympiad>().Property(o => o.OlympiadId).HasColumnName("Olympiad_id");
            modelBuilder.Entity<Olympiad>().Property(o => o.OlympiadId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            modelBuilder.Entity<Olympiad>().Property(o => o.OlympiadName).HasColumnName("Olympiad_name");
            modelBuilder.Entity<Olympiad>().Property(o => o.OlympiadName).HasMaxLength(255);
            modelBuilder.Entity<Olympiad>().Property(o => o.OlympiadName).IsRequired();
            modelBuilder.Entity<Competition>().HasKey(c => c.CompetitionId);
            modelBuilder.Entity<Competition>().Property(c => c.CompetitionId).HasColumnName("Competition_id");
            modelBuilder.Entity<Competition>().Property(c => c.CompetitionId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            modelBuilder.Entity<Competition>().Property(c => c.CompetitionName).HasColumnName("Competition_name");
            modelBuilder.Entity<Competition>().Property(c => c.CompetitionName).HasMaxLength(255);
            modelBuilder.Entity<Competition>().Property(c => c.CompetitionName).IsRequired();
            modelBuilder.Entity<OlympiadStudentParticipation>().HasKey(o => o.ParticipationId);
            modelBuilder.Entity<OlympiadStudentParticipation>().Property(o => o.ParticipationId).HasColumnName("Participation_id");
            modelBuilder.Entity<OlympiadStudentParticipation>().Property(o => o.ParticipationId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            modelBuilder.Entity<OlympiadStudentParticipation>().Property(o => o.StudentId).HasColumnName("Student_id");
            modelBuilder.Entity<OlympiadStudentParticipation>().HasRequired(o => o.Student).WithMany(s => s.OlympiadStudentParticipation).HasForeignKey(o => o.StudentId).WillCascadeOnDelete(true);
            modelBuilder.Entity<OlympiadStudentParticipation>().Property(o => o.OlympiadId).HasColumnName("Olympiad_id");
            modelBuilder.Entity<OlympiadStudentParticipation>().HasRequired(o => o.Olympiad).WithMany(s => s.OlympiadStudentParticipation).HasForeignKey(o => o.OlympiadId).WillCascadeOnDelete(true);
            modelBuilder.Entity<OlympiadStudentParticipation>().Property(o => o.ParticipationDate).IsRequired();
            modelBuilder.Entity<OlympiadStudentParticipation>().Property(o => o.Place).HasMaxLength(255);
            modelBuilder.Entity<OlympiadStudentParticipation>().Property(o => o.Place).IsRequired();
            modelBuilder.Entity<OlympiadStudentParticipation>().Property(o => o.Results).HasMaxLength(20);
            modelBuilder.Entity<OlympiadStudentParticipation>().Property(o => o.Results).IsRequired();
            modelBuilder.Entity<CompetitionStudentParticipation>().HasKey(o => o.ParticipationId);
            modelBuilder.Entity<CompetitionStudentParticipation>().Property(o => o.ParticipationId).HasColumnName("Participation_id");
            modelBuilder.Entity<CompetitionStudentParticipation>().Property(o => o.ParticipationId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            modelBuilder.Entity<CompetitionStudentParticipation>().Property(o => o.StudentId).HasColumnName("Student_id");
            modelBuilder.Entity<CompetitionStudentParticipation>().HasRequired(o => o.Student).WithMany(s => s.CompetitionStudentParticipation).HasForeignKey(o => o.StudentId).WillCascadeOnDelete(true);
            modelBuilder.Entity<CompetitionStudentParticipation>().Property(o => o.CompetitionId).HasColumnName("Competition_id");
            modelBuilder.Entity<CompetitionStudentParticipation>().HasRequired(o => o.Competition).WithMany(s => s.CompetitionStudentParticipation).HasForeignKey(o => o.CompetitionId).WillCascadeOnDelete(true);
            modelBuilder.Entity<CompetitionStudentParticipation>().Property(o => o.ParticipationDate).IsRequired();
            modelBuilder.Entity<CompetitionStudentParticipation>().Property(o => o.Place).HasMaxLength(255);
            modelBuilder.Entity<CompetitionStudentParticipation>().Property(o => o.Place).IsRequired();
            modelBuilder.Entity<CompetitionStudentParticipation>().Property(o => o.Results).HasMaxLength(20);
            modelBuilder.Entity<CompetitionStudentParticipation>().Property(o => o.Results).IsRequired();
        }
    }
}