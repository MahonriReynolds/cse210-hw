
class Program
{
    static async Task Main(string[] args)
    {
        MainMenu mainMenu = new MainMenu();
        PauseMenu pauseMenu = new PauseMenu();
        PlayMenu playMenu = new PlayMenu();
        EndMenu endMenu = new EndMenu();

        while (Convert.ToBoolean(mainMenu.Display()))
        {
            Map map = new Map(1);
            Player player = new Player(new char[] { '|', '>', '—', '<' }, 10, 10);
            player.Spawn(16, 26);
            Camera camera = new Camera(1, map, player);

            bool run = true;
            int[] userInput = [0, 0];
            bool pauseMenuActive = false;

            Task inputTask = Task.Run(async () =>
            {
                while (run)
                {
                    if (!pauseMenuActive)
                    {
                        userInput = playMenu.GetMovement();
                    }
                    await Task.Delay(50);
                }
            });

            while (run)
            {
                
                camera.Display();

                if (pauseMenuActive)
                {
                    int pauseChoice = pauseMenu.Display();
                    if (pauseChoice == 1)
                    {
                        pauseMenu.RecordProgress(camera.Snapshot());
                    }
                    run = Convert.ToBoolean(pauseChoice);
                    pauseMenuActive = false;
                    userInput = [0, 0];
                }
                else if (userInput[0] == -1 && userInput[1] == -1)
                {
                    pauseMenuActive = true;
                }
                else if (userInput[0] != 0 || userInput[1] != 0)
                {
                    int direction = userInput[0] == 0 ? 0 : (userInput[0] > 0 ? 1 : -1);
                    if (Math.Abs(userInput[0]) == 3 && player.UseStamina(1))
                    {
                        char[] sequence = player.GetAttackSequence(direction);
                        for (int i = 0; i <= 3; i++)
                        {
                            player.Advance(direction, userInput[1]);
                            camera.Display(sequence[i]);
                            await Task.Delay(50);

                            if (camera.LookForCollision())
                            {
                                if (!player.TakeDamage(1))
                                {
                                    run = false;
                                }
                                player.Advance(-(userInput[0] * 2), -(userInput[1] * 2));
                            }
                        }
                    }
                    else
                    {
                        player.Advance(direction, userInput[1]);
                        await Task.Delay(50);

                        if (camera.LookForCollision())
                        {
                            if (!player.TakeDamage(1))
                            {
                                run = false;
                            }
                            player.Advance(-(userInput[0] * 2), -(userInput[1] * 2));
                        }
                    }
                    userInput = [0, 0];
                }
                else
                {
                    player.Rest();
                }

                if (player.GetHealth() == 0)
                {
                    if (endMenu.Display() == 1)
                    {
                        endMenu.RecordProgress(camera.Snapshot());
                    }
                    run = false;
                }
                await Task.Delay(50);
            }
            await inputTask;
        }
    }
}
