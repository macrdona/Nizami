using System.Collections.Generic;

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
    }
}
