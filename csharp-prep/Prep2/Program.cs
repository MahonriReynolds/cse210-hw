using System;
using System.Reflection.Metadata;

class Program
{
    static void Main(string[] args)
    {
        // Console.WriteLine("Hello Prep2 World!");

        Console.Write("Grade Percentage: ");
        string gradePercentageString = Console.ReadLine();
        int gradePercentageInt = int.Parse(gradePercentageString);

        char letter;
        if (gradePercentageInt >= 90)
        {
            letter = 'A';
        }
        else if (gradePercentageInt >= 80)
        {
            letter = 'B';
        }
        else if (gradePercentageInt >= 70)
        {
            letter = 'C';
        }
        else if (gradePercentageInt >= 60)
        {
            letter = 'D';
        }
        else
        {
            letter = 'F';
        }

        int lastDigit = gradePercentageInt % 10;
        char sign = '-';
        if (lastDigit >= 7)
        {
            sign = '+';
        }

        if ((letter == 'A' && sign == '+') || letter == 'F')
        {
            sign = '\0';
        }
           
        Console.WriteLine($"{letter}{sign}");
            

        if (gradePercentageInt >= 70)
        {
            Console.WriteLine("Passed the course");
        }
        else
        {
            Console.WriteLine("Passedn't the course");
        }

    }
}
