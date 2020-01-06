using Microsoft.EntityFrameworkCore;

namespace Calendar.Server.Models
{
    public class CalendarContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventType> EventTypes { get; set; }
        public DbSet<UserEventTypeColor> UserEventTypeColors { get; set; }

        public CalendarContext(DbContextOptions<CalendarContext> options) : base(options) 
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            EventType[] eventTypes = new EventType[]
            {
                new EventType() { Id = (int)EventsTypes.SHORT + 1, Name = "Короткое", DefaultColor = "#ad2121" },
                new EventType() { Id = (int)EventsTypes.MIDDLE + 1, Name = "Среднее", DefaultColor = "#e3bc08" },
                new EventType() { Id = (int)EventsTypes.LONG + 1, Name = "Длительное", DefaultColor = "#1e90ff" }
            };
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().HasKey(u => u.Id);
            modelBuilder.Entity<User>().Property(u => u.Id).ValueGeneratedNever();
            modelBuilder.Entity<User>().Property(u => u.Name).HasColumnType("varchar(30)").IsRequired();
            modelBuilder.Entity<User>().Property(u => u.Email).HasColumnType("varchar(50)").IsRequired();
            modelBuilder.Entity<User>().Property(u => u.Password).HasColumnType("varchar(100)").IsRequired();
            modelBuilder.Entity<Event>().HasKey(e => e.Id);
            modelBuilder.Entity<Event>().Property(e => e.Id).ValueGeneratedNever();
            modelBuilder.Entity<Event>().Property(e => e.Name).HasColumnType("varchar(50)").IsRequired();
            modelBuilder.Entity<Event>().Property(e => e.DateStart).HasColumnName("Date_start").HasColumnType("datetime").IsRequired();
            modelBuilder.Entity<Event>().Property(e => e.DateEnd).HasColumnName("Date_end").HasColumnType("datetime").IsRequired();
            modelBuilder.Entity<Event>().HasOne(e => e.EventType).WithMany(et => et.Events).HasForeignKey(e => e.TypeId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Event>().Property(e => e.TypeId).HasColumnName("Type_id").IsRequired();
            modelBuilder.Entity<Event>().Property(e => e.Location).HasColumnType("varchar(100)");
            modelBuilder.Entity<Event>().Property(e => e.Description).HasColumnType("varchar(MAX)");
            modelBuilder.Entity<Event>().HasOne(e => e.User).WithMany(u => u.Events).HasForeignKey(e => e.UserId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Event>().Property(e => e.UserId).HasColumnName("User_id").IsRequired();
            modelBuilder.Entity<EventType>().HasKey(et => et.Id);
            modelBuilder.Entity<EventType>().Property(et => et.Id).ValueGeneratedNever();
            modelBuilder.Entity<EventType>().Property(et => et.Name).HasColumnType("varchar(20)").IsRequired();
            modelBuilder.Entity<EventType>().Property(et => et.DefaultColor).HasColumnName("Default_color").HasColumnType("varchar(10)").IsRequired();
            modelBuilder.Entity<EventType>().HasData(eventTypes);
            modelBuilder.Entity<UserEventTypeColor>().HasKey(uetc => uetc.Id);
            modelBuilder.Entity<UserEventTypeColor>().Property(uetc => uetc.Id).ValueGeneratedNever();
            modelBuilder.Entity<UserEventTypeColor>().HasOne(uetc => uetc.User).WithMany(u => u.UserEventTypeColors).HasForeignKey(uetc => uetc.UserId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<UserEventTypeColor>().Property(uetc => uetc.UserId).HasColumnName("User_id").IsRequired();
            modelBuilder.Entity<UserEventTypeColor>().HasOne(uetc => uetc.EventType).WithMany(et => et.UserEventTypeColors).HasForeignKey(uetc => uetc.TypeId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<UserEventTypeColor>().Property(uetc => uetc.TypeId).HasColumnName("Type_id").IsRequired();
            modelBuilder.Entity<UserEventTypeColor>().Property(uetc => uetc.Color).HasColumnType("varchar(10)").IsRequired();
        }
    }
}