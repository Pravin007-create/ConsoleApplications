using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator_with_Type_Conversion
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("********Adding Two Numbers**********");
            while (true)
            {
                Console.WriteLine("Enter the First Number: ");
                bool num1 = double.TryParse(Console.ReadLine(), out double num2);
                Console.WriteLine("Enter the Second number:");
                bool num3 = double.TryParse(Console.ReadLine(), out double num4);
                Console.WriteLine("Select the operator(+,-,*,/)");
                char ch = Convert.ToChar(Console.ReadLine());
                switch (ch)
                {
                    case '+':
                        double ansp = (num2 + num4);
                        Console.WriteLine("Answer is:" + ansp);
                        break;

                    case '-':
                        double anss = (num2 - num4);
                        Console.WriteLine("Answer is:" + anss);
                        break;

                    case '*':
                        double ansm = (num2 * num4);
                        Console.WriteLine("Answer is:" + ansm);
                        break;
                    case '/':
                        double ansd = (num2 / num4);
                        Console.WriteLine("Answer is:" + ansd);
                        break;



                }
                Console.WriteLine("YOU WANT TO CONTINUE?(Y/N)");
                char sloop = Convert.ToChar(Console.ReadLine());
                if (sloop == 'N' || sloop == 'n')
                    break;

            }



        }
    }
}
