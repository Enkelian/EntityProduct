using System;
using System.Linq;
using Microsoft.EntityFrameworkCore.Design;

namespace ANosekProductEF
{
    
    class Program
    {
        public static void AddProduct(ProdContext prodContext)
        {
            Console.WriteLine("write name of product");
            string prodName = Console.ReadLine();
            Product prod1 = new Product { Name = prodName };

            prodContext.Products.Add(prod1);
            prodContext.SaveChanges();
        }

        public static void AddSupplier(ProdContext prodContext)
        {
            Console.WriteLine("Write name of supplier");
            String suppName = Console.ReadLine();
            Supplier supp1 = new Supplier { CompanyName = suppName };

            prodContext.Suppliers.Add(supp1);
            prodContext.SaveChanges();
        }

        public static void AddCategory(ProdContext prodContext)
        {
            Console.WriteLine("write name of category");
            string catName = Console.ReadLine();
            Category cat1 = new Category { Name = catName };

            prodContext.Categories.Add(cat1);
            prodContext.SaveChanges();
        }

        public static void AddInvoice(ProdContext prodContext)
        {
            Invoice inv = new Invoice { };
            prodContext.Invoices.Add(inv);
            prodContext.SaveChanges();
        }


        public static void ConnectProductToSupplier(ProdContext prodContext)
        {
            Console.WriteLine("Write name of product");
            string prodName = Console.ReadLine();

            Console.WriteLine("Write name of supplier");
            String suppName = Console.ReadLine();

            Product product = prodContext.Products.Where(p => p.Name == prodName).FirstOrDefault();

            Supplier supplier = prodContext.Suppliers.Where(s => s.CompanyName == suppName).FirstOrDefault();

            product.Supplier = supplier;
            prodContext.SaveChanges();
        }

        public static void ConnectProductToCategory(ProdContext prodContext)
        {
            Console.WriteLine("Write name of product");
            string prodName = Console.ReadLine();

            Console.WriteLine("Write name of category");
            String conName = Console.ReadLine();

            Product product = prodContext.Products.Where(p => p.Name == prodName).FirstOrDefault();

            Category category = prodContext.Categories.Where(c => c.Name == conName).FirstOrDefault();

            product.Category = category;
            prodContext.SaveChanges();
        }

        public static void ConnectProductToInvoice(ProdContext prodContext)
        {
            Console.WriteLine("Write name of product");
            String prodName = Console.ReadLine();

            Console.WriteLine("Write number of invoice");
            String invNumStr = Console.ReadLine();
            int invNum = Int32.Parse(invNumStr);

            Product product = prodContext.Products.Where(p => p.Name == prodName).FirstOrDefault();

            Invoice invoice = prodContext.Invoices.Where(i => i.InvoiceNumber == invNum).FirstOrDefault();

            prodContext.ProductInvoices.Add(new ProductInvoice
            {
                ProductID = product.ProductID,
                Product = product,
                InvoiceNumber = invoice.InvoiceNumber,
                Invoice = invoice
            });
            prodContext.SaveChanges();
        }

    public static void ShowProductsWithSuppliers(ProdContext prodContext)
        {

            Console.WriteLine("List of products with suppliers:");

            foreach (Product item in prodContext.Products)
            {
                prodContext.Entry(item).Reference(prod => prod.Supplier).Load();

                if (item.Supplier != null)
                {

                    Console.WriteLine(item.Name + " " + item.Supplier.CompanyName);
                }
                else
                {
                    Console.WriteLine(item.Name);
                }
            }
        }


        public static void ShowSuppliersWithProducts(ProdContext prodContext)
        {
            Console.WriteLine("List of suppliers with products:");

            foreach (Supplier supp in prodContext.Suppliers)
            {
                prodContext.Entry(supp).Collection(supp => supp.Products).Load();

                Console.WriteLine(supp.CompanyName);

                foreach (Product prod in supp.Products)
                {
                    Console.WriteLine(prod.Name);
                }

            }
        }


