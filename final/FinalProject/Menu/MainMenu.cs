

public class MainMenu : Menu
{
    private string[] _options;

    public MainMenu()
    {
        this._options = ["Start Game", "Exit"];
    }

    public int Display()
    {
        Console.Clear();
        Console.WriteLine(@"  __  __         _             __  __                     ");
        Console.WriteLine(@" |  \/  |  __ _ (_) _ __      |  \/  |  ___  _ __   _   _ ");
        Console.WriteLine(@" | |\/| | / _` || || '_ \     | |\/| | / _ \| '_ \ | | | |");
        Console.WriteLine(@" | |  | || (_| || || | | |    | |  | ||  __/| | | || |_| |");
        Console.WriteLine(@" |_|  |_| \__,_||_||_| |_|    |_|  |_| \___||_| |_| \__,_|");
        Console.WriteLine(@"                                                          ");
        int choice = this.GetChoice(5, 8, this._options, "Λ V to navigate\nEnter to select");
        return choice;
    }
}


