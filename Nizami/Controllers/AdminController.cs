using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Nizami.Infrastructure;
using Nizami.Models;
using System;
using System.Linq;
using System.Security.Claims;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Nizami.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private IProductRepository repository;
        private UserManager<AppUser> userManager;
        public AdminController(IProductRepository repo, UserManager<AppUser> userMgr)
        {
            repository = repo;
            userManager = userMgr;
        }

        private async Task<bool> AuthenticatAdmin()
        {
            AppUser appUser = await userManager.GetUserAsync(HttpContext.User);
            if (appUser.UserId == 1)
            {
                return true;
            }
            return false;
        }

        //returns a view with all available products in the database
        public async Task<IActionResult> ProductList()
        {
            
            if(await AuthenticatAdmin())
            {
                return View(repository.Products);
            }
            return Redirect(HttpContext.Request.HomePage());
        }


        //edit products
        public async Task<IActionResult> Edit(int productId)
        {
            if (await AuthenticatAdmin())
            {
                return View(repository.Products.FirstOrDefault(p => p.ProductID == productId));

            }
            return Redirect(HttpContext.Request.HomePage());
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                repository.SaveProduct(product);
                TempData["message"] = $"{product.Name} has been saved";
                return RedirectToAction("ProductList");
            }
            else
            {
                return View(product);
            }
        }

        public async Task<IActionResult> Create()
        {
            if (await AuthenticatAdmin())
            {
                return View("Edit", new Product()); 

            }
            return Redirect(HttpContext.Request.HomePage());
        }

        [HttpPost]
        public IActionResult Delete(int productId)
        {
            Product deletedProduct = repository.DeleteProduct(productId);
            if (deletedProduct != null)
            {
                TempData["message"] = $"{deletedProduct.Name} was deleted";
            }
            return RedirectToAction("ProductList");
        }


    }
}
