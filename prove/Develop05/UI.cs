
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
        int choice = GetChoice(5, 8, options, "Λ V to navigate\nEnter to select");
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

        int choice = GetChoice(5, 8, saves.Select(Path.GetFileNameWithoutExtension).ToArray(), "Λ V to navigate\nEnter to select\n\n* Saves can be found in ./saves/");
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

        string newSavePath = GetInput(5, 8, ["New save name\t>"], "Enter to submit form\n\n* Saves can be found in ./saves/")[0];
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

        int choice = GetChoice(5, 8, goalStrings.ToArray(), $"{gr.GetLvl()}\n\nΛ V to navigate\nEnter to select");
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
        int choice = GetChoice(5, 11, goalOptions, "Λ V to navigate\nEnter to select");

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
        
        int goalType = GetChoice(5, 8, ["Simple Goal", "Eternal Goal", "Checklist Goal"], "Λ V to navigate\nEnter to select");
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

        do
        {
            newGoalInfo = newGoalInfo[0..1];
            newGoalInfo.AddRange(GetInput(5, 8, goalInfoFields.ToArray(), "Λ V to navigate form\nEnter to submit form"));
            if (goalType == 2)
            {
                newGoalInfo.Add("0");
            }

        }while (!ValidateGoalArray(newGoalInfo.ToArray()));

        return string.Join("|", newGoalInfo);
    }

    private int GetChoice(int x, int y, string[] options, string footerMessage=null)
    {
        // Found this method here: https://stackoverflow.com/questions/46908148/controlling-menu-with-the-arrow-keys-and-enter.
        // Not sure how to document that. 
        // Quite a bit was modified as well tho!

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

    private string[] GetInput(int x, int y, string[] prompts, string footerMessage=null)
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

            if (footerMessage != null)
            {
                Console.SetCursorPosition(0, startY + prompts.Length + 1);
                Console.WriteLine(footerMessage);
            }

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

    private bool ValidateGoalArray(string[] goalAray)
    {
        for (int i = 3; i < goalAray.Length; i++)
        {
            if (!int.TryParse(goalAray[i], out _))
            {
                return false;
            }
        }
        return true;
    }
}
