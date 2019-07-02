using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ProductsListControl.Models
{
    public class ProductsListContext : IdentityDbContext<ProductsListUser>
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Setting> Settings { get; set; }

        public ProductsListContext() : base("name = ProductsListContext") { }

        public static ProductsListContext Create()
        {
            return new ProductsListContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>().HasKey(p => p.ProductId);
            modelBuilder.Entity<Product>().Property(p => p.ProductId).HasColumnName("Product_id");
            modelBuilder.Entity<Product>().Property(p => p.ProductId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            modelBuilder.Entity<Product>().Property(p => p.ProductName).HasColumnName("Product_name");
            modelBuilder.Entity<Product>().Property(p => p.ProductName).HasColumnType("varchar");
            modelBuilder.Entity<Product>().Property(p => p.ProductName).HasMaxLength(150);
            modelBuilder.Entity<Product>().Property(p => p.ProductName).IsRequired();
            modelBuilder.Entity<Product>().Property(p => p.ManufactureDate).HasColumnName("Manufacture_date");
            modelBuilder.Entity<Product>().Property(p => p.ManufactureDate).HasColumnType("date");
            modelBuilder.Entity<Product>().Property(p => p.ManufactureDate).IsRequired();
            modelBuilder.Entity<Product>().Property(p => p.Description).HasColumnType("text");
            modelBuilder.Entity<Product>().Property(p => p.WarehouseAvailability).HasColumnName("Warehouse_availability");
            modelBuilder.Entity<Product>().Property(p => p.Photo).HasColumnType("varchar(MAX)");
            modelBuilder.Entity<Setting>().HasKey(s => s.SettingId);
            modelBuilder.Entity<Setting>().Property(s => s.SettingId).HasColumnName("Setting_id");
            modelBuilder.Entity<Setting>().Property(s => s.HasDescription).HasColumnName("Has_description");
            modelBuilder.Entity<Setting>().Property(s => s.HasDescription).IsRequired();
            modelBuilder.Entity<Setting>().Property(s => s.HasWarranty).HasColumnName("Has_warranty");
            modelBuilder.Entity<Setting>().Property(s => s.HasWarranty).IsRequired();
            modelBuilder.Entity<Setting>().Property(s => s.HasDiscount).HasColumnName("Has_discount");
            modelBuilder.Entity<Setting>().Property(s => s.HasDiscount).IsRequired();
            modelBuilder.Entity<Setting>().Property(s => s.HasWarehouseAvailability).HasColumnName("Has_warehouse_availability");
            modelBuilder.Entity<Setting>().Property(s => s.HasWarehouseAvailability).IsRequired();
            modelBuilder.Entity<Setting>().Property(s => s.HasPhoto).HasColumnName("Has_photo");
            modelBuilder.Entity<Setting>().Property(s => s.HasPhoto).IsRequired();
        }
    }
}