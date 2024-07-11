

public class Controller
{
    public Controller()
    {
    }
    
    public (int[], bool) GetStep()
    {
        int[] step = [0, 0];
        bool escape = false;
        if (Console.KeyAvailable)
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);

            switch (keyInfo.Key)
            {
                case ConsoleKey.LeftArrow:
                    step = [-1, 0];
                    break;
                case ConsoleKey.UpArrow:
                    step = [0, -1];
                    break;
                case ConsoleKey.RightArrow:
                    step = [1, 0];
                    break;
                case ConsoleKey.DownArrow:
                    step = [0, 1];
                    break;
                case ConsoleKey.Escape:
                    escape = true;
                    break;
            }
        }
        return (step, escape);
    }
}