        public static void ShowProductsWithCategories(ProdContext prodContext)
        {

            Console.WriteLine("List of products with categories:");

            foreach (Product item in prodContext.Products)
            {
                prodContext.Entry(item).Reference(prod => prod.Category).Load();

                if (item.Category != null)
                {
                    Console.WriteLine(item.Name + " " + item.Category.Name);
                }
                else
                {
                    Console.WriteLine(item.Name);
                }
            }
        }

        public static void ShowCategoriesWithProducts(ProdContext prodContext)
        {
            Console.WriteLine("List of categories with products:");

            foreach (Category cat in prodContext.Categories)
            {
                prodContext.Entry(cat).Collection(cat => cat.Products).Load();

                Console.WriteLine(cat.Name);

                foreach (Product prod in cat.Products)
                {
                    Console.WriteLine(prod.Name);
                }

            }
        }

        public static void ShowProductInvoices(ProdContext prodContext)
        {
            Console.WriteLine("ProductInvoices:");

            foreach (ProductInvoice item in prodContext.ProductInvoices)
            {
                prodContext.Entry(item).Reference(item => item.Product).Load();
                prodContext.Entry(item).Reference(item => item.Invoice).Load();


                if (item.Product != null)
                {
                    Console.Write("Product:");
                    Console.WriteLine(item.Product.Name);
                }
                if (item.Invoice != null)
                {
                    Console.Write("Invoice:");
                    Console.WriteLine(item.Invoice.InvoiceNumber);
                }
                Console.WriteLine();
            }
        }

        public static void ShowInvoicesOfProduct(ProdContext prodContext)
        {
            Console.WriteLine("Write name of product");
            String prodName = Console.ReadLine();

            Product product = prodContext.Products.Where(p => p.Name == prodName).FirstOrDefault();
            prodContext.Entry(product).Collection(prod => prod.ProductInvoices).Load();

            Console.WriteLine("List of invoices for given product:");

            foreach (ProductInvoice prodInv in product.ProductInvoices)
            {
                prodContext.Entry(prodInv).Reference(prodInv => prodInv.Invoice).Load();
                Console.WriteLine(prodInv.InvoiceNumber);
            }
        }

        public static void ShowProductsOfInvoice(ProdContext prodContext)
        {
            Console.WriteLine("Write number of invoice");
            String invNumStr = Console.ReadLine();
            int invnum = Int32.Parse(invNumStr);

            Invoice invoice = prodContext.Invoices.Where(i => i.InvoiceNumber == invnum).FirstOrDefault();
            prodContext.Entry(invoice).Collection(inv => inv.ProductInvoices).Load();

            Console.WriteLine("List of products for given invoice:");

            foreach (ProductInvoice prodInv in invoice.ProductInvoices)
            {
                prodContext.Entry(prodInv).Reference(prodInv => prodInv.Invoice).Load();
                Console.WriteLine(prodInv.Product.Name);
            }
        }

        static void Main(string[] args)
        {
            ProdContext prodContext = new ProdContext();


            //prodContext.Entry(supplier).Collection(supp => supp.Products).Load();
            //supplier.Products.Add(product);
            //prodContext.SaveChanges();

            //AddProduct(prodContext);
            //AddSupplier(prodContext); 
            //AddCategory(prodContext);
            //AddInvoice(prodContext);

            //ConnectProductToSupplier(prodContext);
            //ConnectProductToCategory(prodContext);
            //ConnectProductToInvoice(prodContext);

            //ShowProductsWithSuppliers(prodContext);
            //ShowSuppliersWithProducts(prodContext);
            //ShowProductsWithCategories(prodContext);
            //ShowCategoriesWithProducts(prodContext);
            //ShowProductInvoices(prodContext);
            ShowProductInvoices(prodContext);
            ShowInvoicesOfProduct(prodContext);
            ShowProductsOfInvoice(prodContext);

        }

    }
}
