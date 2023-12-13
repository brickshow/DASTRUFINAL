using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DASTRU_PROJECT
{
    internal class Cart
    {
        private string ItemsInCArt { get; set; }
        private double priceInCart { get; set; }

        public Cart(string item, double price)
        {
            this.ItemsInCArt = item;
            this.priceInCart = price;
        }

        public string DisplayCart()
        {
            Console.Clear();
            Console.WriteLine("Item In Cart");
            return this.ItemsInCArt;
        }

    }
}
