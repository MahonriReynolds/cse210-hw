
using Newtonsoft.Json;
public class Journal 
{
    public string _journalTitle = "";
    public List<Entry> _currentEntries = [];

    [JsonIgnore]
    public string _storagePath;

    public Journal()
    {

    }

    public void LoadJournal()
    {

        try
        {
            Journal handover = JsonConvert.DeserializeObject<Journal>(File.ReadAllText(this._storagePath));
            this._journalTitle = handover._journalTitle;
            this._currentEntries = handover._currentEntries;
        }
        catch (FileNotFoundException)
        {
            
        }
        
         
    }

    public void SaveJournal()
    {
        File.WriteAllText(this._storagePath, JsonConvert.SerializeObject(this, Formatting.Indented));
    }

    public void NewJournal()
    {
        try 
        {
            Directory.CreateDirectory(Path.GetDirectoryName(this._storagePath));
        }
        catch (ArgumentException)
        {
            File.Create(this._storagePath).Close();
        }
    }

    public string ConvertToString(bool numbered = false)
    {
        string output = "\n\n~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~";
        output += $"\n--{this._journalTitle}--";

        if (this._currentEntries?.Any() != true)
        {
            output += "\n\n*Empty*";
            output += "\n~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~\n\n";
            return output;
        }

        if (!numbered)
        {
            foreach (Entry e in this._currentEntries)
            {
                output += $"\n\n{e.ConvertToString()}";
            }
        }
        else
        {
            foreach (Entry e in this._currentEntries)
            {
                output += $"\n\n{_currentEntries.IndexOf(e)}) {e.ConvertToString()}";
            }
        }

        output += "\n~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~\n\n";
        return output;
    }

    public void AddEntry(Entry currentEntry)
    {
        this._currentEntries.Add(currentEntry);
    }

    public void RemoveEntry(int entryIndex)
    {
        if(this._currentEntries.Count > entryIndex)
        {
            this._currentEntries.RemoveAt(entryIndex);
        }
        
    }

}