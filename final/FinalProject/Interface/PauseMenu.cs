

public class PauseMenu : UserInterface
{
    public PauseMenu()
    : base (@"
         ____                           __  __                  
        |  _ \ __ _ _   _ ___  ___     |  \/  | ___ _ __  _   _ 
        | |_) / _` | | | / __|/ _ \    | |\/| |/ _ \ '_ \| | | |
        |  __/ (_| | |_| \__ \  __/    | |  | |  __/ | | | |_| |
        |_|   \__,_|\__,_|___/\___|    |_|  |_|\___|_| |_|\__,_|
                                                        
        ",
        ["Quit", "Record Progress", "Resume"]
    )
    {
    }

    private string GetFilePath()
    {
        string filePath;
        do
        {
            filePath = this.GetInput(5, 8, ["Record file (.txt is suggested):\n\t>"])[0].Trim();
        }while (
            string.IsNullOrWhiteSpace(filePath) ||
            filePath.IndexOfAny(Path.GetInvalidPathChars()) >= 0
        );

        return filePath;
    }

    public void RecordProgress(char[,] fullMap)
    {
        string filePath = this.GetFilePath();

        using (StreamWriter outputFile = new StreamWriter(filePath))
        {
            int rows = fullMap.GetLength(0);
            int cols = fullMap.GetLength(1);

            // Iterate over each row
            for (int i = 0; i < rows; i++)
            {
                // Create a string for the current row
                char[] rowChars = new char[cols];
                for (int j = 0; j < cols; j++)
                {
                    rowChars[j] = fullMap[i, j];
                }

                // Convert the row array to a string and write it to the file
                string rowString = new string(rowChars);
                outputFile.WriteLine(rowString);
            }
        }
    }
}
