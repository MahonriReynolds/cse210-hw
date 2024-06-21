
class Program
{
    static void Main(string[] args)
    {
        List<string> prompts = new List<string> { "Name:", "Age:", "Email:" };
        var ui = new UI();
        var responses = ui.GetTextInput(prompts);

        Console.Clear();
        foreach (var response in responses)
        {
            Console.WriteLine(response);
        }
    }
}

class UI
{
    public List<string> GetTextInput(List<string> prompts)
    {
        int currentPrompt = 0;
        List<string> responses = new List<string>(new string[prompts.Count]);
        ConsoleKeyInfo keyInfo;
        int maxLength = 50; // Assuming max length for input is 50 characters

        Console.Clear();
        Console.CursorVisible = false; // Hide the cursor

        do
        {
            Console.Clear();

            for (int i = 0; i < prompts.Count; i++)
            {
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

            Console.ResetColor();

            keyInfo = Console.ReadKey(intercept: true);

            switch (keyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    currentPrompt = (currentPrompt > 0) ? currentPrompt - 1 : prompts.Count - 1;
                    break;
                case ConsoleKey.DownArrow:
                    currentPrompt = (currentPrompt + 1) % prompts.Count;
                    break;
                case ConsoleKey.Enter:
                    Console.SetCursorPosition(0, prompts.Count + 1);
                    Console.CursorVisible = true; // Show the cursor again
                    Console.WriteLine("Responses submitted.");
                    return responses;
                case ConsoleKey.Backspace:
                    if (!string.IsNullOrEmpty(responses[currentPrompt]))
                    {
                        responses[currentPrompt] = responses[currentPrompt].Remove(responses[currentPrompt].Length - 1);
                    }
                    break;
                default:
                    if (keyInfo.KeyChar >= 32 && keyInfo.KeyChar <= 126 && (responses[currentPrompt] == null || responses[currentPrompt].Length < maxLength))
                    {
                        responses[currentPrompt] += keyInfo.KeyChar;
                    }
                    break;
            }

        } while (true);
    }
}
