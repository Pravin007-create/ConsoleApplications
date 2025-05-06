using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
  Exercise: Safe Number Collector

Continuously read inputs from the user.

Try to convert each to an int. If successful, add to an array.

Stop when the user types "exit".

Display all valid integers collected.

 */

namespace Safe_Number_Collector
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>();

            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("********Safe Number Collector*******");
            Console.ResetColor();
            while (true)
            {
                
                Console.WriteLine("\n**For exit Press 'Enter Key'**");
                Console.WriteLine("\nEnter the Number :");
                string input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    break;
                }
                    
                bool cond = int.TryParse(input, out int addnum);
                if (cond)
                {
                    list.Add(addnum);
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nEnter the valid number");
                    Console.ResetColor();
                }

            }
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine($"\n----The integers-----");
            Console.ResetColor();
            Console.WriteLine();
            
            foreach (int i in list)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(" "+i+",");

            }
            Console.ResetColor();
        }
    }
}
