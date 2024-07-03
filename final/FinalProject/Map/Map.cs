
public class Map
{
    private List<Tile> _tiles;

    public Map()
    {
        this._tiles = [];
        for (int i = 0; i < 10; i++)
        {
            this.AddTile(i, i);
        }
    }

    private void AddTile(int x, int verdure)
    {
        this._tiles.Add(new Tile(x, verdure));
    }

    public List<Tuple<int, char[,]>> GetTileDataInRange(int left, int right)
    {
        if (right == this._tiles.Count)
        {
            this.AddTile(right, right);
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

