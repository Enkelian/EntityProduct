using System;
using System.Linq;
using Microsoft.EntityFrameworkCore.Design;

namespace ANosekProductEF
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("write name of product");
            string prodName = Console.ReadLine();
            Product prod1 = new Product { Name = prodName };

            //Console.WriteLine("Write name of supplier");
            //String suppName = Console.ReadLine();
            //Supplier supp1 = new Supplier { CompanyName = suppName };


            ProdContext prodContext = new ProdContext();

            //prodContext.Products.Add(prod1);
            //prodContext.SaveChanges();

            //prodContext.Suppliers.Add(supp1);
            //prodContext.SaveChanges();

            //Product product = prodContext.Products.Where(p => p.Name == prodName).FirstOrDefault();

            //Supplier supplier = prodContext.Suppliers.Where(s => s.CompanyName == suppName).FirstOrDefault();


            //product.Supplier = supplier;
            //prodContext.SaveChanges();

            //prodContext.Entry(supplier).Collection(supp => supp.Products).Load();
            //supplier.Products.Add(product);
            //prodContext.SaveChanges();

            //IQueryable<string> query = prodContext.Products.Select(p => p.Name);

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

    }
}
