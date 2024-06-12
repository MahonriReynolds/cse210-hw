

public class Prompt
{
    private string _content;
    private bool _used;

    public Prompt(string content)
    {
        this._content = content;
        this._used = false;
    }

    public string TryUse()
    {
        if (this._used)
        {
            // return false for can't use
            return "";
        }
        // return true for can use
        this._used = true;
        return this._content;
    }

    public void MakeAvailable()
    {
        this._used = false;
    }
}


