using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/*
 * Passes information to the view about the number of pages
 * available, the current page, and the total number of products in the repository
 * 
 */

namespace Nizami.Models.ViewModels
{
	public class PagingInfo
	{
        public int TotalItems { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }

        public int TotalPages => (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage);

    }
}

