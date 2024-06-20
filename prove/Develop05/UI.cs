
public class UI
{
    public int DisplayMainMenu()
    {
        Console.Clear();
        Console.WriteLine("  __  __         _             __  __                          ");
        Console.WriteLine(" |  \\/  |  __ _ (_) _ __      |  \\/  |  ___  _ __   _   _    ");
        Console.WriteLine(" | |\\/| | / _` || || '_ \\     | |\\/| | / _ \\| '_ \\ | | | |");
        Console.WriteLine(" | |  | || (_| || || | | |    | |  | ||  __/| | | || |_| |     ");
        Console.WriteLine(" |_|  |_| \\__,_||_||_| |_|    |_|  |_| \\___||_| |_| \\__,_|  ");
        Console.WriteLine("                                                               ");

        string[] options = ["New Game", "Load Game", "Quit"];
        int choice = GetUIChoice(5, 8, 1, false, options);
        return choice;
    }

    public int DisplaySavesMenu(string[] saves)
    {
        Console.Clear();
        Console.WriteLine("  ____                          _       ____                                     ");
        Console.WriteLine(" / ___|   __ _ __   __ ___   __| |     / ___|  __ _  _ __ ___    ___  ___        ");
        Console.WriteLine(" \\___ \\  / _` |\\ \\ / // _ \\ / _` |    | |  _  / _` || '_ ` _ \\  / _ \\/ __|");
        Console.WriteLine("  ___) || (_| | \\ V /|  __/| (_| |    | |_| || (_| || | | | | ||  __/\\__ \\    ");
        Console.WriteLine(" |____/  \\__,_|  \\_/  \\___| \\__,_|     \\____| \\__,_||_| |_| |_| \\___||___/");
        Console.WriteLine("                                                                                 ");

        int choice = GetUIChoice(5, 8, 1, false, saves);
        return choice;
    }

    public int DisplayHome(List<Goal> goals)
    {
        Console.Clear(); 
        Console.WriteLine("  _   _                            ");
        Console.WriteLine(" | | | |  ___   _ __ ___    ___    ");
        Console.WriteLine(" | |_| | / _ \\ | '_ ` _ \\  / _ \\");
        Console.WriteLine(" |  _  || (_) || | | | | ||  __/   ");
        Console.WriteLine(" |_| |_| \\___/ |_| |_| |_| \\___| ");
        Console.WriteLine("                                   ");
        
        string[] goalStrings = goals.Select(obj => $"{obj}").ToArray();
        int choice = GetUIChoice(5, 8, 1, false, goalStrings);
        return 0;
    }




    private int GetUIChoice(int x, int y, int columns, bool canCancel, string[] options)
    {
        // Found this method here: https://stackoverflow.com/questions/46908148/controlling-menu-with-the-arrow-keys-and-enter.
        // Not sure how to document that. 

        const int spacingPerLine = 14;

        int startX = x;
        int startY = y;
        int optionsPerLine = columns;
        
        int currentSelection = 0;

        ConsoleKey key;

        Console.CursorVisible = false;

        do
        {
            for (int i = 0; i < options.Length; i++)
            {
                Console.SetCursorPosition(startX + i % optionsPerLine * spacingPerLine, startY + i / optionsPerLine);

                if (i == currentSelection)
                    Console.ForegroundColor = ConsoleColor.Green;

                Console.Write(options[i]);

                Console.ResetColor();
            }

            key = Console.ReadKey(true).Key;

            switch (key)
            {
                case ConsoleKey.LeftArrow:
                    if (currentSelection % optionsPerLine > 0)
                        currentSelection--;
                    break;
                case ConsoleKey.RightArrow:
                    if (currentSelection % optionsPerLine < optionsPerLine - 1)
                        currentSelection++;
                    break;
                case ConsoleKey.UpArrow:
                    if (currentSelection >= optionsPerLine)
                        currentSelection -= optionsPerLine;
                    break;
                case ConsoleKey.DownArrow:
                    if (currentSelection + optionsPerLine < options.Length)
                        currentSelection += optionsPerLine;
                    break;
                case ConsoleKey.Escape:
                    if (canCancel)
                        return -1;
                    break;
            }

            Console.SetCursorPosition(0, startY + options.Length / optionsPerLine + 1);
        } while (key != ConsoleKey.Enter);

        Console.CursorVisible = true;

        return currentSelection;
    }
}
