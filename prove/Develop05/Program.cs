using System.IO;
using System.Text.Json;

class Program
{
    static void Main(string[] args)
    {

        SimpleGoal g1 = new SimpleGoal("test", "testing", 0);

        string jsonString = JsonSerializer.Serialize(g1);
        Console.WriteLine(jsonString);

        // GoalRecord gr = new GoalRecord();
        // UI ui = new UI();

        // bool run = true;
        // while (run)
        // {
        //     int selection = ui.DisplayMainMenu();

        //     string[] saves = Directory.GetFiles("./saves/");
            

        //     switch (selection)
        //     {
        //         case 0:
        //             List<Goal> blankGoals = [];
        //             ui.DisplayHome(blankGoals);
        //             break;
        //         case 1:
        //             List<Goal> goals = gr.GetGoals(saves[ui.DisplaySavesMenu(saves)]);
        //             ui.DisplayHome(goals);
        //             break;
        //         case 2:
        //             run = false;
        //             break;
        //     }
        // }
    }
}