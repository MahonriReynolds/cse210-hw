
// Found a cool console navigation method and used a couple variations of it 
// to get that last 7%

class Program
{
    static void Main()
    {
        UI ui = new UI();

        bool run = true;
        while (run)
        {
            int saveChoice = ui.DisplayMainMenu();
            string[] saves = Directory.GetFiles("./saves/");
            if (saves.Length < 1 && saveChoice == 1)
            {
                saveChoice = 0;
            }

            string gamePath = "./saves/default.txt";
            switch (saveChoice)
            {
                case 0:
                    string saveName;
                    do
                    {
                        saveName = ui.DisplayNewSave();
                        gamePath = $"./saves/{saveName}.txt";

                    }while (File.Exists(gamePath) || string.IsNullOrWhiteSpace(saveName));
                    
                    File.Create(gamePath).Dispose();
                    using (StreamWriter outputFile = new StreamWriter(gamePath))
                    {
                        outputFile.WriteLine("0");
                    }
                    break;
                case 1:
                    gamePath = saves[ui.DisplaySavesMenu(saves)];
                    break;
                case 2:
                    run = false;
                    break;
            }

            if (run)
            {
                GoalRecord gr = new GoalRecord(gamePath);
                int goalChoice;
                do
                {
                    goalChoice = ui.DisplayHome(gr);
                    if (goalChoice == -1)
                    {
                        string goalInfo = ui.DisplayNewGoal();
                        gr.AddGoal(goalInfo);
                    }
                    else if (goalChoice >= 0)
                    {
                        int optionChoice = ui.DisplayGoal(gr.GrabGoal(goalChoice));
                        switch (optionChoice)
                        {
                            case 0:
                                Goal currGoal = gr.GrabGoal(goalChoice);
                                gr.GainPoints(currGoal.CheckOff());
                                break;
                            case 1:
                                gr.RemoveGoal(goalChoice);
                                break;
                        }
                    }
                    gr.SaveGame();
                } while (goalChoice != -2);
            }
        }
    }
}
