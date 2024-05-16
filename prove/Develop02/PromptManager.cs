
using Newtonsoft.Json;
public class PromptManager
{
    public List<string> _currentPrompts;

    [JsonIgnore]
    public string _storagePath;

    public PromptManager()
    {
        
    }

    public void PopulatePrompts()
    {
        PromptManager handover = JsonConvert.DeserializeObject<PromptManager>(File.ReadAllText(this._storagePath));
        this._currentPrompts = handover._currentPrompts;
    }

    public string GetPrompt()
    {
        Random rndm = new();
        int promptIndex = rndm.Next(_currentPrompts.Count);
        return _currentPrompts[promptIndex];
    }

    public void SavePrompts()
    {
        File.WriteAllText(this._storagePath, JsonConvert.SerializeObject(this, Formatting.Indented));
    }

    public string ConvertToString()
    {
        string output = "";
        foreach (string p in this._currentPrompts)
        {
            output += $"\n{_currentPrompts.IndexOf(p)}) {p}";
        }
        return output;
    }

    public void AddPrompt(string prompt)
    {
        this._currentPrompts.Add(prompt);
        SavePrompts();
    }

    public void RemovePrompt(int promptIndex)
    {
        if(this._currentPrompts.Count > promptIndex)
        {
            this._currentPrompts.RemoveAt(promptIndex);
            SavePrompts();
        } 
    }
}



