using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expense_Tracker
{
    internal class Expenses
    {
       
        public string name {  get;private set; }
        public double amount {  get;private  set; }
       internal Expenses()
        {
        
            SetName();
            SetAmount();
        }
        internal void ReplaceName(string s)
        {
            name = s;
        }
        internal void ReplaceAmount(double d)
        {
            amount+= d;
        }
        internal void SetName()
        {
        SetName:
            try
            {
                Console.WriteLine("\nEnter the Expense Name:");
                string newname = Console.ReadLine();
                if (string.IsNullOrEmpty(newname))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nThe name should not be Empty");
                    Console.ResetColor();
                    goto SetName;
                }
                else if (!newname.Any(char.IsLetter))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nMust have Minimum 1 letter");
                    Console.ResetColor();
                    goto SetName;
                }
                else
                {
                    name = newname;
                }
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ResetColor();
                goto SetName;
            }
           


        }
        internal void SetAmount() {
        SetAmount:
            Console.WriteLine($"\nEnter the Amount for the {name} :");
            bool amount_true = double.TryParse(Console.ReadLine(), out double new_amount);
            if (amount_true) { 
                if(new_amount<= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nAmount must be Geater than '0'");
                    Console.ResetColor();
                    goto SetAmount;
                }
                else{ 
                    amount = new_amount;
                   
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n**Invalid Input**");
                Console.ResetColor();
                goto SetAmount;

            }



        }

        

    }
}
