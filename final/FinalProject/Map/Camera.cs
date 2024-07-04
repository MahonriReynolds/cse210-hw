
public class Camera
{
    private int _width;
    private double _center;

    private Map _map;
    private Player _player;

    public Camera(int width, Map map, Player player)
    {
        this._width = width;
        this._center = 0;

        this._map = map;
        this._player = player;
    }

    public void Display(TimeSpan timing, char playerModel=' ')
    {
        if (playerModel == ' ')
        {
            playerModel = this._player.Show();
        }

        Console.Clear();
        Console.CursorVisible = false;

        int[] playerPos = this._player.Locate();
        this._center = playerPos[0] / 30;

        List<Tuple<int, char[,]>> tileData = this._map.GetTileDataInRange(
            (int)(this._center - this._width < 0 ? 0 : this._center - this._width),
            Math.Max((int)(this._center - this._width < 0 ? 0 : this._center - this._width) + 2, (int)(this._center + this._width))
        );

        int rows = tileData[0].Item2.GetLength(0);
        int cols = tileData[0].Item2.GetLength(1);

        int playerTilePosition = playerPos[0] % 30;
        for (int i = 0; i < rows; i++)
        {
            foreach (Tuple<int, char[,]> data in tileData)
            {
                int consoleStartX = data.Item1 * 30;
                for (int j = 0; j < cols; j++)
                {
                    int consoleX = consoleStartX + j;

                    if (data.Item1 == this._center && i == playerPos[1] && j == playerTilePosition)
                    {
                        float healthPercentage = this._player.GetHealth();
                        ConsoleColor color;
                        if (healthPercentage >= 0.60)
                        {
                            color = ConsoleColor.Green;
                        }
                        else if (healthPercentage >= 0.30)
                        {
                            color = ConsoleColor.Yellow;
                        }
                        else
                        {
                            color = ConsoleColor.Red;
                        }

                        Console.ForegroundColor = color;
                        Console.Write(playerModel);
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write(data.Item2[i, j]);
                    }
                }
            }
            Console.WriteLine();    
        }

        int barLength = 15;
        int filledStamina = (int)(this._player.CheckStamina() * barLength);
        int filledHealth = (int)(this._player.GetHealth() * barLength);
        Console.Write("Stamina: [");
        for (int i = 0; i < barLength; i++)
        {
            if (i < filledStamina)
            {
                Console.Write('#');
            }
            else
            {
                Console.Write('-');
            }
        }
        Console.Write("]  Health: [");
        for (int i = 0; i < barLength; i++)
        {
            if (i < filledHealth)
            {
                Console.Write('#');
            }
            else
            {
                Console.Write('-');
            }
        }
        Console.Write($"]  Time: [{timing.Minutes:D2}:{timing.Seconds:D2}]");
    }

    public int LookForCollision()
    {
        int[] playerPos = this._player.Locate();
        int playerTilePosition = playerPos[0] % 30;
        int centerTileIndex = playerPos[0] / 30;
        this._center = centerTileIndex;

        List<Tuple<int, char[,]>> tileData = this._map.GetTileDataInRange(
            (int)(this._center - this._width < 0 ? 0 : this._center - this._width),
            Math.Max((int)(this._center - this._width < 0 ? 0 : this._center - this._width) + 2, (int)(this._center + this._width))
        );

        foreach (var data in tileData)
        {
            if (data.Item1 == centerTileIndex)
            {
                char characterAtPlayerPosition = data.Item2[playerPos[1], playerTilePosition];
                if (characterAtPlayerPosition == ' ' || characterAtPlayerPosition == '_')
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
        List<Tuple<int, char[,]>> tileData = this._map.GetTileDataInRange(0, -1);

        int rows = tileData[0].Item2.GetLength(0);
        int cols = tileData[0].Item2.GetLength(1);

        char[,] allTiles = new char[rows, cols * tileData.Count];

        for (int i = 0; i < rows; i++)
        {
            for (int t = 0; t < tileData.Count; t++)
            {
                Tuple<int, char[,]> data = tileData[t];
                char[,] tile = data.Item2;

                int startCol = t * cols;

                for (int j = 0; j < cols; j++)
                {
                    allTiles[i, startCol + j] = tile[i, j];
                }
            }
        }
        return allTiles;
    }
}

