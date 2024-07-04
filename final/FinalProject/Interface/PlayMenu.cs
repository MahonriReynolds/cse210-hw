



public class PlayMenu : Interface
{
    public PlayMenu() : base (@"",[]){}

    public int[] GetMovement()
    {
        ConsoleKeyInfo keyInfo = Console.ReadKey(true);

        while (Console.KeyAvailable)
        {
            Console.ReadKey(true);
        }

        switch (keyInfo.Key)
        {
            case ConsoleKey.LeftArrow:
                return [-1, 0];
            case ConsoleKey.RightArrow:
                return [1, 0];
            case ConsoleKey.DownArrow:
                return [0, 1];
            case ConsoleKey.UpArrow:
                return [0, -1];


            case ConsoleKey.Backspace:
                return [-3, 0];
            case ConsoleKey.Tab:
                return [3, 0];


            case ConsoleKey.Escape:
                return [-1, -1];
            default:
                return [0, 0];
        }
    }

    public override int Display()
    {
        return 0;
    }
}