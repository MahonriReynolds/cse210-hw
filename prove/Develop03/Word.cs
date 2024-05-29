

class Word
{
    private bool _hidden;
    private List<char> _content;

    // Word object is built off a string input, so accept 
    // a single string argument to construct.
    public Word(string content)
    {
        this._hidden = false; 
        this._content = content.ToList();
    }

    // Try to hide this object. If already hidden, return 
    // false for failed to hide. If this object was 
    // successfully hidden, return true.
    public bool TryHide()
    {
        if (!this._hidden)
        {
            this._hidden = true;
            return true;
        }
        
        return false;
    }

    // Try to unhide this object. If already not hidden, 
    // return false for failed to unhide. If this object 
    // was successfully unhid, return true.
    public bool TryUnhide()
    {
        if (this._hidden)
        {
            this._hidden = false;
            return true;
        }
        
        return false;
    }

    // Return this word object as a string. If not hidden, 
    // just return this object's content concatenated into 
    // a string. If hidden, then replace every character 
    // (that isn't punctuation) with an underscore. 
    public string Spaghettify()
    {
        if (!this._hidden)
        {
            return String.Concat(this._content);
        }

        string output = "";
        foreach (char c in this._content)
        {
            if (".?!:;\"\'-(),".Contains(c))
            {
                output += c;
            }
            else
            {
                output += "_";
            }
        }
        
        return output;      
    }
}


