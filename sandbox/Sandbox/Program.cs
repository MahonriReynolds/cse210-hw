
public class Program
{
    public static void Main()
    {
        string[] filePaths = { "./saves/default.txt", "./saves/test.txt"};

        var baseFileNames = filePaths.Select(path =>
        {
            // Check if the path is not empty or null
            if (string.IsNullOrWhiteSpace(path))
            {
                return string.Empty;
            }

            // Use Path.GetFileName to extract the file name
            return Path.GetFileNameWithoutExtension(path);
        }).ToArray();

        foreach (var baseFileName in baseFileNames)
        {
            Console.WriteLine(baseFileName);
        }
    }
}
