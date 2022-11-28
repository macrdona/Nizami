using Microsoft.AspNetCore.Mvc;
using Nizami.Models;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using Microsoft.Extensions.Options;
using System.Linq;
using Nizami.Models.ViewModels;
using System.ComponentModel;
using Microsoft.AspNetCore.Authorization;

namespace Nizami.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private IProductRepository repository;
        public int PageSize = 20; 
        public HomeController(IProductRepository repo)
        {
            repository = repo;
        }

        [AllowAnonymous]
        public ViewResult Index(string category, int sort=0, int page = 1)
            => View(new ProductsListViewModel
            {
                Products = repository.Products
                                .Where(p => category == null || p.Category == category)
                                .OrderBy(p => (sort == 1) ? p.Price : p.ProductID)
                                .Skip((page - 1) * PageSize)
                                .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null ?
                         repository.Products.Count() :
                         repository.Products.Where(e =>
                         e.Category == category).Count()
                },
                CurrentCategory = category,
                SortPrice = sort
            });

        public ViewResult PostLogin(string category, int sort = 0, int page = 1)
                 => View(new ProductsListViewModel
                 {
                     Products = repository.Products
                                .Where(p => category == null || p.Category == category)
                                .OrderBy(p => (sort == 1) ? p.Price : p.ProductID)
                                .Skip((page - 1) * PageSize)
                                .Take(PageSize),
                     PagingInfo = new PagingInfo
                     {
                         CurrentPage = page,
                         ItemsPerPage = PageSize,
                         TotalItems = category == null ?
                         repository.Products.Count() :
                         repository.Products.Where(e =>
                         e.Category == category).Count()
                     },
                     CurrentCategory = category,
                     SortPrice = sort
                 });

        public IActionResult Privacy()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult FAQ()
        {
            return View();
        }


        [AllowAnonymous]
        public ActionResult AboutMe()
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