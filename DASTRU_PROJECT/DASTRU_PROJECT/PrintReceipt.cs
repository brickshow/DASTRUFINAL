using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Alcuino.ConsoleWriter472;

namespace DASTRU_PROJECT
{
    internal class PrintReceipt
    {
        string items { get; set; }

        public static void printItems(string items, double price, double CASH, double quantity)
        {
            Console.CursorVisible = true;
            ConsoleWriter.WriteHeader("DON MACCHIATOS", ConsoleColor.Cyan, 100);
            
            
            Console.WriteLine("Priting receipt....\n");
            string printHeader = "             DON MACCHIATOS            ";
            string printLine = "---------------------------------------";

            //Print the header using substring
            for (int i = 0; i < printHeader.Length; i++)
            { 
                Console.Write(printHeader.Substring(0, i + 1));
                Thread.Sleep(40);
                Console.SetCursorPosition(Console.CursorLeft - (i + 1), Console.CursorTop);
            }
            Console.WriteLine("\n");


            //Print the line using substring
            for (int i = 0; i < printLine.Length; i++)
            {
                Console.Write(printLine.Substring(0, i + 1));
                Thread.Sleep(40);
                Console.SetCursorPosition(Console.CursorLeft - (i + 1), Console.CursorTop);
            }
            Console.WriteLine();

            //Print the items using substring

            for (int i = 0; i < items.Length; i++)
            {
                Console.Write(items.Substring(0, i + 1));
                Thread.Sleep(40);
                Console.SetCursorPosition(Console.CursorLeft - (i + 1), Console.CursorTop);
            }




            string printPrice = price.ToString();
            //Print the price using substring
            Console.SetCursorPosition(35, 8);
            for (int i = 0; i < printPrice.Length; i++)
            {
                Console.Write(printPrice.Substring(0, i + 1));
                Thread.Sleep(40);
                Console.SetCursorPosition(Console.CursorLeft - (i + 1), Console.CursorTop);
            }
            Console.WriteLine();

            //Print the line using substring
            for (int i = 0; i < printLine.Length; i++)
            {
                Console.Write(printLine.Substring(0, i + 1));
                Thread.Sleep(40);
                Console.SetCursorPosition(Console.CursorLeft - (i + 1), Console.CursorTop);
            }
            Console.WriteLine("\n\n");

            //Display the total price
            string totatAmount = "Total Amount                      P " + printPrice;
            for (int i = 0; i < totatAmount.Length; i++)
            {
                Console.Write(totatAmount.Substring(0, i + 1));
                Thread.Sleep(40);
                Console.SetCursorPosition(Console.CursorLeft - (i + 1), Console.CursorTop);
            }
            Console.WriteLine();

            //Print total price
            string totatCash = "Total Cash                        P " + CASH.ToString();
            for (int i = 0; i < totatCash.Length; i++)
            {
                Console.Write(totatCash.Substring(0, i + 1));
                Thread.Sleep(40);
                Console.SetCursorPosition(Console.CursorLeft - (i + 1), Console.CursorTop);
            }
            Console.WriteLine();

            //Print total price
            CASH -= price;
            string Change = "Change                            P " + CASH.ToString();
            for (int i = 0; i < Change.Length; i++)
            {
                Console.Write(Change.Substring(0, i + 1));
                Thread.Sleep(40);
                Console.SetCursorPosition(Console.CursorLeft - (i + 1), Console.CursorTop);
            }

        }
    }
}
