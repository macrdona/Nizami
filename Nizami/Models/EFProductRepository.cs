using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace Nizami.Models
{
    /*This class provides access to the Entity Framework Core’s underlying functionality, and
    the Products property will provide access to the Product objects in the database.*/
    public class EFProductRepository : IProductRepository
	{
        private NizamiDbContext context;
        public EFProductRepository(NizamiDbContext ctx)
        {
            context = ctx;
        }
        public IEnumerable<Product> Products => context.Products;

        public void SaveProduct(Product product)
        {
            Product dbEntry = context.Products.FirstOrDefault(p => p.ProductID == product.ProductID);

            if (dbEntry != null)
            {
                dbEntry.Name = product.Name;
                dbEntry.Description = product.Description;
                dbEntry.Price = product.Price;
                dbEntry.Category = product.Category;
            }
            else
            {
                Random random = new Random();
                product.ProductID = random.Next(1000, 9999);

                while(context.Products.FirstOrDefault(p => p.ProductID == product.ProductID) != null)
                {
                    product.ProductID = random.Next(1000, 9999);
                }
                context.Products.Add(product);
            }
          
            context.SaveChanges();
        }

        public Product DeleteProduct(int productID)
        {
            Product dbEntry = context.Products.FirstOrDefault(p => p.ProductID == productID);
            if (dbEntry != null)
            {
                context.Products.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

    }
}
