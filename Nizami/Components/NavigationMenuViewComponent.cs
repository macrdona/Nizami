using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nizami.Models;

/*
 * This class is responsible for managing the logic to support the product navigation(filter) bar
 */
namespace Nizami.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private IProductRepository repository;
        public NavigationMenuViewComponent(IProductRepository repo)
        {
            repository = repo;
        }

        //This method returns a list of all distinct categories in the database.
        public IViewComponentResult Invoke()
        {
            /*
             * ViewBag is a dynamic object to which you can define new properties by merely assigning values to them,
                making those values available in whatever view is subsequently rendered.
             */
            ViewBag.SelectedCategory = RouteData?.Values["category"];
            return View(repository.Products
            .Select(x => x.Category)
            .Distinct()
            .OrderBy(x => x));
        }
    }
}
