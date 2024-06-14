
public class BreathingActivity : Activity
{
    public BreathingActivity()
    : base(
        "Breathing Activity", 
        "This activity will help you relax by walking your through breathing in and out slowly.\nClear your mind and focus on your breathing.", 
        ["Breath In", "Breath Out"]
        )
    {

    }

    public void PromptBreathing()
    {

        int w = 30, h = 20;
        string[][] frameArray = new string[h][];
        for (int i = 0; i < h; i++)
        {
            frameArray[i] = new string[w];
            for (int j = 0; j < w; j++)
            {
                frameArray[i][j] = "   ";
            }
        }

        Random rand = new Random();
        int time = 0;
        string prompt = "";
        while (time <= base.GetDurationMiliseconds())
        {
            for (int i = h - 1; i > 0; i--)
            {
                frameArray[i] = (string[])frameArray[i - 1].Clone();
            }

            for (int j = 0; j < w; j++)
            {
                if (frameArray[h - 1][j] == " | ")
                {
                    frameArray[h - 1][j] = @"\_/";
                }
            }

            for (int j = 0; j < w; j++)
            {
                frameArray[0][j] = rand.Next(15) < 14 ? "   " : " | ";
            }

            Console.Clear();

            foreach (var row in frameArray)
            {
                Console.WriteLine(string.Join("", row));
            }

    
            if (time % 7000 == 0)
            {
                prompt = $"{base.PickPrompt()}....";
            }
            prompt = $"{prompt}\b \b{6 - (time % 7000 / 1000)}";

            Console.WriteLine($"\n\n{prompt}");
            
            Thread.Sleep(100);
            time += 100;
        }

        base.End();
    }
}

