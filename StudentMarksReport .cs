using System;

class Program
{
    public static void Main(string[] args)
    {
        while (true)
        {
            Console.Write("Enter student name: ");
            string name = Console.ReadLine();

            int total = 0;
            for (int i = 1; i <= 5; i++)
            {
                Console.Write($"Enter marks for subject {i}: ");
                int marks = int.Parse(Console.ReadLine());
                total += marks;
            }

            double average = total / 5;
            string grade;

            if (average >= 90)
                grade = "A";
            else if (average >= 75)
                grade = "B";
            else if (average >= 60)
                grade = "C";
            else
                grade = "F";

            Console.WriteLine("\n--- Student Report ---");
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Total Marks: {total}");
            Console.WriteLine($"Average Marks: {average:F2}");
            Console.WriteLine($"Grade: {grade}");

            Console.Write("\nDo you want to enter another student? (y/n): ");
            string choice = Console.ReadLine().ToLower();
            if (choice != "y")
                break;

            Console.WriteLine();
        }
    }
}
