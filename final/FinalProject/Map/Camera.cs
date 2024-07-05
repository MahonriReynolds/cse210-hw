
public class Camera
{
    private int _width;
    private int _center;

    private Map _map;
    private Player _player;

    private List<X> _xes;

    private char[,] _previousBuffer;
    private int _rows;
    private int _totalCols;

    public Camera(int width, Map map, Player player, List<X> xes)
    {
        this._width = width;
        this._center = 0;

        this._map = map;
        this._player = player;

        this._xes = xes;

        this._rows = 30;
        int cols = 30;
        this._totalCols = cols * 3;

        this._previousBuffer = new char[_rows, _totalCols];
    }

    public int Watch(TimeSpan timing, char playerModel = ' ')
    {
        if (playerModel == ' ')
        {
            playerModel = this._player.Show();
        }

        int[] playerPos = this._player.Locate();
        this._center = playerPos[0] / 30;

        List<Tuple<int, char[,]>> tileData = this._map.GetTileDataInRange(
            Math.Max(0, this._center - this._width),
            Math.Min(this._center + this._width, this._center - this._width + 2) + 1
        );

        char[,] buffer = new char[_rows, _totalCols];
        ConsoleColor[,] colorBuffer = new ConsoleColor[_rows, _totalCols];

        // Initialize buffer with map tiles
        for (int i = 0; i < _rows; i++)
        {
            int tileIndex = 0;
            foreach (var data in tileData)
            {
                int consoleStartX = tileIndex * 30; // Adjusted for zero-based index
                tileIndex++;

                for (int j = 0; j < 30; j++)
                {
                    int consoleX = consoleStartX + j;
                    if (consoleX < _totalCols)
                    {
                        buffer[i, consoleX] = data.Item2[i, j];
                        colorBuffer[i, consoleX] = Console.ForegroundColor; // Or tile-specific color
                    }
                }
            }
        }

        foreach (X x in this._xes)
        {
            int[] xPos = x.Locate();
            // Ensure X objects are displayed correctly only after the player moves past the first tile
            if (this._center > 0 && xPos[0] >= (this._center - this._width) * 30 && xPos[0] <= (this._center + this._width) * 30 + 29)
            {
                int consoleX = xPos[0] - (this._center - this._width) * 30;
                if (consoleX >= 0 && consoleX < _totalCols && xPos[1] >= 0 && xPos[1] < _rows)
                {
                    buffer[xPos[1], consoleX] = x.Show();
                    colorBuffer[xPos[1], consoleX] = ConsoleColor.Red;

                    if (playerPos[0] == xPos[0] && playerPos[1] == xPos[1])
                    {
                        x.Aggro(this._player);
                        this._player.TakeDamage(x.DealDamage());
                    }
                }
            }
        }

        // Adjust player position if in the first tile
        int playerConsoleX = playerPos[0] - (this._center - this._width) * 30;
        if (this._center == 0)
        {
            playerConsoleX = playerPos[0]; // Place player at the exact position in the buffer
        }

        if (playerPos[1] >= 0 && playerPos[1] < _rows && playerConsoleX >= 0 && playerConsoleX < _totalCols)
        {
            buffer[playerPos[1], playerConsoleX] = playerModel;
            colorBuffer[playerPos[1], playerConsoleX] = GetPlayerColor(this._player.GetHealth());
        }

        // Update console display based on buffer changes
        Console.CursorVisible = false;
        for (int i = 0; i < _rows; i++)
        {
            for (int j = 0; j < _totalCols; j++)
            {
                Console.SetCursorPosition(j, i);
                Console.ForegroundColor = colorBuffer[i, j];
                Console.Write(buffer[i, j]);
            }
        }

        _previousBuffer = buffer;

        Console.ResetColor();
        DisplayStatusBars(timing);

        // Check for collisions and return status
        return CheckForCollision();
    }

    private int CheckForCollision()
    {
        int[] playerPos = this._player.Locate();
        foreach (X x in this._xes)
        {
            int[] xPos = x.Locate();
            if (playerPos[0] == xPos[0] && playerPos[1] == xPos[1])
            {
                return 1; // Collision detected
            }
        }
        return LookForTileCollision(); // Check for tile collisions
    }

    private ConsoleColor GetPlayerColor(float healthPercentage)
    {
        if (healthPercentage >= 0.60)
        {
            return ConsoleColor.Green;
        }
        else if (healthPercentage >= 0.30)
        {
            return ConsoleColor.Yellow;
        }
        else
        {
            return ConsoleColor.Red;
        }
    }

    private void DisplayStatusBars(TimeSpan timing)
    {
        int barLength = 15;
        int filledStamina = (int)(this._player.CheckStamina() * barLength);
        int filledHealth = (int)(this._player.GetHealth() * barLength);
        Console.SetCursorPosition(0, _rows); // Move cursor below the game area
        Console.Write("Stamina: [");
        for (int i = 0; i < barLength; i++)
        {
            Console.Write(i < filledStamina ? '#' : '-');
        }
        Console.Write("]  Health: [");
        for (int i = 0; i < barLength; i++)
        {
            Console.Write(i < filledHealth ? '#' : '-');
        }
        Console.Write($"]  Time: [{timing.Minutes:D2}:{timing.Seconds:D2}]");
    }

    private int LookForTileCollision()
    {
        int[] playerPos = this._player.Locate();
        int playerTilePosition = playerPos[0] % 30;
        int centerTileIndex = playerPos[0] / 30;
        this._center = centerTileIndex;

        List<Tuple<int, char[,]>> tileData = this._map.GetTileDataInRange(
            Math.Max(0, this._center - this._width),
            Math.Max(this._center + this._width, this._center - this._width + 2)
        );

        foreach (var data in tileData)
        {
            if (data.Item1 == centerTileIndex)
            {
                char characterAtPlayerPosition = data.Item2[playerPos[1], playerTilePosition];
                if (characterAtPlayerPosition == ' ' || 
                    characterAtPlayerPosition == '_' ||
                    characterAtPlayerPosition == '/' ||
                    characterAtPlayerPosition == '\\')
                {
                    return 0;
                }
                if (characterAtPlayerPosition == '|')
                {
                    return 2;
                }
            }
        }
        return 1;
    }

    public char[,] Snapshot()
{
    List<Tuple<int, char[,]>> tileData = this._map.GetTileDataInRange(
        Math.Max(0, this._center - this._width),
        Math.Min(this._center + this._width, this._center - this._width + 2) + 1
    );

    char[,] allTiles = new char[_rows, _totalCols];

    // Initialize allTiles with map tiles
    for (int i = 0; i < _rows; i++)
    {
        int tileIndex = 0;
        foreach (var data in tileData)
        {
            int startCol = tileIndex * 30; // Adjusted for zero-based index
            tileIndex++;

            for (int j = 0; j < 30; j++)
            {
                int consoleX = startCol + j;
                if (consoleX < _totalCols)
                {
                    allTiles[i, consoleX] = data.Item2[i, j];
                }
            }
        }
    }

    // Add X objects to the snapshot
    foreach (X x in this._xes)
    {
        int[] xPos = x.Locate();
        if (xPos[0] >= (this._center - this._width) * 30 && xPos[0] <= (this._center + this._width) * 30 + 29 &&
            xPos[1] >= 0 && xPos[1] < _rows)
        {
            int consoleX = xPos[0] - (this._center - this._width) * 30;
            allTiles[xPos[1], consoleX] = x.Show();
        }
    }

    return allTiles;
}

}
