

public abstract class Interface
{
    protected string _header;
    protected string[] _options;

    public Interface(string header, string[] options)
    {
        this._header = header;
        this._options = options;
    }

    private int GetChoice(int x, int y)
    {
        //https://stackoverflow.com/questions/46908148/controlling-menu-with-the-arrow-keys-and-enter.
        int startX = x;
        int startY = y;
        int selection = 0;

        ConsoleKey key;
        Console.CursorVisible = false;

        do
        {
            for (int i = 0; i < this._options.Length; i++)
            {
                Console.SetCursorPosition(startX, startY + i);

                if (i == selection)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"> {this._options[i]}");
                }
                else
                {
                    Console.ResetColor();
                    Console.Write($"{this._options[i]}  ");
                }
            }

            Console.ResetColor();
            Console.SetCursorPosition(0, startY + this._options.Length + 1);
            Console.WriteLine("Λ V to navigate\nEnter to select");

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

    protected string[] GetInput(int x, int y, string[] prompts)
    {
        int startX = x;
        int startY = y;
        int field = 0;

        string[] responses = new string[prompts.Length];

        ConsoleKeyInfo key;
        Console.CursorVisible = false;

        do
        {
            Console.Clear();
            for (int i = 0; i < prompts.Length; i++)
            {
                Console.SetCursorPosition(startX, startY + i);

                if (i == field)
                    Console.ForegroundColor = ConsoleColor.Green;
                
                Console.Write(prompts[i] + " ");

                if (!string.IsNullOrEmpty(responses[i]))
                {
                    Console.Write(responses[i]);
                }

                Console.ResetColor();
            }

            Console.ResetColor();
            Console.SetCursorPosition(0, startY + prompts.Length + 1);
            Console.WriteLine("\n\nΛ V to navigate\nEnter to submit");

            key = Console.ReadKey(intercept: true);

            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    if (field > 0)
                    {
                        field -= 1;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (field < prompts.Length - 1)
                    {
                        field += 1;
                    }
                    break;
                case ConsoleKey.Backspace:
                    if (!string.IsNullOrEmpty(responses[field]))
                    {
                        responses[field] = responses[field][..^1];
                    }
                    break;
                default:
                    responses[field] += key.KeyChar;
                    break;
            }
        } while (key.Key != ConsoleKey.Enter);

        Console.CursorVisible = true;
        Console.ResetColor();
        return responses;
    }

    public virtual int Display()
    {
        Console.Clear();
        Console.WriteLine(this._header);
        return this.GetChoice(5, 8);
    }
}

