
public class Entry
{
    public string _date;
    public string _prompt; 
    public string _response;

    public void WriteEntry(string date, string prompt, string response)
    {
        _date = date;
        _prompt = prompt;
        _response = response;
    }

    public string ConvertToString()
    {
        return $"-{_date}-\n{_prompt}:\n{_response}";
    }

}

