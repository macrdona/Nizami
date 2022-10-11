using Microsoft.AspNetCore.Mvc;
using Nizami.Models;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using Microsoft.Extensions.Options;
using System.Linq;
using Nizami.Models.ViewModels;

namespace Nizami.Controllers
{
    /*This class that will handle HTTP requests*/
    public class HomeController : Controller
    {
        private IProductRepository repository;
        public int PageSize = 20; // to make the items 20 per page
        public HomeController(IProductRepository repo)
        {
            repository = repo;
        }

        //GET Index()
        /*Index is an action method that will be called when Index.cshtml is invoked.
        When invoked, it will return a list of prducts available in the repository*/

        /*
         * Changed Index to show only 20 items per page
         */
        public ViewResult Index(int page = 1)  // Beginning of Part 24 <Kenniece Harris>
                 => View(new ProductsListViewModel
                 {
                     Products = repository.Products
                                 .OrderBy(p => p.ProductID)
                                .Skip((page - 1) * PageSize)
                                 .Take(PageSize),
                     PagingInfo = new PagingInfo
                     {
                         CurrentPage = page,
                         ItemsPerPage = PageSize,
                         TotalItems = repository.Products.Count()
                     }
                 });




        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}