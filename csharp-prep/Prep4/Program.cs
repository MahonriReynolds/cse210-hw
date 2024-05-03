using System.Collections.Generic;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        List<int> user_numbers = new List<int>();

        Console.Write("Enter a list of numbers, type 0 when finished.\n");

        int next_user_num;
        do 
        {
            Console.Write("Enter a number: ");
            next_user_num = int.Parse(Console.ReadLine());
            if (next_user_num != 0)
            {
                user_numbers.Add(next_user_num);
            }
        } while (next_user_num != 0);
        
        Console.Write($"The sum is: {user_numbers.Sum()}\n");
        Console.Write($"The average is: {user_numbers.Average()}\n");
        Console.Write($"The largest number is: {user_numbers.Max()}\n");

        Console.Write($"The smallest positive number is: {user_numbers.Where(i => i > 0).Min()}\n");

        Console.Write($"The sorted list is:\n");
        user_numbers.Sort();
        foreach(var num in user_numbers)
        {
            Console.WriteLine(num);
        }
    }
}