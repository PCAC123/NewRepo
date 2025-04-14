using BlazorAPI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlazorAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> UsersDb { get; set; }
        public DbSet<CarStyle> CarStylesDb { get; set; }
        public DbSet<CarModel> CarModelsDb { get; set; }
        public DbSet<Car> CarsDb { get; set; }
        public DbSet<ViewHistory> ViewHistoriesDb { get; set; }
        public DbSet<Promotion> PromotionsDb { get; set; }
        public DbSet<Payment> PaymentsDb { get; set; }
        public DbSet<Order> OrdersDb { get; set; }
        public DbSet<OrderDetail> OrderDetailsDb { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Unique constraints
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<CarStyle>()
                .HasIndex(c => c.StyleName)
                .IsUnique();

            modelBuilder.Entity<CarModel>()
                .HasIndex(c => c.ModelName)
                .IsUnique();

            // Relationships

            // CarStyle - CarModel (1-n)
            modelBuilder.Entity<CarModel>()
                .HasOne(cm => cm.CarStyle)
                .WithMany(cs => cs.CarModels)
                .HasForeignKey(cm => cm.StyleId)
                .OnDelete(DeleteBehavior.Cascade);

            // CarModel - Car (1-n)
            modelBuilder.Entity<Car>()
                .HasOne(c => c.CarModel)
                .WithMany(cm => cm.Cars)
                .HasForeignKey(c => c.ModelId)
                .OnDelete(DeleteBehavior.Cascade);

            // User - Order (1-n)
            modelBuilder.Entity<Order>()
                .HasOne(o => o.User)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // User - ViewHistory (1-n)
            modelBuilder.Entity<ViewHistory>()
                .HasOne(vh => vh.User)
                .WithMany(u => u.ViewHistories)
                .HasForeignKey(vh => vh.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Car - ViewHistory (1-n)
            modelBuilder.Entity<ViewHistory>()
                .HasOne(vh => vh.Car)
                .WithMany()
                .HasForeignKey(vh => vh.CarId)
                .OnDelete(DeleteBehavior.Cascade);

            // Order - OrderDetail (1-n)
            modelBuilder.Entity<OrderDetail>()
                .HasOne(od => od.Order)
                .WithMany(o => o.OrderDetails)
                .HasForeignKey(od => od.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            // Car - OrderDetail (1-n)
            modelBuilder.Entity<OrderDetail>()
                .HasOne(od => od.Car)
                .WithMany()
                .HasForeignKey(od => od.CarId)
                .OnDelete(DeleteBehavior.Cascade);

            // Order - Payment (1-1 optional)
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Payment)
                .WithMany()
                .HasForeignKey(o => o.PaymentId)
                .OnDelete(DeleteBehavior.SetNull);

            // Order - Promotion (1-1 optional)
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Promotion)
                .WithMany()
                .HasForeignKey(o => o.PromotionId)
                .OnDelete(DeleteBehavior.SetNull);

            base.OnModelCreating(modelBuilder);
        }

    }
}
