

public class Menu
{
    private string _title;
    private string[] _options;

    public Menu(string title, string[] options)
    {
        this._title = title;
        this._options = options;
    }

    public virtual void Display()
    {
        Console.Clear();
        Console.WriteLine(this._title);

        GetChoice();
    }

    private int GetChoice()
    {
        int selection = 0;

        ConsoleKey key;
        Console.CursorVisible = false;

        do
        {
            for (int i = 0; i < this._options.Length; i++)
            {
                Console.SetCursorPosition(5, 8 + i);

                if (i == selection)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"\t> {this._options[i]}");
                }
                else
                {
                    Console.ResetColor();
                    Console.Write($"\t {this._options[i]} ");
                }
            }

            Console.ResetColor();
            Console.WriteLine("\n\n\tΛ V to navigate\n\tEnter to select");

            key = Console.ReadKey(true).Key;
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    if (selection > 0)
                        selection -= 1;
                    break;
                case ConsoleKey.DownArrow:
                    if (selection < this._options.Length - 1)
                        selection += 1;
                    break;
            }
        } while (key != ConsoleKey.Enter);

        Console.CursorVisible = true;
        Console.ResetColor();
        return selection;
    }
}


class Program
{
    static void Main()
    {
        Menu m1 = new Menu("testing", ["1", "2", "3"]);
        m1.Display();
    }
}
