using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expense_Tracker
{

    internal class Program
    {
        static void Main(string[] args)
        {
            bool flage = true;
            List<Expenses> TotalItems = new List<Expenses>();
            Console.ForegroundColor = ConsoleColor.Green;   
            Console.WriteLine("=========================================");
            Console.WriteLine("         DAILY EXPENSE TRACKER");
            Console.WriteLine("=========================================\n");
            Console.ResetColor();
            while (flage)
            {
                Expenses Item = new Expenses();

                Expenses name_exist_object =TotalItems.FirstOrDefault(x => x.name.ToUpper() == Item.name.ToUpper());
                if (name_exist_object!=null)
                {
                    name_exist_object.ReplaceName(Item.name);
                    name_exist_object.ReplaceAmount(Item.amount);   
                }
                else
                {
                    TotalItems.Add(Item);
                }
                    
            ContinueAdding:
                Console.WriteLine("\nNeed to Continue (Y/N)");
                bool flag_Consdition = char.TryParse(Console.ReadLine(), out char newflag);
                if (flag_Consdition)
                {
                    if (newflag == 'y' || newflag == 'Y' || newflag == 'N' || newflag == 'n')
                    {
                        if(newflag == 'y'|| newflag == 'Y')
                        {
                            flage = true;
                        }
                        else
                        {
                            flage= false;
                        }
                       

                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n*****Invalid Input****");
                        Console.ResetColor();
                        Console.WriteLine("\nEnter only (y/n):");
                        goto ContinueAdding;

                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n******Enter the Valid Input*****");
                    Console.ResetColor();
                    goto ContinueAdding;
                }

            }

            double TotalAmount = TotalItems.Sum(x=>x.amount); //Getting the total amount from List
            double average_amount = TotalAmount/TotalItems.Count; //Getting the average amount
            double maximun_amount = TotalItems.Max(x => x.amount);//Getting the maximum amount
            var max_name = TotalItems.Where(x => x.amount == maximun_amount);//Getting the maximum amount names
            double min_amount = TotalItems.Min(x => x.amount); //Getting the minimum amount
            var min_name =TotalItems.Where(x=>x.amount== min_amount);//Getting the maximum amount names

            Console.Clear();

            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor=ConsoleColor.Black;
            Console.WriteLine($"\n\t^^^^^^^^^TOTAL EXPENSES^^^^^^^^^^^");
            Console.ResetColor();
            Console.BackgroundColor = ConsoleColor.Magenta;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n\tEXPENSE NAME\t\tAMOUNT\n");
            Console.ResetColor();
            foreach (Expenses Item in TotalItems) {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\n\t{Item.name}\t\t|\t{Item.amount:f2}");
                Console.ResetColor();
            }
            Console.BackgroundColor= ConsoleColor.Red;
            Console.ForegroundColor=ConsoleColor.White;
            Console.WriteLine($"\n\tTotal Amount :\t\t{TotalAmount:f2}");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n\t====================================");
            Console.ResetColor();
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine($"\t^^^^^^^^^HIGHEST EXPENSES^^^^^^^^^^^");
            Console.ResetColor();
            Console.BackgroundColor = ConsoleColor.Magenta;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n\tEXPENSE NAME\t\tAMOUNT");
            Console.ResetColor();
            foreach(Expenses expenses in max_name)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\n\t{expenses.name}\t\t\t{expenses.amount:f2}");

            }
            
            Console.WriteLine($"\n\t=======================================");
            Console.ResetColor();
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine($"\n\t^^^^^^^^^LOWEST EXPENSES^^^^^^^^^^^");
            Console.ResetColor();
            Console.BackgroundColor = ConsoleColor.Magenta;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n\tEXPENSE NAME\t\tAMOUNT");
            Console.ResetColor();
            foreach (Expenses item in min_name) {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\n\t{item.name}\t\t\t{item.amount:f2}");

            }
            Console.WriteLine($"\n\t=======================================");
            Console.ResetColor();









            Console.ReadKey();
        }
    }
}
