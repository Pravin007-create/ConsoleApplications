using System;
using System.Collections;

class Program
{
    static void Main()
    {
        int array_size = 1;
        ArrayList Numbers = new ArrayList();
        Console.BackgroundColor = ConsoleColor.Yellow;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.WriteLine("\nWelcome to the Second Largest Number Finder!");
        Console.ResetColor();
        while (true)
        {
            Console.WriteLine("\nFor Exit Press 'Enter key'");
            Console.WriteLine("\t(or)");
            Console.WriteLine($"Enter the Number {array_size}:");
            string number_instring = Console.ReadLine();
            if (string.IsNullOrEmpty(number_instring))
            {
                break;
            }
            bool number_condition = int.TryParse(number_instring, out int number);
            if (number_condition)
            {
                Numbers.Add(number);
                array_size++;
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Red;

                Console.WriteLine("\n**Please enter a valid number**");
                Console.ResetColor();


            }
           
        }

        int largest_number = int.MinValue;
        int second_largest_number = int.MinValue;

        foreach (int element in Numbers)
        {
            if (element > largest_number)
            {
                second_largest_number = largest_number;
                largest_number = element;
                
            }

            else if (element > second_largest_number && element < largest_number)
            {
                second_largest_number = element;
            }
        }

        if (second_largest_number == int.MinValue)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("\n**There is no second largest unique number**");
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nThe second largest number is: " + second_largest_number);
            Console.ResetColor();
        }
    }

}


