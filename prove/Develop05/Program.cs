
class Program
{
    static void Main()
    {
        UI ui = new UI();

        bool run = true;
        while (run)
        {
            int selection = ui.DisplayMainMenu();
            string[] saves = Directory.GetFiles("./saves/");

            string gamePath = "./saves/default.txt";
            switch (selection)
            {
                case 0:
                    gamePath = "";
                    break;
                case 1:
                    gamePath = saves[ui.DisplaySavesMenu(saves)];
                    break;
                case 2:
                    run = false;
                    break;
            }

            ui.DisplayHome(new GoalRecord(gamePath));

        }
    }
}
