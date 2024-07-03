

public class EndMenu : PauseMenu
{
    public EndMenu()
    : base ()
    {
        this._header = @"
          ____                            ___                 
         / ___| __ _ _ __ ___   ___      / _ \__   _____ _ __ 
        | |  _ / _` | '_ ` _ \ / _ \    | | | \ \ / / _ \ '__|
        | |_| | (_| | | | | | |  __/    | |_| |\ V /  __/ |   
         \____|\__,_|_| |_| |_|\___|     \___/  \_/ \___|_|   
        
        ";
        this._options = ["Quit", "Record Progress"];
    }

}




