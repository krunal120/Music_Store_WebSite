using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Music_Store_WebSite.Models;

namespace Music_Store_WebSite.Controllers
{
    [Authorize]
    public class CheckoutController : Controller
    {
        MvcDBMusicEntities1 storeDB = new MvcDBMusicEntities1();
        const string PromoCode = "FREE";

        // GET: CheckOut
        public ActionResult AddressAndPayment(FormCollection values)
        {
            var order = new Order();
            TryUpdateModel(order);

            try
            {
                if(string.Equals(values["PromoCode"], PromoCode,StringComparison.OrdinalIgnoreCase) == false)
                {
                    return View(order);
                }
                else
                {
                    order.Username = User.Identity.Name;
                    order.OrderDate = DateTime.Now;

                    storeDB.Orders.Add(order);
                    storeDB.SaveChanges();

                    var cart = ShoppingCart.GetCart(this.HttpContext);
                    cart.CreateOrder(order);

                    return RedirectToAction("Complete", new { id = order.OrderId });

                }
            }
            catch
            {
                return View(order);
            }
        }
        public ActionResult Complete(int id)
        {
            bool isValid = storeDB.Orders.Any(
                o => o.OrderId == id &&
                o.Username == User.Identity.Name);
            if (isValid)
            {
                return View(id);
            }
            else
            {
                return View("Error");
            }
        }
    }
}