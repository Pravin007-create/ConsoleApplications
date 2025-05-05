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
            while (true)
            {
                Console.WriteLine("********Safe Number Collector*******");
                Console.WriteLine("Enter the Number :");
                string input = Console.ReadLine();
                if (input == "Exit" || input == "exit")
                    break;
                bool cond = int.TryParse(input, out int addnum);
                if (cond)
                {
                    list.Add(addnum);
                }
                else
                {
                    Console.WriteLine("Enter the valid number");
                }

            }
            foreach (int i in list)
            {
                Console.WriteLine($"The integers : {i}");
            }
        }
    }
}
