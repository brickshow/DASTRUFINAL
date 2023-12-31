﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Threading;
using Alcuino.ConsoleWriter472;
using DASTRU_PROJECT;
using System.ComponentModel.Design;
using System.Security.Policy;

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
        static LinkedList<double> orderedPrice = new LinkedList<double>();
        static int selectedItem;
        static void Main(string[] args)
        {
            PrintReceipt print = new PrintReceipt();

        again:
            try
            {
                //Header
                ConsoleWriter.WriteHeader("DON MACCHIATOS", ConsoleColor.Cyan, 100);
                double totalPrice = 0;
                double cash;

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
                    double totalPrices = price[selectedItem] * quantity;
                    Console.Clear();

                    totalPrice += quantity * price[selectedItem];
                    string productDetail = productSelected + " " + quantity + " pcs: " + (quantity * price[selectedItem]) + " pesos";
                    orderedItems.AddLast(productDetail);
                    orderedPrice.AddLast(price[selectedItem] * quantity);

                    //Console.WriteLine(productDetail);
                    //View Cart
                viewCart:    
                    try
                    {
                        print.getItems(productSelected, totalPrice, orderedPrice.Sum());
                        Console.WriteLine("\nSuccessfully added.\n\n[F6] Order again? \t [F7] View Cart "); Console.CursorVisible = false;

                        //New Console keys
                        ConsoleKeyInfo keyView = Console.ReadKey();
                        if (keyView.Key == ConsoleKey.F7)
                        {
                            DisplayCart();
                            goto Checkout;
                        }
                        else if (keyView.Key == ConsoleKey.F6) goto again;
                        else Console.WriteLine("INVALID KEY", ConsoleColor.Red); Console.ReadKey(); Console.Clear(); goto viewCart;

                    }
                    catch
                    {
                        Console.WriteLine("INVALID KEY", ConsoleColor.Red); Console.ReadKey(); Console.Clear(); goto viewCart;
                    }

                Checkout:
                      
                    Console.WriteLine("\n\n[F3] Remove Item? \t [F4] Checkout? \t [F9] Add More Coffee"); Console.CursorVisible = false;
                    yn = Console.ReadKey().KeyChar.ToString();

                    ConsoleKeyInfo ConsoleKeyNew = Console.ReadKey();

                    if (ConsoleKeyNew.Key == ConsoleKey.F3)
                    {
                        RemoveProduct();

                        Console.WriteLine("Sucessfully removed");
                        Console.ReadKey();
                        Console.Clear();
                        DisplayCart();

                        Console.WriteLine("");
                       // goto again;
                    }
                    else if (ConsoleKeyNew.Key == ConsoleKey.F4)
                    {
                        
                        Console.WriteLine("All items to be checked out\n");
                        Console.Clear();
                        foreach (string item in orderedItems)
                        { Console.WriteLine(item); }

                        Console.WriteLine("\nTotal: " + orderedPrice.Sum() + " pesos");
                        Console.WriteLine("Successfully checkd out.");
                    cashEnter:
                        Console.CursorVisible = true;
                        Console.Write("\nPlease enter cash: ");
                        cash = Convert.ToDouble(Console.ReadLine());
                        print.getCash(cash);


                        if (cash < orderedPrice.Sum()) { Console.WriteLine("Insufficient Cash", ConsoleColor.Red); Console.ReadKey(); goto cashEnter; }
                        else
                        {
                            print.printItems();
                            Console.WriteLine("\n\nClick [Enter] to continue"); Console.CursorVisible=false;
                            Console.ReadKey();
                            goto again;
                        }

                    }

                    else if (ConsoleKeyNew.Key == ConsoleKey.F9) goto again;
                    else Console.WriteLine("INVALID KEY", ConsoleColor.Red); Console.ReadKey(); Console.Clear(); goto Checkout;
                }
                else if (consoleKey.Key == ConsoleKey.F2) Environment.Exit(0);//Exit program
                else ConsoleWriter.WriteLine("INVALID KEY", ConsoleColor.Red); Console.ReadKey(); Console.Clear(); goto again;
            }
            catch
            {
                Console.WriteLine("INVALID KEY!", ConsoleColor.Red);  Console.ReadKey(); Console.Clear(); goto again;
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

        static void DisplayCart()
        {
            Console.Clear();
            if (orderedItems.Count == 0)
            {
                ConsoleWriter.WriteLine("Item In Cart\n");
                Console.WriteLine("==========================================");
                Console.WriteLine("Cart is EMPTY");
                Console.WriteLine("==========================================");
            }
            else
            {
                ConsoleWriter.WriteLine("Item In Cart\n");
                Console.WriteLine("==========================================");
                int i = 1;
                foreach (string item in orderedItems)
                {
                    Console.WriteLine("{0} ->  " + item, i++);
                }
                Console.WriteLine("==========================================");
            }   
        }

        static void RemoveProduct()
        {
            Console.Write("\nEnter the coffee number you want to remove: ");
            if (int.TryParse(Console.ReadLine(), out int indexToRemove))
            {
                try
                {
                    // Remove item at the specified index
                    RemoveCoffe(orderedItems, indexToRemove);
                }
                catch (IndexOutOfRangeException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid integer.");
            }
        }

        // Method to remove an item from the linked list using a 1-based index
        static void RemoveCoffe<T>(LinkedList<T> linkedList, int index)
        {
            if (index < 1 || index > linkedList.Count)
            {
                throw new IndexOutOfRangeException("Invalid index");//return errors
            }

            // Adjust the index to match the 0-based index of LinkedList<T>
            int adjustedIndex = index - 1;

            LinkedListNode<T> nodeToRemove = linkedList.First;
            for (int i = 0; i < adjustedIndex; i++)
            {
                nodeToRemove = nodeToRemove.Next;
            }

            linkedList.Remove(nodeToRemove);
        }
    }
}