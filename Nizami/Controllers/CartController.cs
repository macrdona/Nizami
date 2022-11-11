using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nizami.Infrastructure;
using Nizami.Models;
using Nizami.Models.ViewModels;

namespace Nizami.Controllers
{

    //This class controls the actions on the shopping cart
    [Authorize]
    public class CartController : Controller
    {
        private IProductRepository repository;

        private Cart cart;

        public CartController(IProductRepository repo, Cart cartService)
        {
            repository = repo;
            this.cart = cartService;
        }

        //creates an instance of a cart
        public ViewResult Cart(string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = cart,
                ReturnUrl = returnUrl
            });
        }

        public RedirectResult UpdateQuantity(int productId, string returnUrl)
        {
            Product product = repository.Products
            .FirstOrDefault(p => p.ProductID == productId);
            if (product != null)
            {

                cart.AddItem(product, -1);

            }
            return Redirect(returnUrl);
        }

        //this method adds item to cart
        public RedirectResult AddToCart(int productId, string returnUrl)
        {
            Product product = repository.Products
            .FirstOrDefault(p => p.ProductID == productId);
            if (product != null)
            {
                
                cart.AddItem(product, 1);
               
            }
             return Redirect(returnUrl);
        }

        //this method returns item to cart
        public RedirectToActionResult RemoveFromCart(int productId, string returnUrl)
        {
            Product product = repository.Products
            .FirstOrDefault(p => p.ProductID == productId);
            if (product != null)
            {
                
                cart.RemoveLine(product);
                
            }
            return RedirectToAction("Cart", new { returnUrl });
        }

    }
}

