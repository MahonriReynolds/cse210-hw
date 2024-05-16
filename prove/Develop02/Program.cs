
/*
For that last sweet sweet 7%:

- Added several new prompts
    - New Journal : Create a new journal without loading it into the working journal.
    - Remove Entry : Remove entries from currently loaded journal.
    - Add Prompt : Permanently add a prompt to the prompt list.
    - Remove Prompt : Permanently remove a prompt from the prompt list.

- Used JSON for persistent storage (Ended up using Json.NET (Newtonsoft))
    - All journals are saved in JSON formatted files (with or without .json extension)
    - Prompts are saved in prompts.json
*/

class Program
{
    static void Main(string[] args)
    {
        // Display startup message.
        Console.WriteLine("\nStarting Journal Program");

        // Make general journal and prompt manager objects to be used by program.
        Journal workingJournal = new();
        PromptManager promptManager = new()
        {
            _storagePath = "prompts.json"
        };
        promptManager.PopulatePrompts();

        // Set user's choice as non-usable value to start loop.
        int user_choice = -1;
        while (user_choice != 8)
        {
            // Display Menu.
            Console.WriteLine("\nMain Menu");
            Console.WriteLine(".....................");
            Console.WriteLine("| 0. New Journal    |");
            Console.WriteLine("| 1. Load Journal   |");
            Console.WriteLine("| 2. Save Journal   |");
            Console.WriteLine("| 3. Display Journal|");
            Console.WriteLine("| 4. Write Entry    |");
            Console.WriteLine("| 5. Remove Entry   |");
            Console.WriteLine("| 6. Add Prompt     |");
            Console.WriteLine("| 7. Remove Prompt  |");
            Console.WriteLine("| 8. Quit           |");
            Console.WriteLine(".....................");

            // Get int choice from user.
            do 
            {
                Console.Write("\nOption > "); 
            } while (!int.TryParse(Console.ReadLine(), out user_choice));

            switch (user_choice)
            {
                // new journal
                case 0:
                    Console.Write("\nNew journal path > ");
                    workingJournal._storagePath = Console.ReadLine();
                    Console.Write("New journal title > ");
                    workingJournal._journalTitle = Console.ReadLine();
                    workingJournal.NewJournal();
                    Console.WriteLine("New journal created!");
                    break;

                // load journal
                case 1:
                    Console.Write("\nJournal path > ");
                    workingJournal._storagePath = Console.ReadLine();
                    workingJournal.LoadJournal();
                    if (string.IsNullOrEmpty(workingJournal._journalTitle))
                    {
                        Console.WriteLine("No journal found!");
                    }
                    else
                    {
                        Console.WriteLine("Journal loaded!");
                    }
                    break;

                // save journal
                case 2:
                    if (string.IsNullOrEmpty(workingJournal._storagePath))
                    {
                        Console.Write("\nNew journal path > ");
                        workingJournal._storagePath = Console.ReadLine();
                        workingJournal.NewJournal();
                    }
                    if (string.IsNullOrEmpty(workingJournal._journalTitle))
                    {
                        Console.Write("\nNew journal title > ");
                        workingJournal._journalTitle = Console.ReadLine();
                    }
                    workingJournal.SaveJournal();
                    Console.WriteLine("Journal saved!");
                    break;

                // display journal
                case 3:
                    Console.WriteLine(workingJournal.ConvertToString());
                    break;

                // write entry
                case 4:
                    Console.WriteLine("\nNew entry >");

                    string workingPrompt = promptManager.GetPrompt();
                    string workingTime = DateTime.Now.ToShortDateString();
                    Console.WriteLine(workingPrompt);
                    Console.Write("> ");
                    string workingResponse = Console.ReadLine();

                    // Make new entry object and use its init / write method.
                    Entry workingEntry = new();
                    workingEntry.WriteEntry(workingTime, workingPrompt, workingResponse);
                    workingJournal.AddEntry(workingEntry);
                    Console.WriteLine("Entry written!");
                    break;

                // remove entry
                case 5:
                    Console.WriteLine(workingJournal.ConvertToString(numbered:true));
                    int entryToRemove;
                    do 
                    {
                        Console.Write("\nEntry to remove > "); 
                    } while (!int.TryParse(Console.ReadLine(), out entryToRemove));
                    workingJournal.RemoveEntry(entryToRemove);
                    if (workingJournal._currentEntries.Count > entryToRemove)
                    {
                        Console.WriteLine("Entry removed!");
                    }
                    else
                    {
                        Console.WriteLine("No entries removed!");
                    }
                    break;
                
                // add prompt
                case 6:
                    Console.Write("\nNew prompt > ");
                    string promptToAdd = Console.ReadLine();
                    promptManager.AddPrompt(promptToAdd);
                    Console.WriteLine("Prompt added!");
                    break;
                
                // remove prompt
                case 7:
                    Console.WriteLine(promptManager.ConvertToString());
                    int promptToRemove;
                    do 
                    {
                        Console.Write("\nPrompt to remove > "); 
                    } while (!int.TryParse(Console.ReadLine(), out promptToRemove));
                    promptManager.RemovePrompt(promptToRemove);
                    if (promptManager._currentPrompts.Count > promptToRemove)
                    {
                        Console.WriteLine("Prompt removed!");
                    }
                    else
                    {
                        Console.WriteLine("No prompts removed!");
                    }
                    break;

                // just so 8 (quit) doesn't print out invalid option
                case 8:
                    break;

                // altert if option not in menu
                default:
                {
                    Console.WriteLine("Invalid Option");
                    break;
                }
            }
        }
    }
}


