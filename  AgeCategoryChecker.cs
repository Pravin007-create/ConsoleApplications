using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
/* Exercise: Age Category Checker

Ask for a user's age.

Use a ternary operator to print: "Child" (under 13), "Teen" (13-17), "Adult" (18-59), or "Senior" (60+).
*/

namespace Age_Category_Checker
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("----------Age Category Checker------------");
            while (true)
            {
            EnterAge:
                string category;
                Console.WriteLine("\n**For EXIT Press'ENTER'key**");
                Console.WriteLine("\nEnter your age: ");

                string age_instring = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(age_instring))
                {
                    break;
                }
                bool age_condition = int.TryParse(age_instring, out int age);
                if (age_condition)
                {
                    if (age <= 0)
                    {
                        Console.WriteLine("\n**Age Must be Greater than '0'***");
                        goto EnterAge;
                    }
                    else
                    {
                        category = age < 13 ? "Child" :
                                         age < 18 ? "Teen" :
                                         age < 60 ? "Adult" : "Senior";

                    }



                    Console.WriteLine($"\nCategory is {category}");
                }
                else
                {
                    Console.WriteLine("\n**Invalid Input**");

                }
            }
        }
    }
}

