using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.UI.Modelss
{
    public class CartItem
    {
        public CartItem()
        {
            Quantity = 1;
        }
        public int Id { get; set; }
        public string MovieName { get; set; }
        public int Quantity { get; set; }
        public decimal? Price { get; set; }
        public string MovieDate { get; set; }
        public string MovieTime { get; set; }
        public decimal? SubTotal
        {
            get
            {
                return Price * Quantity;
            }
        }
    }
}