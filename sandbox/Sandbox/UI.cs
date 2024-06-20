using System;
using System.Collections.Generic;

public class UI
{
    public void DisplayMainMenu()
    {
        Console.Clear();
        Console.WriteLine("Welcome");
        Console.WriteLine();

        // Define prompts for each field
        List<string> prompts = new List<string>
        {
            "Enter your name:",
            "Enter your age:",
            "Enter your email:"
            // Add more prompts as needed
        };

        // Collect user inputs for each prompt
        List<string> inputs = new List<string>();
        foreach (var prompt in prompts)
        {
            string input = TextInputField(prompt);
            inputs.Add(input);
            Console.WriteLine(); // Add a blank line after each input field
        }

        // Example usage: Print collected inputs
        Console.WriteLine("Entered Information:");
        for (int i = 0; i < prompts.Count; i++)
        {
            Console.WriteLine($"{prompts[i]} {inputs[i]}");
        }
    }

    private string TextInputField(string prompt)
    {
        const int startX = 15;
        const int promptWidth = 20; // Adjust this based on your prompt length
        int currentY = Console.CursorTop;

        Console.CursorVisible = true;
        Console.SetCursorPosition(startX, currentY);
        Console.Write(prompt.PadRight(promptWidth)); // Pad the prompt to ensure consistent width

        Console.SetCursorPosition(startX + promptWidth + 1, currentY); // Move cursor to the input position

        string input = Console.ReadLine().Trim();

        Console.CursorVisible = false;

        return input;
    }
}
