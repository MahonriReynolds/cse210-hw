
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
        int c = 5;
        string prompt = "";
        while (time <= base.GetDurationMiliseconds())
        {
            for (int i = h - 1; i > 0; i--)
            {
                frameArray[i] = (string[])frameArray[i - 1].Clone();
            }

            for (int j = 0; j < w; j++)
            {
                if (frameArray[1][j] == " 0 ")
                {
                    frameArray[1][j] = " o ";
                }
            }

            for (int j = 0; j < w; j++)
            {
                if (frameArray[h - 1][j] == " o ")
                {
                    frameArray[h - 1][j] = @"\_/";
                }
            }

            for (int j = 0; j < w; j++)
            {
                frameArray[0][j] = rand.Next(20) < 18 ? "   " : " 0 ";
            }


            Console.Clear();

            foreach (var row in frameArray)
            {
                Console.WriteLine(string.Join("", row));
            }

            if (time % 5000 == 0)
            {
                prompt = $"{base.PickPrompt()}...";
                c = 5;
            }

            if (time % 1000 == 0)
            {
                prompt = $"{prompt}\b \b{c}";
                c--;
            }

            Console.WriteLine($"\n\n{prompt}");
            
            Thread.Sleep(200);
            time += 200;
        }

        base.End();
    }
}

