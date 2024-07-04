

public class FinishMenu : PauseMenu
{
    public FinishMenu()
    : base ()
    {
        this._header = @"
         __  __             _            ___  _    _ 
        |  \/  |  __ _   __| |  ___     |_ _|| |_ | |
        | |\/| | / _` | / _` | / _ \     | | | __|| |
        | |  | || (_| || (_| ||  __/     | | | |_ |_|
        |_|  |_| \__,_| \__,_| \___|    |___| \__|(_)                                  
        ";
        this._options = ["Main Menu", "Record Finished Game"];
    }
}

