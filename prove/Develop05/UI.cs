
using System.ComponentModel;

public class UI
{
    public int DisplayMainMenu()
    {
        Console.Clear();
        Console.WriteLine(@"  __  __         _             __  __                     ");
        Console.WriteLine(@" |  \/  |  __ _ (_) _ __      |  \/  |  ___  _ __   _   _ ");
        Console.WriteLine(@" | |\/| | / _` || || '_ \     | |\/| | / _ \| '_ \ | | | |");
        Console.WriteLine(@" | |  | || (_| || || | | |    | |  | ||  __/| | | || |_| |");
        Console.WriteLine(@" |_|  |_| \__,_||_||_| |_|    |_|  |_| \___||_| |_| \__,_|");
        Console.WriteLine(@"                                                          ");

        string[] options = ["New Game", "Load Game", "Quit"];
        int choice = GetUIChoice(5, 8, 1, false, options, null);
        return choice;
    }

    public int DisplaySavesMenu(string[] saves)
    {
        Console.Clear();
        Console.WriteLine(@"  ____                          _       ____                              ");
        Console.WriteLine(@" / ___|   __ _ __   __ ___   __| |     / ___|  __ _  _ __ ___    ___  ___ ");
        Console.WriteLine(@" \___ \  / _` |\ \ / // _ \ / _` |    | |  _  / _` || '_ ` _ \  / _ \/ __|");
        Console.WriteLine(@"  ___) || (_| | \ V /|  __/| (_| |    | |_| || (_| || | | | | ||  __/\__ \");
        Console.WriteLine(@" |____/  \__,_|  \_/  \___| \__,_|     \____| \__,_||_| |_| |_| \___||___/");
        Console.WriteLine(@"                                                                          ");

        int choice = GetUIChoice(5, 8, 1, false, saves, null);
        return choice;
    }

    public string DisplayNewSave()
    {
        Console.Clear();
        Console.WriteLine(@"  _   _                      ____                     ");
        Console.WriteLine(@" | \ | |  ___ __      __    / ___|   __ _ __   __ ___ ");
        Console.WriteLine(@" |  \| | / _ \\ \ /\ / /    \___ \  / _` |\ \ / // _ \");
        Console.WriteLine(@" | |\  ||  __/ \ V  V /      ___) || (_| | \ V /|  __/");
        Console.WriteLine(@" |_| \_| \___|  \_/\_/      |____/  \__,_|  \_/  \___|");
        Console.WriteLine(@"                                                      ");

        string newSavePath = GetTextInput(5, 8, 1, false, ["New save name\t>"], "\n*Saves can be found in ./saves/")[0];
        return newSavePath;
    }

    public int DisplayHome(GoalRecord gr)
    {
        Console.Clear(); 
        Console.WriteLine(@"  _   _                         ");
        Console.WriteLine(@" | | | |  ___   _ __ ___    ___ ");
        Console.WriteLine(@" | |_| | / _ \ | '_ ` _ \  / _ \");
        Console.WriteLine(@" |  _  || (_) || | | | | ||  __/");
        Console.WriteLine(@" |_| |_| \___/ |_| |_| |_| \___|");
        Console.WriteLine(@"                                ");
        
        List<string> goalStrings = ["Main Menu", "New Goal"];
        goalStrings.AddRange(gr.GetGoals().Select(obj => $"{obj}"));

        int choice = GetUIChoice(5, 8, 1, false, goalStrings.ToArray(), gr.GetLvl());
        return choice-2;
    }

    public int DisplayGoal(Goal goal)
    {
        Console.Clear();
        Console.WriteLine(@"   ___          _    _                    ");
        Console.WriteLine(@"  / _ \  _ __  | |_ (_)  ___   _ __   ___ ");
        Console.WriteLine(@" | | | || '_ \ | __|| | / _ \ | '_ \ / __|");
        Console.WriteLine(@" | |_| || |_) || |_ | || (_) || | | |\__ \");
        Console.WriteLine(@"  \___/ | .__/  \__||_| \___/ |_| |_||___/");
        Console.WriteLine(@"        |_|                               ");
        
        Console.WriteLine($"\n\n{goal}");
        
        string[] goalOptions = ["Complete", "Delete"];
        int choice = GetUIChoice(5, 11, 1, true, goalOptions, null);

        return choice;
    }

    public string DisplayNewGoal()
    {

        Console.Clear();
        Console.WriteLine(@"  _   _                       ____                _ ");
        Console.WriteLine(@" | \ | |  ___ __      __     / ___|  ___    __ _ | |");
        Console.WriteLine(@" |  \| | / _ \\ \ /\ / /    | |  _  / _ \  / _` || |");
        Console.WriteLine(@" | |\  ||  __/ \ V  V /     | |_| || (_) || (_| || |");
        Console.WriteLine(@" |_| \_| \___|  \_/\_/       \____| \___/  \__,_||_|");
        Console.WriteLine(@"                                                    ");
        
        int goalType = GetUIChoice(5, 8, 1, true, ["Simple Goal", "Eternal Goal", "Checklist Goal"], null);
        List<string> goalInfoFields = [];
        List<string> newGoalInfo = [];
        switch (goalType)
        {
            case 0:
                newGoalInfo.Add("SimpleGoal");
                goalInfoFields = ["Name\t\t>", "Description\t>", "Points\t\t>"];
                break;
            case 1:
                newGoalInfo.Add("EternalGoal");
                goalInfoFields = ["Name\t\t>", "Description\t>", "Points\t\t>"];
                break;
            case 2:
                newGoalInfo.Add("ChecklistGoal");
                goalInfoFields = ["Name\t\t>", "Description\t>", "Points\t\t>", "Iterations\t\t>", "Bonus\t\t>"];
                break;
        }

        newGoalInfo.AddRange(GetTextInput(5, 8, 1, true, goalInfoFields.ToArray(), null));
        return string.Join("|", newGoalInfo);
    }

    private int GetUIChoice(int x, int y, int columns, bool canCancel, string[] options, string footerMessage)
    {
        // Found this method here: https://stackoverflow.com/questions/46908148/controlling-menu-with-the-arrow-keys-and-enter.
        // Not sure how to document that. 
        // Quite a bit was modified as well tho!

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

            if (footerMessage != null)
            {
                Console.SetCursorPosition(0, startY + options.Length / optionsPerLine + 2);
                Console.WriteLine(footerMessage);
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

    private string[] GetTextInput(int x, int y, int columns, bool canCancel, string[] prompts, string footerMessage)
    {
        const int spacingPerLine = 14;
        int startX = x;
        int startY = y;
        int promptsPerLine = columns;
        int currentPrompt = 0;

        // Initialize responses with empty strings corresponding to each prompt
        List<string> responses = new List<string>();
        for (int i = 0; i < prompts.Length; i++)
        {
            responses.Add("");
        }

        int maxLength = 50; // Assuming max length for input is 50 characters
        ConsoleKeyInfo keyInfo;

        Console.Clear();
        Console.CursorVisible = false; // Hide the cursor initially

        do
        {
            Console.Clear();

            for (int i = 0; i < prompts.Length; i++)
            {
                Console.SetCursorPosition(startX + i % promptsPerLine * spacingPerLine, startY + i / promptsPerLine);

                if (i == currentPrompt)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else
                {
                    Console.ResetColor();
                }

                Console.Write(prompts[i] + " ");
                if (!string.IsNullOrEmpty(responses[i]))
                {
                    Console.Write(responses[i]);
                }
                Console.WriteLine();
            }

            if (footerMessage != null)
            {
                Console.SetCursorPosition(0, startY + prompts.Length / promptsPerLine + 2);
                Console.WriteLine(footerMessage);
            }

            keyInfo = Console.ReadKey(intercept: true);

            switch (keyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    currentPrompt = (currentPrompt > 0) ? currentPrompt - 1 : prompts.Length - 1;
                    break;
                case ConsoleKey.DownArrow:
                    currentPrompt = (currentPrompt + 1) % prompts.Length;
                    break;
                case ConsoleKey.Enter:
                    Console.SetCursorPosition(0, startY + prompts.Length / promptsPerLine + 1);
                    Console.CursorVisible = true; // Show the cursor again before returning
                    Console.WriteLine("Responses submitted.");
                    return responses.ToArray();
                case ConsoleKey.Backspace:
                    if (!string.IsNullOrEmpty(responses[currentPrompt]))
                    {
                        responses[currentPrompt] = responses[currentPrompt].Remove(responses[currentPrompt].Length - 1);
                    }
                    break;
                case ConsoleKey.Escape:
                    if (canCancel)
                    {
                        Console.CursorVisible = true; // Show the cursor again before returning
                        return null; // Indicate cancellation
                    }
                    break;
                default:
                    // Handle alphanumeric keys and space
                    if ((char.IsLetterOrDigit(keyInfo.KeyChar) || keyInfo.KeyChar == ' ') && responses[currentPrompt].Length < maxLength)
                    {
                        responses[currentPrompt] += keyInfo.KeyChar.ToString().ToLower();
                    }
                    break;
            }

        } while (true);
    }




}
