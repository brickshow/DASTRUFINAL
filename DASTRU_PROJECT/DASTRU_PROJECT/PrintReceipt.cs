using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Alcuino.ConsoleWriter472;

namespace DASTRU_PROJECT
{
    internal class PrintReceipt
    {
        //PrintItemInCart printI = new PrintItemInCart();
        public string itemCart { get; set; }
        string itemPrice { get; set; }
        double itemQuantity { get; set; }
        double itemCAsh { get; set; }
        double totalPrice { get; set; }

        static LinkedList<string> itemsList = new LinkedList<string>();
        static LinkedList<double> itemsPrice = new LinkedList<double>();


        public void getCash(double CASH)
        {
            itemCAsh = CASH;
        }
        public void getItems(string items, double price, double totalItem)
        {
            itemsList.AddLast(items);
            itemsPrice.AddLast(price);
           // this.itemPrice = price;
           // this.itemCAsh = CASH;
            this.totalPrice = totalItem;
        }

        public void printItems()
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

            //Print item using loop
            foreach (string item in itemsList)
            {
                foreach (char letter in item)
                {
                    Console.Write(letter);
                    Thread.Sleep(50);
                }
                Console.WriteLine();
                
            }


            int j = 0;
           // Console.SetCursorPosition(38, 8);
            //Print item using loop
            foreach (double price in itemsPrice)
            {
                Console.SetCursorPosition(30, 8 + j++);
                Console.Write(price);
                Thread.Sleep(100);
            }
            Console.WriteLine();

            //Print the line using substring
            for (int i = 0; i < printLine.Length; i++)
            {
                Console.Write(printLine.Substring(0, i + 1));
                Thread.Sleep(50);
                Console.SetCursorPosition(Console.CursorLeft - (i + 1), Console.CursorTop);
            }
            Console.WriteLine("\n\n");

            //Display the total price
            string totatAmount = "Total Amount                      P " + totalPrice;
            for (int i = 0; i < totatAmount.Length; i++)
            {
                Console.Write(totatAmount.Substring(0, i + 1));
                Thread.Sleep(40);
                Console.SetCursorPosition(Console.CursorLeft - (i + 1), Console.CursorTop);
            }
            Console.WriteLine();

            //Print total price
            string totatCash = "Total Cash                        P " + itemCAsh.ToString();
            for (int i = 0; i < totatCash.Length; i++)
            {
                Console.Write(totatCash.Substring(0, i + 1));
                Thread.Sleep(40);
                Console.SetCursorPosition(Console.CursorLeft - (i + 1), Console.CursorTop);
            }
            Console.WriteLine();

            ////Print total price
            //itemCAsh -= itemPrice;
            //string Change = "Change                            P " + itemCAsh.ToString();
            //for (int i = 0; i < Change.Length; i++)
            //{
            //    Console.Write(Change.Substring(0, i + 1));
            //    Thread.Sleep(40);
            //    Console.SetCursorPosition(Console.CursorLeft - (i + 1), Console.CursorTop);
            //}
        }
    }
}
