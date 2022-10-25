using Microsoft.AspNetCore.Mvc;
using Nizami.Models;
using System.Linq;

namespace Nizami.Controllers
{
    public class OrderController : Controller
    {
        private IOrderRepository repository; private Cart cart; 
        public OrderController(IOrderRepository repoService, Cart cartService) 
        { 
            repository = repoService; cart = cartService;
        }
        public ViewResult Checkout() => View(new Orders());

        [HttpPost] 
        public IActionResult Checkout(Orders order) 
        { 
            if (cart.Lines.Count() == 0)
             { 
                    ModelState.AddModelError("", "Sorry, your cart is empty!"); 
             } 
         
            if (ModelState.IsValid) 
            {
                order.Lines = cart.Lines.ToArray(); 
                repository.SaveOrder(order); 
                return RedirectToAction(nameof(Completed)); 
            } 

            else 
            { 
                return View(order); 
            } 
        }
        public ViewResult Completed() 
        { 
            cart.Clear(); return View(); 
        }
    }
}
