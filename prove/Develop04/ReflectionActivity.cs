
public class ReflectionActivity : Activity
{
    private List<Prompt> _questions;
    private List<string> _animationSteps;

    public ReflectionActivity()
    : base(
        "Reflection Activity", 
        "This activity will help you reflect on times in your life when you have shown strength and resilience.\nThis will help you recognize the power you have and how you can use it in other aspects of your life.", 
        [
            "Think of a time when you stood up for someone else.", 
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        ]
        )
    {
        List<string> questions = [
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        ];
        this._questions = [];
        foreach (string question in questions)
        {
            Prompt newPrompt = new Prompt(question);
            this._questions.Add(newPrompt);
        }

        Random random = new Random();
        for (int i = this._questions.Count - 1; i > 0; i--)
        {
            int k = random.Next(1, i + 1);
            (this._questions[i], this._questions[k]) 
                = (this._questions[k], this._questions[i]);
        }

        this._animationSteps = ["⠋", "⠙", "⠹", "⠸", "⠼", "⠴", "⠦", "⠧", "⠇", "⠏"];
        
    }

    private string PickQuestion()
    {
        string tmp = "";

        for (int i = 0; i < this._questions.Count; i++)
        {
            tmp = this._questions[i].TryUse();
            if (tmp.Length > 0)
            {
                return tmp;
            }
        }

        for (int i = 0; i < this._questions.Count; i++)
        {
            this._questions[i].MakeAvailable();
        }

        return this._questions[0].TryUse();
    }

    public void PromptReflection()
    {
        string prompt = base.PickPrompt();
        string question = "";

        int time = 0;
        while (time < base.GetDurationMiliseconds())
        {
            Console.Clear();

            if (time % 30000 == 0)
            {
                question = $"{this.PickQuestion()}";
            }
            Console.WriteLine($"\n{prompt}\n");

            Console.WriteLine($"{this._animationSteps[time % 2500 / 250]} {29 - (time % 30000 / 1000)}");

            Console.WriteLine(question);
            Thread.Sleep(250);
            time += 250;
        }
    }
}

