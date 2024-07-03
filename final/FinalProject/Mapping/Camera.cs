
public class Camera
{
    private int _width;
    private double _center;

    private Map _map;
    private Player _player;

    public Camera(int width, Map map, Player player)
    {
        Console.CursorVisible = false;

        this._width = width;
        this._center = 0;

        this._map = map;
        this._player = player;
    }

    public void Display()
{
    Console.Clear();

    // Calculate the active tile based on the player's position
    int playerPos = this._player.Locate();

    // Calculate the active tile index
    this._center = playerPos / 30;

    List<Tuple<int, char[,]>> tileData = this._map.GetTileDataInRange(
        (int)(this._center - this._width < 0 ? 0 : this._center - this._width),
        Math.Max((int)(this._center - this._width < 0 ? 0 : this._center - this._width) + 2, (int)(this._center + this._width))
    );

    int rows = tileData[0].Item2.GetLength(0);
    int cols = tileData[0].Item2.GetLength(1);

    // Calculate the player's position within the current tile
    int playerTilePosition = playerPos % 30;

    // Loop through rows of the tiles
    for (int i = 0; i < rows; i++)
    {
        // Loop through each tile in tileData
        foreach (Tuple<int, char[,]> data in tileData)
        {
            // Calculate the starting position in the console window for each tile
            int consoleStartX = data.Item1 * 30;

            // Loop through columns of the tiles
            for (int j = 0; j < cols; j++)
            {
                int consoleX = consoleStartX + j;

                if (data.Item1 == this._center && i == 26 && j == playerTilePosition)
                {
                    // Print player's representation
                    Console.Write(this._player.Show());
                }
                else
                {
                    // Print tile data
                    Console.Write(data.Item2[i, j]);
                }
            }
        }

        Console.WriteLine();
    }
}


}

