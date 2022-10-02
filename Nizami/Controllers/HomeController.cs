using Microsoft.AspNetCore.Mvc;
using Nizami.Models;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using Microsoft.Extensions.Options;

namespace Nizami.Controllers
{
    /*This class that will handle HTTP requests*/
    public class HomeController : Controller
    {
        private IProductRepository repository;
        public HomeController(IProductRepository repo)
        {
            repository = repo;
        }

        //GET Index()
        /*Index is an action method that will be called when Index.cshtml is invoked.
        When invoked, it will return a list of prducts available in the repository*/
        public ViewResult Index() => View(repository.Products);
        

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