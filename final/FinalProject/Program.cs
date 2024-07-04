using System;
using System.Threading.Tasks;

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
            player.Spawn(16);
            Camera camera = new Camera(1, map, player);

            bool run = true;
            int userInput = 0;
            bool pauseMenuActive = false;

            Task inputTask = Task.Run(async () =>
            {
                while (run)
                {
                    if (!pauseMenuActive)
                    {
                        userInput = playMenu.GetMovement();
                    }
                    await Task.Delay(25);
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
                    userInput = 0;
                }
                else if (userInput == 2)
                {
                    pauseMenuActive = true;
                }
                else if (userInput != 0)
                {
                    int direction = userInput > 0 ? 1 : -1;
                    if (Math.Abs(userInput) == 3 && player.UseStamina(1))
                    {
                        char[] sequence = player.GetAttackSequence(direction);
                        for (int i = 0; i <= 3; i++)
                        {
                            player.Advance(direction);
                            camera.Display(sequence[i]);
                            await Task.Delay(25);

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
                        await Task.Delay(25);

                        if (camera.LookForCollision())
                        {
                            if (!player.TakeDamage(1))
                            {
                                run = false;
                            }
                            player.Advance(-(userInput * 2));
                        }
                    }
                    userInput = 0;
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
                await Task.Delay(25);
            }
            await inputTask;
        }
    }
}
