

public class Controller
{
    private PlayerO _player;

    public Controller(PlayerO player)
    {
        this._player = player;
    }

    public (int[], int[]) MovePlayer()
    {
        int[] step = [0, 0];

        ConsoleKeyInfo keyInfo = Console.ReadKey();
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
        }

        this._player.Advance(step);
        return (step, this._player.Locate());
    }
}

