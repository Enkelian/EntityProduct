using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using Microsoft.EntityFrameworkCore.Design;

namespace ANosekProductEF
{   
    class ProdContext: DbContext
    {
       public DbSet<Product> Products { set; get; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Invoice> Invoices { get; set; }

        public DbSet<ProductInvoice> ProductInvoices { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite("DataSource=Product.db");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductInvoice>()
                .HasKey(pi => new { pi.ProductID, pi.InvoiceNumber });
            modelBuilder.Entity<ProductInvoice>()
                .HasOne(pi => pi.Product)
                .WithMany(pi => pi.ProductInvoices)
                .HasForeignKey(pi => pi.ProductID);
            modelBuilder.Entity<ProductInvoice>()
                .HasOne(pi => pi.Invoice)
                .WithMany(pi => pi.ProductInvoices)
                .HasForeignKey(pi => pi.InvoiceNumber);

            modelBuilder.Entity<Customer>();
            modelBuilder.Entity<Supplier>();
        }
    }
}