using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/* Exercise: GislenSoftware with a Twist

Print numbers from 1 to 100.

For multiples of 3 print "Gislen", for 5 print "Software", for both print "Gislen Software".

Add: For numbers divisible by 7, skip printing them altogether.
*/
namespace GislenSoftware_with_a_Twist
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 1; i <= 100; i++)

            {
                int c3 = 0;
                int c5 = 0;
                if (i % 3 == 0 && i % 5 == 0)
                {
                    Console.WriteLine("Gislen Software");
                    c3++;
                    c5++;
                }
                else if (i % 3 == 0 && c3 == 0)
                {
                    Console.WriteLine("Gislen");
                }
                else if (i % 5 == 0 && c5 == 0)
                {
                    Console.WriteLine("Software");
                }

                else if (i % 7 == 0)
                {
                    continue;
                }
            }
        }
    }
}
