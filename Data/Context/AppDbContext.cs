using Microsoft.EntityFrameworkCore;

namespace YourNamespace.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<StockMovement> StockMovements { get; set; }
        public DbSet<Payment> Payments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasKey(p => p.ProductId);
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId);

            modelBuilder.Entity<Category>()
                .HasKey(c => c.CategoryId);

            modelBuilder.Entity<Customer>()
                .HasKey(c => c.CustomerId);

            modelBuilder.Entity<Supplier>()
                .HasKey(s => s.SupplierId);

            modelBuilder.Entity<Invoice>()
                .HasKey(i => i.InvoiceId);
            modelBuilder.Entity<Invoice>()
                .HasOne(i => i.Customer)
                .WithMany(c => c.Invoices)
                .HasForeignKey(i => i.CustomerId);

            modelBuilder.Entity<Order>()
                .HasKey(o => o.OrderId);
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Customer)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.CustomerId);

            modelBuilder.Entity<StockMovement>()
                .HasKey(sm => sm.StockMovementId);

            modelBuilder.Entity<Payment>()
                .HasKey(p => p.PaymentId);
            modelBuilder.Entity<Payment>()
                .HasOne(p => p.Invoice)
                .WithMany(i => i.Payments)
                .HasForeignKey(p => p.InvoiceId);
        }
    }
}