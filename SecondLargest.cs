using System;

class Program
{
    static void Main()
    {
        int[] numbers = new int[10];
        Console.WriteLine("Enter 10 integers:");


        for (int i = 0; i < 10; i++)
        {
            numbers[i] = int.Parse(Console.ReadLine());
        }

        int largest = int.MinValue;
        int secondLargest = int.MinValue;

        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i] > largest)
            {
                secondLargest = largest;
                largest = numbers[i];
            }

            else if (numbers[i] > secondLargest && numbers[i] < largest)
            {
                secondLargest = numbers[i];
            }
        }

        if (secondLargest == int.MinValue)
        {
            Console.WriteLine("There is no second largest unique number.");
        }
        else
        {
            Console.WriteLine("The second largest number is: " + secondLargest);
        }
    }
}
