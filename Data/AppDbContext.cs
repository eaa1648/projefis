using Microsoft.EntityFrameworkCore;
using projefis.Models;

namespace projefis.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceDetail> InvoiceDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // İlişkileri ve özel yapılandırmaları burada tanımlayabilirsiniz
            modelBuilder.Entity<Invoice>()
                .HasOne(i => i.Customer)
                .WithMany()
                .HasForeignKey(i => i.CustomerId);

            modelBuilder.Entity<InvoiceDetail>()
                .HasOne(d => d.Invoice)
                .WithMany(i => i.InvoiceDetails)
                .HasForeignKey(d => d.InvoiceId);

            modelBuilder.Entity<InvoiceDetail>()
                .HasOne(d => d.Stock)
                .WithMany(s => s.InvoiceDetails)
                .HasForeignKey(d => d.StockId);
        }
    }
}
