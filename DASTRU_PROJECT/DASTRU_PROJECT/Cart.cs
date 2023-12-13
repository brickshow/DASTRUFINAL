using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alcuino.ConsoleWriter472;

namespace DASTRU_PROJECT
{
    internal class Cart
    {
        private string ItemsInCArt { get; set; }

        public void DisplayCart(string item)
        {
            ItemsInCArt = item;
            Console.Clear();
            ConsoleWriter.WriteLine("Item In Cart\n");
            Console.WriteLine("==========================================");
            Console.WriteLine(ItemsInCArt);
            Console.WriteLine("==========================================");
        }
    }
}
