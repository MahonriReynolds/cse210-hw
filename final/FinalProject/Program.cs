
class Program
{
    static void Main(string[] args)
    {
        MainMenu mainMenu = new MainMenu();
        PauseMenu pauseMenu = new PauseMenu();
        PlayMenu playMenu = new PlayMenu();
        EndMenu endMenu = new EndMenu();
        while (Convert.ToBoolean(mainMenu.Display()))
        {
            Map map = new Map(1);
            Player player = new Player(['|', '>', '—', '<'], 10, 10);
            player.Spawn(16);
            Camera camera = new Camera(1, map, player);

            bool run = true;
            while (run)
            {
                camera.Display();

                int userInput = playMenu.GetMovement();
                if (userInput == 2)
                {
                    int pauseChoice = pauseMenu.Display();
                    if (pauseChoice == 1)
                    {
                        pauseMenu.RecordProgress(camera.Snapshot());
                    }
                    run = Convert.ToBoolean(pauseChoice);
                }
                else
                {
                    int direction = userInput > 0 ? 1 : -1;
                    if (Math.Abs(userInput) == 3)
                    {
                        char[] sequence = player.GetAttackSequence(direction);
                        for (int i = 0; i <= 3; i++)
                        {
                            player.Advance(direction);
                            camera.Display(sequence[i]);
                            Thread.Sleep(50);
                            if (camera.LookForCollision())
                            {
                                if (!player.TakeDamage(1))
                                {
                                    run = false;
                                }
                                player.Advance(-(userInput * 2));
                            }
                        }
                    }
                    else
                    {
                        player.Advance(direction);
                        Thread.Sleep(100);
                        if (camera.LookForCollision())
                        {
                            if (!player.TakeDamage(1))
                            {
                                run = false;
                            }
                            player.Advance(-(userInput * 2));
                        }
                    }  
                }

                if (player.GetHealth() == 0)
                {
                    if(endMenu.Display() == 1)
                    {
                        endMenu.RecordProgress(camera.Snapshot());
                    }
                }
            }
        }
    }
}
