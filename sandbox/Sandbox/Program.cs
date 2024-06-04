using System;


public class Test
{
    private string _text;

    public Test(string text)
    {
        this._text = text;
    }

    public string get_text()
    {
        return this._text;
    }
}


public class Tester : Test
{
    private int _number;

    public Tester(string text, int number) : base(text)
    {
      this._number = number;
    }

    public int get_number()
    {
        return this._number;
    }

    public string get_both()
    {
        return $"{base.get_text()} - {this._number}";
    }
}





class Program
{
    static void Main(string[] args)
    {
        Tester tester = new Tester("testing text", 1);

        Console.WriteLine(tester.get_text());
        Console.WriteLine(tester.get_number());
        Console.WriteLine(tester.get_both());
    }
}