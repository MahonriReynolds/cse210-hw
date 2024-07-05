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
        this.AddTile(2, 0);
        this.AddTile(3, 0);
        this.AddTile(4, 0);
    }

    private void AddTile(int x, int verdure)
    {
        this._tiles.Add(new Tile(x, verdure));
    }

    public int GetTileCount()
    {
        return this._tiles.Count;
    }

    public List<Tuple<int, char[,]>> GetTileDataInRange(int left, int right)
    {
        if (right == -1)
        {
            right = this._tiles.Count - 1;
        }
        else if (right >= this._tiles.Count)
        {
            this.AddTile(right, right / this._scale);
        }

        List<Tuple<int, char[,]>> tileData = new List<Tuple<int, char[,]>>();
        for (int i = left; i <= right && i < this._tiles.Count; i++)
        {
            tileData.Add(this._tiles[i].Print());
        }

        tileData.Sort((a, b) => a.Item1.CompareTo(b.Item1));

        return tileData;
    }
}
