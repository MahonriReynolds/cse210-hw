








// Added a different kind of animation / style to each activity.
// Made sure to not pick any repeat prompts until the entire list was used. 
//





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
                    ReflectionActivity ra = new ReflectionActivity();
                    ra.PromptReflection();
                    break;
                
                case "3":
                    ListingActivity la = new ListingActivity();
                    la.PromptListing();
                    break;
                
                default:
                    Console.Write("\nOption was in the list of approved options but was somehow still not valid. . . ");
                    for (int i = 0; i < 3; i++)
                    {
                        Console.Write("\b\b  \b\b");
                        Thread.Sleep(1000);
                    }
                    break;
            }
        }
    }
}