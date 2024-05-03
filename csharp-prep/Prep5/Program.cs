using System;

class Program
{

    static void DisplayWelcome ()
    {
        Console.Write("Welcome to the Program!\n");
    }

    static string PromptUserName ()
    {
        Console.Write("Please enter your name: ");
        string user_name = Console.ReadLine();
        return user_name;
    }

    static int PromptUserNumber ()
    {
        Console.Write("Please enter your favorite number: ");
        int user_number = int.Parse(Console.ReadLine());
        return user_number;
    }

    static int SquareNumber (int number)
    {
        int squared_number = number * number;
        return squared_number;
    }

    static void DisplayResult (string name, int number)
    {
        Console.Write($"{name}, the square of your number is {number}\n");
    }

    static void Main(string[] args)
    {
        DisplayWelcome();
        string user_name = PromptUserName();
        int user_number = PromptUserNumber();
        int squared_user_number = SquareNumber(user_number);
        DisplayResult(user_name, squared_user_number);
    }
}