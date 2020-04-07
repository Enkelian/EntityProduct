using System;
using System.Linq;
using Microsoft.EntityFrameworkCore.Design;

namespace ANosekProductEF
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Write name of product");
            String prodName = Console.ReadLine();
            //Product prod = new Product { Name = prodName };

            Console.WriteLine("Write name of supplier");
            String suppName = Console.ReadLine();
            //Supplier supp = new Supplier { CompanyName = suppName };


            ProdContext prodContext = new ProdContext();

            //prodContext.Products.Add(prod);
            //prodContext.SaveChanges();

            //prodContext.Suppliers.Add(supp);
            //prodContext.SaveChanges();

            Product product = prodContext.Products.Where(p => p.Name == prodName).FirstOrDefault();

            Supplier supplier = prodContext.Suppliers.Where(s => s.CompanyName == suppName).FirstOrDefault();




            prodContext.Entry(product).Property("SupplierID").CurrentValue = supplier.SupplierID;

            prodContext.SaveChanges();

            IQueryable<string> query = prodContext.Products.Select(p => p.Name);
                
            foreach(var item in query)
            {
                Console.WriteLine(item);    
            }  

        }
    }
}
