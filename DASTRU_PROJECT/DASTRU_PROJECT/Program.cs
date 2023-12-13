using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Threading;
using Alcuino.ConsoleWriter472;
using DASTRU_PROJECT;
using System.ComponentModel.Design;

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
            try
            {
                //Header
                ConsoleWriter.WriteHeader("DON MACCHIATOS", ConsoleColor.Cyan, 100);
                double totalPrice = 0;

                Console.WriteLine("\n[F1] DISPLAY PRODUCTS \t\t[F2] EXIT]\n"); Console.CursorVisible = false;
                var displayChoices = Console.ReadKey().KeyChar.ToString();
                string yn;
                ConsoleKeyInfo consoleKey = Console.ReadKey();//Key controlled option
                if (consoleKey.Key == ConsoleKey.F1)
                {
                    Console.CursorVisible = true;
                    string productSelected = ProductSelection();
                    Console.Clear();
                    double quantity = SelectQuantity();
                    Console.Clear();

                    totalPrice += quantity * price[selectedItem];
                    string productDetail = productSelected + " " + quantity + " pcs: " + (quantity * price[selectedItem]) + " pesos";

                    orderedItems.AddLast(productDetail);

                    //View Cart
                    Console.WriteLine("\nSuccessfully added.\n\n[F3] Order again? \t [F4] View Cart "); Console.CursorVisible = false;

                    //New Console keys
                    ConsoleKeyInfo keyView = Console.ReadKey();
                    if (keyView.Key == ConsoleKey.F7)
                    {
                        Cart cart = new Cart(productDetail, price[selectedItem]);
                        cart.DisplayCart();
                    }


                Checkout:
                    Console.WriteLine(productDetail);
                   
                    Console.WriteLine("\nSuccessfully added.\n\n[F3] Order again? \t [F4] Checkout? "); Console.CursorVisible = false;
                    yn = Console.ReadKey().KeyChar.ToString();

                    ConsoleKeyInfo ConsoleKeyNew = Console.ReadKey();

                    if (ConsoleKeyNew.Key == ConsoleKey.F3)
                    {
                        orderedItems.Clear(); Console.Clear();
                        goto again;
                    }
                    else if (ConsoleKeyNew.Key == ConsoleKey.F4)
                    {
                        Console.WriteLine("All items to be checked out\n");
                        Console.Clear();
                        foreach (string item in orderedItems)
                        { Console.WriteLine(item); }

                        Console.WriteLine("\nTotal: " + totalPrice + " pesos");
                        Console.WriteLine("Successfully checkd out.");
                    cashEnter:
                        Console.CursorVisible = true;
                        Console.Write("\nPlease enter cash: ");
                        var cash = Convert.ToDouble(Console.ReadLine());

                        if (cash < totalPrice) { Console.WriteLine("Insufficient Cash", ConsoleColor.Red); Console.ReadKey(); goto cashEnter; }
                        else
                        {
                            PrintReceipt.printItems(productSelected, totalPrice, cash, quantity);
                            Console.WriteLine("\n\nClick [Enter] to continue"); Console.CursorVisible=false;
                            Console.ReadKey();
                            goto again;
                        }

                    }
                    else Console.WriteLine("INVALID KEY", ConsoleColor.Red); Console.ReadKey(); Console.Clear(); goto Checkout;
                }
                else if (consoleKey.Key == ConsoleKey.F2) Environment.Exit(0);//Exit program
                else ConsoleWriter.WriteLine("INVALID KEY", ConsoleColor.Red); Console.ReadKey(); Console.Clear(); goto again;
            }
            catch
            {
                Console.WriteLine("INVALID KEY", ConsoleColor.Red);  Console.ReadKey(); Console.Clear(); goto again;
            }
            Console.ReadKey();

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