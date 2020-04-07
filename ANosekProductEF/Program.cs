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

        static void Main(string[] args)
        {
            ProdContext prodContext = new ProdContext();


            //prodContext.Entry(supplier).Collection(supp => supp.Products).Load();
            //supplier.Products.Add(product);
            //prodContext.SaveChanges();

            //AddProduct(prodContext);
            //AddSupplier(prodContext);
            //AddCategory(prodContext);

            //ConnectProductToSupplier(prodContext);
            //ConnectProductToCategory(prodContext);

            //ShowProductsWithSuppliers(prodContext);
            //ShowSuppliersWithProducts(prodContext);
            ShowProductsWithCategories(prodContext);
            ShowCategoriesWithProducts(prodContext);


        }

    }
}
