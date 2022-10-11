using System.Collections.Generic;
using Nizami.Models;

/*
 * sends the data of pages with products to the controller
 */

namespace Nizami.Models.ViewModels
{
	public class ProductsListViewModel
	{
       
            public IEnumerable<Product> Products { get; set; }
            public PagingInfo PagingInfo { get; set; }
        

    }
}
