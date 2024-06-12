using System;

class Program
{
    static void Main(string[] args)
    {


        string mainMenu = @"
-------------------------------
| Main Menu:                  |
|                             |
|     0) Quit                 |
|     1) Breathing Activity   |
|     2) Reflection Activity  |
|     3) Listing Activity     |
|                             |
-------------------------------
        ";

        string choice = "";
        List<string> options = ["0", "1", "2", "3"];
        while (choice != "0")
        {

            do
            {
                Console.Clear();
                Console.WriteLine(mainMenu);
                Console.Write(" Select > ");
                choice = Console.ReadLine();

            }while (!options.Contains(choice));
            

            switch (choice)
            {
                case "0":
                    break;
            
                case "1":
                    BreathingActivity ba = new BreathingActivity();
                    ba.PromptBreathing();
                    break;

                case "2":
                    Console.WriteLine("2");
                    break;
                
                case "3":
                    Console.WriteLine("3");
                    break;
                
                default:
                    break;
            }
        }
    }
}