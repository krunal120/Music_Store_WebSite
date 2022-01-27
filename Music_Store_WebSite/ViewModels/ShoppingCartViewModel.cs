using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Music_Store_WebSite.Models;

namespace Music_Store_WebSite.ViewModels
{
    public class ShoppingCartViewModel
    {
        public List<Cart> CartItems { get; set; }
        public decimal CartTotal { get; set; }
    }
}