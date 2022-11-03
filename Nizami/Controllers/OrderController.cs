using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Nizami.Infrastructure;
using Nizami.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Nizami.Controllers
{
    public class OrderController : Controller
    {
        private IOrderRepository repository; 
        private Cart cart;
        private UserManager<AppUser> userManager;
        public OrderController(IOrderRepository repoService, Cart cartService, UserManager<AppUser> userMgr) 
        { 
            repository = repoService; cart = cartService;
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

        [Authorize]
        public async Task<IActionResult> List()
        {
            if (await AuthenticatAdmin())
            {
                return View(repository.Orders.Where(o => !o.Shipped));
            }
            return Redirect(HttpContext.Request.HomePage());
        }

        [HttpPost]
        [Authorize]
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
