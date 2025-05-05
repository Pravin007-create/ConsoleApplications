using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * Exercise: Reverse & Average

Read 5 numbers into an array.

Reverse the array using a loop and print it.

Calculate and print the average of the numbers.

 * */

namespace Reverse_and_average
{
    class Program
    {
        static void Main(string[] args)

        {
            int array_index = 0;  //for array index
            int array_size = 5;   //for array size to increase the size when it full
            int[] array = new int[array_size]; // array
            double total_value = 0;   //for total value

            while (true)
            {
            GettingNumber:
                Console.WriteLine("****For EXIT Press'ENTER'key****");
                Console.WriteLine($"Enter the Number {array_index + 1}");
                string value_instring = Console.ReadLine();
                if (string.IsNullOrEmpty(value_instring))
                {
                    break;                             ///////// For exit 
                }


                bool value_condition = int.TryParse(value_instring, out int value);

                if (value_condition)
                {
                    //checking the size of array if true the array size doubled
                    if (array_index == array_size)
                    {
                        Array.Resize(ref array, array_size * 2);
                        array_size *= 2;
                        array[array_index] = value;
                        array_index++;

                    }
                    //else it add 
                    else
                    {
                        array[array_index] = value;
                        array_index++;
                    }

                }
                else
                {
                    Console.WriteLine("**Invalid Numver**");
                    goto GettingNumber;
                }
            }

            ///checking if the array having elements
            if (array_index > 0)
            {
                Console.WriteLine("*****Array in Reverse********");

                for (int i = array_index - 1; i >= 0; i--)
                {

                    Console.Write(" " + array[i] + ",");
                    total_value += array[i];

                }
                Console.WriteLine();
                double average = total_value / array_index;

                Console.WriteLine($"Total is :{total_value} ");
                Console.WriteLine($"The average is : {average:f2}");

            }
            else
            {
                Console.WriteLine("**No Elements in Array**");
            }
        }


    }
}
