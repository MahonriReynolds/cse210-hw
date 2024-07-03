



public class PlayMenu : UserInterface
{
    public PlayMenu() : base (@"",[]){}

    public int GetMovement()
    {
        ConsoleKeyInfo keyInfo = Console.ReadKey(true);

        while (Console.KeyAvailable)
        {
            Console.ReadKey(true);
        }

        switch (keyInfo.Key)
        {
            case ConsoleKey.LeftArrow:
                return -1;
            case ConsoleKey.RightArrow:
                return 1;
            case ConsoleKey.DownArrow:
                return -3;
            case ConsoleKey.UpArrow:
                return 3;
            case ConsoleKey.Escape:
                return 2;
            default:
                return 0;
        }
    }

    public override int Display()
    {
        return 0;
    }
}