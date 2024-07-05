using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;

class Program
{
    static async Task Main(string[] args)
    {
        Stopwatch stopwatch = new Stopwatch();

        while (Convert.ToBoolean(new MainMenu().Display()))
        {
            int scale = 1;
            Map map = new Map(scale);
            List<X> theXs = new List<X>();
            Player player = new Player(new char[] { 'O', '>', '—', '<' }, 10, 10);
            player.Spawn(16, 26);
            Camera camera = new Camera(1, map, player, theXs);
            TimeSpan countdownDuration = TimeSpan.FromMinutes(5 * scale);
            stopwatch.Start();

            Random random = new Random();
            for (int i = 0; i < 200 * scale; i++)
            {
                theXs.Add(new X(random.Next(33, 3001 * scale), random.Next(25, 30)));
            }

            bool run = true;
            int[] userInput = new int[] { 0, 0 };
            bool pauseMenuActive = false;

            Task inputTask = Task.Run(async () =>
            {
                PlayMenu playMenu = new PlayMenu();
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
                camera.Watch(countdownDuration - stopwatch.Elapsed);
                if (pauseMenuActive)
                {
                    PauseMenu pauseMenu = new PauseMenu();
                    int pauseChoice = pauseMenu.Display();
                    if (pauseChoice == 1)
                    {
                        pauseMenu.RecordProgress(camera.Snapshot());
                    }
                    run = Convert.ToBoolean(pauseChoice);
                    pauseMenuActive = false;
                    userInput = new int[] { 0, 0 };

                     
                }
                else
                {
                    if (userInput[0] == -1 && userInput[1] == -1)
                    {
                        pauseMenuActive = true;
                    }
                    else if (userInput[0] != 0 || userInput[1] != 0)
                    {
                        int direction = userInput[0] == 0 ? 0 : (userInput[0] > 0 ? 1 : -1);
                        if (Math.Abs(userInput[0]) == 8 && player.UseStamina(1))
                        {
                            char[] sequence = player.GetAttackSequence(direction);
                            for (int i = 0; i <= 8; i++)
                            {
                                player.Advance(direction, userInput[1]);
                                int collision1 = camera.Watch(countdownDuration - stopwatch.Elapsed, sequence[i * 3 / 8]);
                                await Task.Delay(10);
                                switch (collision1)
                                {
                                    case 0:
                                        break;
                                    case 1:
                                        if (!player.TakeDamage(1))
                                        {
                                            run = false;
                                        }
                                        player.Advance(-(userInput[0] * 2), -(userInput[1] * 2));
                                        break;
                                    case 2:
                                        run = false;
                                        FinishMenu finishMenu = new FinishMenu();
                                        int finishChoice = finishMenu.Display();
                                        if (finishChoice == 1)
                                        {
                                            finishMenu.RecordProgress(camera.Snapshot());
                                        }
                                        break;
                                }
                            }
                        }
                        else
                        {
                            player.Advance(direction, userInput[1]);
                        }
                        int collision2 = camera.Watch(countdownDuration - stopwatch.Elapsed);
                        switch (collision2)
                        {
                            case 0:
                                break;
                            case 1:
                                if (!player.TakeDamage(1))
                                {
                                    run = false;
                                }
                                player.Advance(-(userInput[0] * 2), -(userInput[1] * 2));
                                break;
                            case 2:
                                run = false;
                                FinishMenu finishMenu = new FinishMenu();
                                int finishChoice = finishMenu.Display();
                                if (finishChoice == 1)
                                {
                                    finishMenu.RecordProgress(camera.Snapshot());
                                }
                                break;
                        }

                        userInput = new int[] { 0, 0 };
                    }
                    else
                    {
                        player.Rest();
                    }

                    if (player.GetHealth() == 0 || countdownDuration - stopwatch.Elapsed <= TimeSpan.Zero)
                    {
                        EndMenu endMenu = new EndMenu();
                        if (endMenu.Display() == 1)
                        {
                            endMenu.RecordProgress(camera.Snapshot());
                        }
                        run = false;
                    }

                    foreach (X x in theXs)
                    {
                        x.Follow();
                    }
                    await Task.Delay(50);
                }
            }
            await inputTask;
        }
    }
}
