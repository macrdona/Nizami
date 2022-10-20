using Microsoft.AspNetCore.Mvc;
using Nizami.Models;

// Gets cart objects to be used to make the cart summary on the main page navbar
namespace Nizami.Components
{
    public class CartSummaryViewComponent : ViewComponent
    {
        private Cart cart;
        public CartSummaryViewComponent(Cart cartService)
        {
            cart = cartService;
        }
        public IViewComponentResult Invoke()
        {
            return View(cart);
        }
    }
}
