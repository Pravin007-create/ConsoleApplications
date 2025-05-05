using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            char Loop = 'Y';
            char ConWitPreAns = 'N';
            int result = 0;
            Console.WriteLine("******************SIMPLE CALCULATOR******************");
            while (Loop == 'y' || Loop == 'Y')
            {
                Console.WriteLine("Enter the number of values you want to Calculate: ");
                int count = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Select the Symbol( + , - , * , / )");
                string Symbol = Console.ReadLine();
                int[] Values = new int[count];
                if (ConWitPreAns == 'N' || ConWitPreAns == 'n')
                {
                    result = 0;
                }


                int LenOfArr = Values.Length;

                while (count > 0)
                {
                    Console.WriteLine("Enter the value " + (LenOfArr - (count - 1)) + ":");
                    Values[count - 1] = Convert.ToInt32(Console.ReadLine());
                    count--;
                }
                switch (Symbol)
                {
                    case "+":
                        foreach (int i in Values)
                        {
                            result += i;
                        }
                        Console.WriteLine("Answer is :" + result);
                        break;
                    case "-":
                        for (int i = Values.Length - 1; i >= 0; i--)
                        {
                            if (result == 0)
                            {
                                result = Values[i];
                            }
                            else
                                result -= Values[i];
                        }

                        Console.WriteLine("Answer is :" + result);
                        break;
                    case "*":
                        if (result == 0)
                            result = 1;
                        for (int i = Values.Length - 1; i >= 0; i--)
                        {
                            result *= Values[i];
                        }
                        Console.WriteLine("Answer is :" + result);
                        break;
                    case "/":
                        for (int i = Values.Length - 1; i >= 0; i--)
                        {
                            if (result == 0)
                            {
                                result = Values[i];
                            }
                            else
                                result /= Values[i];
                        }
                        Console.WriteLine("Answer is :" + result);
                        break;
                }
                Console.WriteLine("Do You want to Continue?(Y/N) :");
                Loop = Convert.ToChar(Console.ReadLine());
                if (Loop == 'N' || Loop == 'n')
                    break;
                Console.WriteLine("Need to Continue with Previous Answer?(Y/N) :");
                ConWitPreAns = Convert.ToChar(Console.ReadLine());

            }


        }
    }
}
