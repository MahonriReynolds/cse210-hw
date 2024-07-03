

public abstract class Menu
{
    protected int GetChoice(int x, int y, string[] options, string footerMessage=null)
    {
        //https://stackoverflow.com/questions/46908148/controlling-menu-with-the-arrow-keys-and-enter.
        int startX = x;
        int startY = y;
        int selection = 0;

        ConsoleKey key;
        Console.CursorVisible = false;

        do
        {
            for (int i = 0; i < options.Length; i++)
            {
                Console.SetCursorPosition(startX, startY + i);

                if (i == selection)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"> {options[i]}");
                }
                else
                {
                    Console.ResetColor();
                    Console.Write($"{options[i]}  ");
                }
            }

            Console.ResetColor();
            if (footerMessage != null)
            {
                Console.SetCursorPosition(0, startY + options.Length + 1);
                Console.WriteLine(footerMessage);
            }

            key = Console.ReadKey(true).Key;

            switch (key)
            {
                case ConsoleKey.UpArrow:
                    if (selection > 0)
                        selection -= 1;
                    break;
                case ConsoleKey.DownArrow:
                    if (selection < options.Length - 1)
                        selection += 1;
                    break;
            }

            // Console.SetCursorPosition(0, startY + options.Length / 2);
        } while (key != ConsoleKey.Enter);

        Console.CursorVisible = true;
        Console.ResetColor();

        return selection;
    }

    protected int GetMovement()
    {
        return 0;
    }
}

