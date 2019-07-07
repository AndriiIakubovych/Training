using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace CarShowroom
{
    class ShowroomContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Car>().HasKey(c => c.CarId);
            modelBuilder.Entity<Car>().Property(c => c.CarId).HasColumnName("Car_id");
            modelBuilder.Entity<Car>().Property(c => c.CarId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            modelBuilder.Entity<Car>().Property(c => c.CarName).HasColumnName("Car_name");
            modelBuilder.Entity<Car>().Property(c => c.CarName).IsRequired();
            modelBuilder.Entity<Car>().Property(c => c.CarPhoto).HasColumnName("Car_photo");
            modelBuilder.Entity<Car>().Property(c => c.CarPhoto).IsRequired();
            modelBuilder.Entity<Car>().Property(c => c.EngineType).HasColumnName("Engine_type");
            modelBuilder.Entity<Car>().Property(c => c.EngineType).IsRequired();
            modelBuilder.Entity<Car>().Property(c => c.EngineVolume).HasColumnName("Engine_volume");
            modelBuilder.Entity<Car>().Property(c => c.EngineVolume).IsRequired();
            modelBuilder.Entity<Car>().Property(c => c.Power).IsRequired();
            modelBuilder.Entity<Car>().Property(c => c.MaxSpeed).HasColumnName("Max_speed");
            modelBuilder.Entity<Car>().Property(c => c.MaxSpeed).IsRequired();
            modelBuilder.Entity<Car>().Property(c => c.FuelTankCapacity).HasColumnName("Fuel_tank_capacity");
            modelBuilder.Entity<Car>().Property(c => c.FuelTankCapacity).IsRequired();
            modelBuilder.Entity<Car>().Property(c => c.Transmission).IsRequired();
            modelBuilder.Entity<Car>().Property(c => c.Drive).IsRequired();
            modelBuilder.Entity<Car>().Property(c => c.Weight).IsRequired();
            modelBuilder.Entity<Car>().Property(c => c.Price).IsRequired();
        }
    }
}