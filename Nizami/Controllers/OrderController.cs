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

        public ViewResult List() => View(repository.Orders.Where(o => !o.Shipped));

        [HttpPost]
        public IActionResult MarkShipped(int orderID)
        {
            Orders order = repository.Orders.FirstOrDefault(o => o.OrderID == orderID);

            if (order != null)
            {
                order.Shipped = true;
                repository.UpdateOrder(order, orderID);

            }
            return RedirectToAction(nameof(List));
        }

        public ViewResult Checkout() => View(new Orders());

        //if products exists, returns a list of items in cart
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
                //sets default value of shipped to false
                order.Shipped = false;
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
