

class Scripture
{
    private Reference _reference;
    private List<Word> _content;
    private List<Word> _scrambledContent;

    // Only allow this object to be created with both a reference 
    // and a string to be chopped up into the content. While making 
    // the object's content, also generate a scrambled version of 
    // it to be used in the hide/unhide methods.
    public Scripture(Reference reference, string content)
    {
        this._reference = reference;

        this._content= [];
        this._scrambledContent= [];
        foreach (string w in content.Split(' '))
        {
            Word newWord = new Word(w);
            this._content.Add(newWord);
            this._scrambledContent.Add(newWord);
        }

        Random random = new Random();
        int n = this._scrambledContent.Count;
        while (n > 1)
        {
            n--;
            int k = random.Next(n + 1);
            (this._scrambledContent[n], this._scrambledContent[k]) 
                = (this._scrambledContent[k], this._scrambledContent[n]);
        }
    }

    // Using the scrambled version of the object's contents, step
    // through and hide the next Word object that isn't already
    // hidden. Only hide three words at a time and return false if
    // no words were left to hide. If at least 1 more word was
    // hidden, return true.
    public bool TryHideRandom()
    { 
        int hidden = 0;
        for (int i = 0; i < this._scrambledContent.Count; i++)
        {
            if (hidden < 3 && this._scrambledContent[i].TryHide())
            {
                hidden++;
            }

        }

        if (hidden > 0)
        {
            return true;
        }
        return false;
    }

    // Using the scrambled version of the object's contents, step
    // through backwards and unhide the first three next Word objects 
    // that are already hidden. Only unhide  max of three words at a
    // time and don't return anything regardless of the outcome.
    public void UndoLastHide()
    {
        int unhid = 0;
        for (int i = this._scrambledContent.Count - 1; i >= 0; i--)
        {
            if (unhid < 3 && this._scrambledContent[i].TryUnhide())
            {
                unhid++;
            }
        }
    }

    // Return this Scripture object as a string by making a string 
    // variable with the object's Reference. Then loop through the 
    // properly ordered contents and add each to the end of the output 
    // string.
    public string Spaghettify()
    {
        string output = $"{this._reference.Spaghettify()}";
        foreach (Word word in this._content)
        {
            output += $" {word.Spaghettify()}";
        }

        return output;
    }
}



