


public class Map:MapMaker
{
    private Dictionary<(int, int), char> _mapContent;

    public Map(int seed, int genWidth, int genHeight)
    : base (seed)
    {
        this._mapContent = new Dictionary<(int, int), char>();
        int startX = -(genWidth / 2);
        int startY = -(genHeight / 2);

        for (int x = 0; x < genWidth; x++)
        {
            int mapX = startX + x;
            for (int y = 0; y < genHeight; y++)
            {
                int mapY = startY + y;
                this._mapContent[(mapX, mapY)] = MakeCell(mapX, mapY);
            }
        }
    }

    public void Extend(int[] center, int width, int height, int[] step)
    {
        int startX = center[0] - width / 2;
        int startY = center[1] - height / 2;

        int stepX = step[0];
        int stepY = step[1];

        if (Math.Abs(stepX) == 1)
        {
            int mapX = startX + (stepX == 1 ? width - 1 : 0);

            for (int y = 0; y < height; y++)
            {
                int mapY = startY + y;
                this._mapContent[(mapX, mapY)] = MakeCell(mapX, mapY);
            }
        }

        else if (Math.Abs(stepY) == 1)
        {
            int mapY = startY + (stepY == 1 ? height - 1 : 0);

            for (int x = 0; x < width; x++)
            {
                int mapX = startX + x;
                this._mapContent[(mapX, mapY)] = MakeCell(mapX, mapY);
            }
        }
    }

    public char[,] GetSelection(int[] center, int width, int height)
    {
        char[,] selection = new char[width, height];
        int startX = center[0] - width / 2;
        int startY = center[1] - height / 2;

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                int mapX = startX + x;
                int mapY = startY + y;
                selection[x, y] = this._mapContent[(mapX, mapY)];
            }
        }
        
        return selection;
    }
}


