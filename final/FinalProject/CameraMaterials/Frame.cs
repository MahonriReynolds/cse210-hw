

public class Frame
{
    private char[,] _contentArray;

    public Frame(int width, int height)
    {
        this._contentArray = new char[width, height];
    }

    public void UpdateCell(int x, int y, char content)
    {
        this._contentArray[x, y] = content;
    }

    public void Fill(char[,] fillContent)
    {
        this._contentArray = fillContent;
    }

    public char[,] GetContent()
    {
        return this._contentArray;
    }
}

