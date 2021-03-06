﻿// <auto-generated />
using System;
using ANosekProductEF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ANosekProductEF.Migrations
{
    [DbContext(typeof(ProdContext))]
    partial class ProdContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3");

            modelBuilder.Entity("ANosekProductEF.Category", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("CategoryID");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("ANosekProductEF.Company", b =>
                {
                    b.Property<int>("CompanyID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("City")
                        .HasColumnType("TEXT");

                    b.Property<string>("CompanyName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Street")
                        .HasColumnType("TEXT");

                    b.Property<string>("ZipCode")
                        .HasColumnType("TEXT");

                    b.HasKey("CompanyID");

                    b.ToTable("Companies");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Company");
                });

            modelBuilder.Entity("ANosekProductEF.Invoice", b =>
                {
                    b.Property<int>("InvoiceNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.HasKey("InvoiceNumber");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("ANosekProductEF.Product", b =>
                {
                    b.Property<int>("ProductID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CategoryID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int?>("SupplierCompanyID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UnitsInStock")
                        .HasColumnType("INTEGER");

                    b.HasKey("ProductID");

                    b.HasIndex("CategoryID");

                    b.HasIndex("SupplierCompanyID");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("ANosekProductEF.ProductInvoice", b =>
                {
                    b.Property<int>("ProductID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("InvoiceNumber")
                        .HasColumnType("INTEGER");

                    b.HasKey("ProductID", "InvoiceNumber");

                    b.HasIndex("InvoiceNumber");

                    b.ToTable("ProductInvoices");
                });

            modelBuilder.Entity("ANosekProductEF.Customer", b =>
                {
                    b.HasBaseType("ANosekProductEF.Company");

                    b.Property<float>("Discount")
                        .HasColumnType("REAL");

                    b.HasDiscriminator().HasValue("Customer");
                });

            modelBuilder.Entity("ANosekProductEF.Supplier", b =>
                {
                    b.HasBaseType("ANosekProductEF.Company");

                    b.Property<string>("BankAccountNumber")
                        .HasColumnType("TEXT");

                    b.HasDiscriminator().HasValue("Supplier");
                });

            modelBuilder.Entity("ANosekProductEF.Product", b =>
                {
                    b.HasOne("ANosekProductEF.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryID");

                    b.HasOne("ANosekProductEF.Supplier", "Supplier")
                        .WithMany("Products")
                        .HasForeignKey("SupplierCompanyID");
                });

            modelBuilder.Entity("ANosekProductEF.ProductInvoice", b =>
                {
                    b.HasOne("ANosekProductEF.Invoice", "Invoice")
                        .WithMany("ProductInvoices")
                        .HasForeignKey("InvoiceNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ANosekProductEF.Product", "Product")
                        .WithMany("ProductInvoices")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
