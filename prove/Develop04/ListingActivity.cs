




public class ListingActivity : Activity
{
    private List<string> _notebookLines;

    public ListingActivity()
    : base(
        "Listing Activity", 
        "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.", 
        [   
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        ]
        )
    {
        this._notebookLines = [];
    }


    private void DisplayNotebook(string mainPrompt)
    {
        string pageTop = "  _____________________________________________________________ ";
        string lineSpacer = "|                                                             |";
        string linePrompt = $"=| {mainPrompt.PadRight((lineSpacer.Length - 3))}|";
        string pageBtm = " |_____________________________________________________________|";

        Console.Clear();

            
        Console.WriteLine(pageTop);
        Console.WriteLine($" {lineSpacer}");
        Console.WriteLine(linePrompt);
        Console.WriteLine($" {lineSpacer}");

        bool shwBnd = true;
        for (int i = 0; i < this._notebookLines.Count; i++)
        {
            if (shwBnd)
            {
                Console.Write($"=");
            }
            else
            {
                Console.Write($" ");
            }
            shwBnd = !shwBnd;
            Console.Write($"|    {i+1}. ");

            string content = this._notebookLines[i];
            if (i < 9)
            {
                Console.WriteLine($"{content.PadRight(lineSpacer.Length - 9)}|");
            }
            else
            {
                Console.WriteLine($"{content.PadRight(lineSpacer.Length - 10)}|");
            }
                
        }

        if (shwBnd)
        {
            Console.WriteLine($"={lineSpacer}");
        }
        else
        {
            Console.WriteLine($" {lineSpacer}");
        }
        Console.WriteLine(pageBtm);
    }

    public void PromptListing()
    {
        
        DateTime startTime = DateTime.UtcNow;
        
        string mainPrompt = base.PickPrompt();
        while(DateTime.UtcNow - startTime < TimeSpan.FromMilliseconds(base.GetDurationMiliseconds()))
        {
            
            this.DisplayNotebook(mainPrompt);

            Console.SetCursorPosition(6, this._notebookLines.Count + 4);
            Console.Write(">");
            string newEntry = Console.ReadLine();
            this._notebookLines.Add(newEntry);
        }
        this.DisplayNotebook(mainPrompt);
        Console.Write("\n. . . . . . . . . . ");
        for (int i = 0; i < 10; i++)
        {
            Console.Write("\b\b  \b\b");
            Thread.Sleep(1000);
        }
        base.End();
    }
}
