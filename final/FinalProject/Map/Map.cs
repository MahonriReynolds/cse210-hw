
public class Map
{
    private int _scale;
    private List<Tile> _tiles;

    public Map(int scale)
    {
        this._scale = scale;
        this._tiles = [];
        this.AddTile(0, -1);
        this.AddTile(1, 0);
    }

    private void AddTile(int x, int verdure)
    {
        this._tiles.Add(new Tile(x, verdure));
    }

    public List<Tuple<int, char[,]>> GetTileDataInRange(int left, int right)
    {
        if (right == this._tiles.Count)
        {
            this.AddTile(right, right/this._scale);
        }

        if (right == -1)
        {
            right = this._tiles.Count - 1;
        }

        List<Tuple<int, char[,]>> tileData = [];
        for (int i = left; i <= right; i++)
        {
            tileData.Add(this._tiles[i].Print());
        }

        tileData.Sort((a, b) => a.Item1.CompareTo(b.Item1));

        return tileData;
    }
 }

