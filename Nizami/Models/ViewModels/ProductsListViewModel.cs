using System.Collections.Generic;
using Nizami.Models;

/*
 * sends the data of pages with products to the controller
 */

namespace Nizami.Models.ViewModels
{
	public class ProductsListViewModel
	{
       //list of products
       public IEnumerable<Product> Products { get; set; }
       //settings for how many products will be displayed per page
       public PagingInfo PagingInfo { get; set; }
       //display products based on selected category
       public string CurrentCategory { get; set; }

       public int SortPrice { get; set; }
       
    }
}
