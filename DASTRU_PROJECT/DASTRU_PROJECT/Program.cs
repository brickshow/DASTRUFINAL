using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Threading;
using Alcuino.ConsoleWriter472;
using DASTRU_PROJECT;

namespace DASTRU_FINAL_PROJECT
{
    class Program
    {


        public static object Color { get; private set; }

        static string[] products =
         { "Don Darko", "Donya Berry", "Don Matchatos", "Caramel Macchiato", "Iced Mocha",
          "Iced Ube", "Iced Chocolate", "Cookie Dough Iced Latte", "Pumpkin Spice Latte", "Spanish Latte" };

        static double[] price = { 39.00, 39.00, 49.00, 59.00, 39.00, 39.00, 49.00, 59.00, 39.00, 39.00 };

        static LinkedList<string> orderedItems = new LinkedList<string>();
        static int selectedItem;
        static void Main(string[] args)
        {
           
        again:
            ConsoleWriter.WriteHeader("DON MACCHIATOS", ConsoleColor.Cyan, 100);
            double totalPrice = 0;
            string yn;

            string productSelected = ProductSelection();
            Console.Clear();
            double quantity = SelectQuantity();
            Console.Clear();

            totalPrice += quantity * price[selectedItem];
            string productDetail = productSelected + " " + quantity + " pcs: " + (quantity * price[selectedItem]) + " pesos";

            orderedItems.AddLast(productDetail);
            Console.WriteLine(productDetail);

            Console.WriteLine("Successfully added.\n[F1] Order again? \t [F2] Checkout? "); Console.CursorVisible = false;
            yn = Console.ReadKey().KeyChar.ToString();

            ConsoleKeyInfo consoleKey = Console.ReadKey();
           if (consoleKey.Key == ConsoleKey.F1)
           {
                orderedItems.Clear(); Console.Clear();
                goto again;
           }
           else if (consoleKey.Key == ConsoleKey.F2)
           {
                Console.WriteLine("All items to be checked out\n");
                Console.Clear();
                foreach (string item in orderedItems)
                { Console.WriteLine(item); }

                Console.WriteLine("\nTotal: " + totalPrice + " pesos");
                Console.WriteLine("Successfully checkd out.");
            cashEnter:
                Console.CursorVisible=true;
                Console.Write("\nPlease enter cash: ");
                var cash = Convert.ToDouble(Console.ReadLine());

                if (cash < totalPrice) { Console.WriteLine("Insufficient Cash", ConsoleColor.Red); Console.ReadKey(); goto cashEnter; }
                else
                {
                    PrintReceipt.printItems(productSelected, totalPrice, cash);
                    Console.WriteLine("\n\nClick [Enter] to continue");
                    Console.ReadKey();
                    goto again;
                }

                
            }
        }   

        static string ProductSelection()
        {
            selectedItem = 0;
            Console.WriteLine("List of products:");
            foreach (string item in products)
            { Console.WriteLine("-> " + item); }
            Console.Write("Choose product: ");
            string ans = Console.ReadLine().TrimEnd().TrimStart().ToLower();

            if (ans.Length == 0)
            { Console.Clear(); Console.WriteLine("Invalid, please try again."); return ProductSelection(); }
            else
            {
                foreach (string item in products)
                {
                    if (item.ToLower() == ans)
                    { return ans; }
                    selectedItem++;
                }
                Console.Clear(); Console.WriteLine("Invalid, please try again."); return ProductSelection();
            }
        }

        static double SelectQuantity()
        {
         
            Console.Write("Enter quantity: ");
            if (!int.TryParse(Console.ReadLine(), out int quantity) || quantity <= 0)
            { Console.Clear(); Console.WriteLine("Invalid, please try again."); return SelectQuantity(); }
            else { return quantity; }
        }
    }
}