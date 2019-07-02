using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelEconomy
{
    public class HotelContext : DbContext
    {
        public HotelContext() : base("name = HotelContext") { }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<RoomsHiringOut> RoomsHiringOut { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Client>().HasKey(k => k.ClientId);
            modelBuilder.Entity<Client>().Property(p => p.ClientId).HasColumnName("Client_id");
            modelBuilder.Entity<Client>().Property(p => p.ClientId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            modelBuilder.Entity<Client>().Property(p => p.ClientName).HasColumnName("Client_name");
            modelBuilder.Entity<Client>().Property(p => p.ClientName).HasColumnType("varchar");
            modelBuilder.Entity<Client>().Property(p => p.ClientName).HasMaxLength(50);
            modelBuilder.Entity<Client>().Property(p => p.ClientName).IsRequired();
            modelBuilder.Entity<Client>().Property(p => p.Sex).HasColumnType("varchar");
            modelBuilder.Entity<Client>().Property(p => p.Sex).HasMaxLength(10);
            modelBuilder.Entity<Client>().Property(p => p.Sex).IsRequired();
            modelBuilder.Entity<Client>().Property(p => p.Birthdate).HasColumnType("date");
            modelBuilder.Entity<Client>().Property(p => p.PassportData).HasColumnType("varchar");
            modelBuilder.Entity<Client>().Property(p => p.PassportData).HasMaxLength(255);
            modelBuilder.Entity<Client>().Property(p => p.PassportData).IsRequired();
            modelBuilder.Entity<Client>().Property(p => p.Address).HasColumnType("varchar");
            modelBuilder.Entity<Client>().Property(p => p.Address).HasMaxLength(255);
            modelBuilder.Entity<Client>().Property(p => p.Address).IsRequired();
            modelBuilder.Entity<Client>().Property(p => p.Telephone).HasColumnType("varchar");
            modelBuilder.Entity<Client>().Property(p => p.Telephone).HasMaxLength(20);
            modelBuilder.Entity<Client>().Property(p => p.Telephone).IsRequired();
            modelBuilder.Entity<Client>().Property(p => p.Nationality).HasColumnType("varchar");
            modelBuilder.Entity<Client>().Property(p => p.Nationality).HasMaxLength(20);
            modelBuilder.Entity<Client>().Property(p => p.Nationality).IsRequired();
            modelBuilder.Entity<Room>().HasKey(k => k.RoomId);
            modelBuilder.Entity<Room>().Property(p => p.RoomId).HasColumnName("Room_id");
            modelBuilder.Entity<Room>().Property(p => p.RoomId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            modelBuilder.Entity<Room>().Property(p => p.RoomNumber).HasColumnName("Room_number");
            modelBuilder.Entity<Room>().Property(p => p.Category).HasColumnType("varchar");
            modelBuilder.Entity<Room>().Property(p => p.Category).HasMaxLength(50);
            modelBuilder.Entity<Room>().Property(p => p.Category).IsRequired();
            modelBuilder.Entity<Room>().Property(p => p.PlacesCount).HasColumnName("Places_count");
            modelBuilder.Entity<Room>().Property(p => p.EmployeeId).HasColumnName("Employee_id");
            modelBuilder.Entity<Room>().HasRequired(e => e.Employee).WithMany(r => r.Rooms).HasForeignKey(k => k.EmployeeId).WillCascadeOnDelete(true);
            modelBuilder.Entity<Employee>().HasKey(k => k.EmployeeId);
            modelBuilder.Entity<Employee>().Property(p => p.EmployeeId).HasColumnName("Employee_id");
            modelBuilder.Entity<Employee>().Property(p => p.EmployeeId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            modelBuilder.Entity<Employee>().Property(p => p.EmployeeName).HasColumnName("Employee_name");
            modelBuilder.Entity<Employee>().Property(p => p.EmployeeName).HasColumnType("varchar");
            modelBuilder.Entity<Employee>().Property(p => p.EmployeeName).HasMaxLength(50);
            modelBuilder.Entity<Employee>().Property(p => p.EmployeeName).IsRequired();
            modelBuilder.Entity<Employee>().Property(p => p.Birthdate).HasColumnType("date");
            modelBuilder.Entity<Employee>().Property(p => p.Position).HasColumnType("varchar");
            modelBuilder.Entity<Employee>().Property(p => p.Position).HasMaxLength(100);
            modelBuilder.Entity<Employee>().Property(p => p.Position).IsRequired();
            modelBuilder.Entity<Employee>().Property(p => p.Address).HasColumnType("varchar");
            modelBuilder.Entity<Employee>().Property(p => p.Address).HasMaxLength(255);
            modelBuilder.Entity<Employee>().Property(p => p.Address).IsRequired();
            modelBuilder.Entity<Employee>().Property(p => p.Telephone).HasColumnType("varchar");
            modelBuilder.Entity<Employee>().Property(p => p.Telephone).HasMaxLength(20);
            modelBuilder.Entity<Employee>().Property(p => p.Telephone).IsRequired();
            modelBuilder.Entity<RoomsHiringOut>().HasKey(k => k.RoomsHiringOutId);
            modelBuilder.Entity<RoomsHiringOut>().Property(p => p.RoomsHiringOutId).HasColumnName("Hiring_id");
            modelBuilder.Entity<RoomsHiringOut>().Property(p => p.RoomsHiringOutId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            modelBuilder.Entity<RoomsHiringOut>().Property(p => p.RoomId).HasColumnName("Room_id");
            modelBuilder.Entity<RoomsHiringOut>().HasRequired(e => e.Room).WithMany(r => r.RoomsHiringOut).HasForeignKey(k => k.RoomId).WillCascadeOnDelete(true);
            modelBuilder.Entity<RoomsHiringOut>().Property(p => p.ClientId).HasColumnName("Client_id");
            modelBuilder.Entity<RoomsHiringOut>().HasRequired(e => e.Client).WithMany(r => r.RoomsHiringOut).HasForeignKey(k => k.ClientId).WillCascadeOnDelete(true);
            modelBuilder.Entity<RoomsHiringOut>().Property(p => p.BeginningDate).HasColumnName("Beginning_date");
            modelBuilder.Entity<RoomsHiringOut>().Property(p => p.BeginningDate).HasColumnType("date");
            modelBuilder.Entity<RoomsHiringOut>().Property(p => p.DaysCount).HasColumnName("Days_count");
            modelBuilder.Entity<Expense>().HasKey(k => k.ExpenseId);
            modelBuilder.Entity<Expense>().Property(p => p.ExpenseId).HasColumnName("Expense_id");
            modelBuilder.Entity<Expense>().Property(p => p.ExpenseId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            modelBuilder.Entity<Expense>().Property(p => p.ExpenseName).HasColumnName("Expense_name");
            modelBuilder.Entity<Expense>().Property(p => p.ExpenseName).HasColumnType("varchar");
            modelBuilder.Entity<Expense>().Property(p => p.ExpenseName).HasMaxLength(255);
            modelBuilder.Entity<Expense>().Property(p => p.ExpenseName).IsRequired();
            modelBuilder.Entity<Expense>().Property(p => p.ExpenseDate).HasColumnName("Expense_date");
            modelBuilder.Entity<Expense>().Property(p => p.ExpenseDate).HasColumnType("date");
            modelBuilder.Entity<Expense>().Property(p => p.ExpenseDate).IsRequired();
            modelBuilder.Entity<Expense>().Property(p => p.ExpenseSum).HasColumnName("Expense_sum");
            modelBuilder.Entity<Expense>().Property(p => p.ExpenseSum).IsRequired();
            modelBuilder.Entity<User>().HasKey(k => k.UserId);
            modelBuilder.Entity<User>().Property(p => p.UserId).HasColumnName("User_id");
            modelBuilder.Entity<User>().Property(p => p.UserId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            modelBuilder.Entity<User>().Property(p => p.UserName).HasColumnName("User_name");
            modelBuilder.Entity<User>().Property(p => p.UserName).HasColumnType("varchar");
            modelBuilder.Entity<User>().Property(p => p.UserName).HasMaxLength(50);
            modelBuilder.Entity<User>().Property(p => p.UserName).IsRequired();
            modelBuilder.Entity<User>().Property(p => p.UserPassword).HasColumnName("User_password");
            modelBuilder.Entity<User>().Property(p => p.UserPassword).HasColumnType("varchar");
            modelBuilder.Entity<User>().Property(p => p.UserPassword).HasMaxLength(15);
            modelBuilder.Entity<User>().Property(p => p.UserPassword).IsRequired();
            modelBuilder.Entity<User>().Property(p => p.AdminRights).HasColumnName("Admin_rights");
        }
    }
}