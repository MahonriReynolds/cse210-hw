
// Ended up using keys instead of the Enter and 'quit' options 
// shown in the demo. It fit the flow of this program better 
// where the user can both hide random words but then show the 
// hidden words back in right order.

using System;

class Program
{
    static void Main(string[] args)
    {
        // Make a Scripture object to demonstrate the program.
        // This uses the first constructor option, but both work.
        Reference demoReference = new Reference("Helaman", 5, 12);
        string demoContent = "And now, my sons, remember, remember that it is upon the rock of our Redeemer, who is Christ, the Son of God, that ye must build your foundation; that when the devil shall send forth his mighty winds, yea, his shafts in the whirlwind, yea, when all his hail and his mighty storm shall beat upon you, it shall have no power over you to drag you down to the gulf of misery and endless wo, because of the rock upon which ye are built, which is a sure foundation, a foundation whereon if men build they cannot fall.";
        Scripture demoScripture = new Scripture(demoReference, demoContent);

        // Start a loop to keep running the scripture display.
        bool run = true;
        while (run)
        {
            Console.Clear();

            // Print out the key for the program. 
            Console.WriteLine("\n\n↑ --> Show");
            Console.WriteLine("↓ --> Hide");
            Console.WriteLine("\nEsc --> Exit\n\n");

            // Print out the scripture object. 
            Console.WriteLine(demoScripture.Spaghettify());

            // Get the next key press from the user and check if it's 
            // a valid option. If valid, run the associated scripture
            // method to either hide or show words.
            switch (Console.ReadKey(false).Key)
            {
                case ConsoleKey.UpArrow:
                    demoScripture.UndoLastHide();
                    break;

                case ConsoleKey.DownArrow:
                    if (!demoScripture.TryHideRandom())
                    {
                        run = false;
                    }
                    break;

                case ConsoleKey.Escape:
                    run = false;
                    break;
            }
        }
    }
}