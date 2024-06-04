


public class MathAssignment : Assignment
{
    private string _textbookSection;
    private string _problems;

    public MathAssignment(string name, string topic, string textbookSection, string problems) 
    : base(name, topic)
    {
        this._textbookSection = textbookSection;
        this._problems = problems;
    }

    public string GetHomeworkList()
    {
        return $"{this._textbookSection} {this._problems}";
    }
}