using System.Collections.Generic;

namespace Nizami.Models
{
    /*This interface will allow us to store and retrive data from the Product data model.*/
    public interface IProductRepository
    {
        //IEnumerable is a generic interface which allows looping over generic or non-generic lists
        IEnumerable<Product> Products { get; }

        void SaveProduct(Product product);

        Product DeleteProduct(int productID);
    }
}
