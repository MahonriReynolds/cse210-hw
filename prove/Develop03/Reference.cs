

class Reference
{
    private string _book;
    private int _chapter;
    private int _start;
    private int _end;

    // Allow reference to be made with 'Proverbs 3:5' format.
    public Reference(string book, int chapter, int verse)
    {
        this._book = book;
        this._chapter = chapter;
        this._start = verse;
        this._end = 0;
    }

    // Allow reference to be made with 'Proverbs 3:5-6' format.
    public Reference(string book, int chapter, int start, int end)
    {
        this._book = book;
        this._chapter = chapter;
        this._start = start;
        this._end = end;
    }

    // Depending on what format was supplied to the constructor, 
    // string together the reference to match.
    public string Spaghettify()
    {
        if (this._end != 0)
        {
            return $"{this._book} {this._chapter}:{this._start}-{this._end}";
        }
        
        return $"{this._book} {this._chapter}:{this._start}";
    }
}


