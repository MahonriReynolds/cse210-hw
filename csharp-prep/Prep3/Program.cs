using System;

class Program
{
    static void Main(string[] args)
    {

        bool play_next_round = true;

        while (play_next_round)
        {

            Random randomGenerator = new();
            int magic_number = randomGenerator.Next(1, 101);

            int user_guess = 0;
            int guess_count = 0;

            while (user_guess != magic_number)
            {
                Console.Write("What is your guess? ");
                user_guess = int.Parse(Console.ReadLine());
                guess_count++;

                if (user_guess == magic_number)
                {
                    Console.Write("You guessed it!\n");
                }
                else if (user_guess < magic_number)
                {
                    Console.Write("Higher\n");
                }
                else
                {
                    Console.Write("Lower\n");
                }

            }

            Console.Write($"Guessed in {guess_count} guess(s)\n");

            Console.Write("Play again? (yes/no) ");
            string play_again_answer = Console.ReadLine();
            if (play_again_answer != "yes")
            {
                play_next_round = false;
            }
        }
    }
}