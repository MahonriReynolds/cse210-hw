



public class Activity
{
    private string _name;
    private string _description;
    private int _duration;
    private List<Prompt> _prompts;
    private List<Prompt> _promptsRand;

    public Activity(string name, string description, List<string> prompts)
    {
        this._name = name;
        this._description = description;
        
        Console.WriteLine($"Welcome to the {this._name}.");
        Console.Write($"\n{this._description}\n");
        do
        {
            Console.Clear();
            Console.Write("\nHow long, in seconds, would you like for your session? ");
        }while(!int.TryParse(Console.ReadLine(), out this._duration));


        this._prompts = [];
        this._promptsRand = [];
        foreach (string prompt in prompts)
        {
            Prompt newPrompt = new Prompt(prompt);
            this._prompts.Add(newPrompt);
            this._promptsRand.Add(newPrompt);
        }

        Random random = new Random();
        // Randomize the promptsRand list without touching the first element.
        for (int i = this._promptsRand.Count - 1; i > 1; i--)
        {
            int k = random.Next(1, i + 1);
            (this._promptsRand[i], this._promptsRand[k]) 
                = (this._promptsRand[k], this._promptsRand[i]);
        }
    }

    public int Start()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {this._name}.");
        Console.Write($"\n{this._description}\n");
        return this._duration;
    }

    public void End()
    {
        Console.Clear();
        Console.WriteLine("\nWell done!");
        Console.Write($"\nYou have completed another {this._duration} seconds of the {this._name}.");
        Thread.Sleep(4000);
    }

    public string PickPrompt()
    {
        string tmp = "";

        for (int i = 0; i < this._promptsRand.Count; i++)
        {
            tmp = this._promptsRand[i].TryUse();
            if (tmp.Length > 0)
            {
                return tmp;
            }
        }

        for (int i = 0; i < this._promptsRand.Count; i++)
        {
            this._promptsRand[i].MakeAvailable();
        }

        return this._promptsRand[0].TryUse();
    }

    public int GetDurationMiliseconds()
    {
        return this._duration * 1000;
    }

}



