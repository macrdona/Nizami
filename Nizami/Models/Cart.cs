using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nizami.Models
{
    /*
     * This class adds the logic for creating and keeping track of items in a shopping cart
     */
    public class Cart
    {
        //this is a list of items curretly in the cart
        private List<CartLine> lineCollection = new List<CartLine>();

        //this method will add items to the list
        public virtual void AddItem(Product product, int quantity)
        {
            CartLine line = lineCollection
            .Where(p => p.Product.ProductID == product.ProductID)
            .FirstOrDefault();

            //if list is empty, create a new list and add items
            if (line == null)
            {
                lineCollection.Add(new CartLine
                {
                    Product = product,
                    Quantity = quantity
                });
            }
            //else add item to existing list
            else
            {
                line.Quantity += quantity;
            }
        }

        //this method will remove item from the list
        public virtual void RemoveLine(Product product) =>
        lineCollection.RemoveAll(l => l.Product.ProductID == product.ProductID);
        
        //computer total to be displayed on check out
        public virtual decimal ComputeTotalValue() =>
        lineCollection.Sum(e => e.Product.Price * e.Quantity);

        //empty the cart
        public virtual void Clear() => lineCollection.Clear();

        //return a list of all available items in the cart
        public virtual IEnumerable<CartLine> Lines => lineCollection;
    }

    /*
     * CartLine class represents a product and the quantity of the product selected
     */
    public class CartLine
    {
        public int CartLineID { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
