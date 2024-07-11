
using System.Diagnostics;
public class Game
{
    private Map _map;
    private Camera _camera;
    private PlayerO _player;
    private Controller _controller;
    private EntityMesh _mesh;
    private int _width;
    private int _height;
    private Stopwatch _stopwatch;
    private float _lastAddEnemy;
    private float _lastAdvanceEnemies;
    private int[] _centerPos;

    public Game(int width, int height, int seed=0)
    {
        height -= 4;
        this._map = new Map(seed, width, height);
        this._camera = new Camera(width, height);
        this._player = new PlayerO(1, 0, 100, 5, 50);
        this._controller = new Controller();
        this._mesh = new EntityMesh(this._player);
        this._width = width;
        this._height = height;
    }

    private bool IsElapsed(float lastTriggeredTime, float intervalSeconds)
    {
        float scale = (float)Math.Max(1.0, this._stopwatch.Elapsed.TotalSeconds / 90);
        float adjustedInterval = intervalSeconds / scale;

        return (this._stopwatch.Elapsed.TotalSeconds - lastTriggeredTime) >= adjustedInterval;
    }

    private void SetUp()
    {
        this._lastAddEnemy = 0;
        this._lastAdvanceEnemies = 0;
        this._stopwatch = Stopwatch.StartNew();
        Console.Clear();

        int[] playerPos;
        (char[,], bool[,]) mapSelection;
        do
        {
            this._player.Advance([-1, 0]);
            playerPos = this._player.Locate();
            this._map.Extend(playerPos, this._width, this._height, [-1, 0]);
            mapSelection = this._map.GetSelection(playerPos, this._width, this._height);

        }while (!this._mesh.CheckValidCenter(mapSelection.Item2));

        this._centerPos = this._player.Locate();
    }

    private int Iterate()
    {
        (int[], int) input = this._controller.GetStep();
        int[] step = input.Item1;
        if (step[0] != 0 || step[1] != 0)
        {
            this._player.Advance(step);
        }
        else
        {
            this._player.Rest();
        }
        
        int[] playerPos = this._player.Locate();

        int xPosDelta = Math.Abs(playerPos[0] - this._centerPos[0]);
        int yPosDelta = Math.Abs(playerPos[1] - this._centerPos[1]);

        if (xPosDelta > this._width / 10 || yPosDelta > this._height / 10)
        {
            this._centerPos[0] += step[0];
            this._centerPos[1] += step[1];
        }
        this._map.Extend(this._centerPos, this._width, this._height, step);
        
        (char[,], bool[,]) mapSelection = this._map.GetSelection(this._centerPos, this._width, this._height);

        if (IsElapsed(this._lastAddEnemy, 5.00f))
        {
            this._mesh.AddEnemy(this._centerPos, mapSelection.Item2);
            this._lastAddEnemy = (float)this._stopwatch.Elapsed.TotalSeconds;
        }

        if (IsElapsed(this._lastAdvanceEnemies, 0.30f))
        {
            this._mesh.AdvanceEnemies(this._centerPos, mapSelection.Item2);
            this._lastAdvanceEnemies = (float)this._stopwatch.Elapsed.TotalSeconds;
        }

        this._mesh.HandleCollisions(this._centerPos, mapSelection.Item2);

        this._camera.MakeNextFrame(
            mapSelection.Item1,
            this._mesh.GetSelection(this._centerPos, this._width, this._height)
        );

        this._camera.Display(
            $"\n({playerPos[0]}, {playerPos[1]})\n" +
            $"Health:  {(int)(this._player.GetHealthPercentage() * 100)}%\n" +
            $"Stamina: {(int)(this._player.GetStaminaPercentage() * 100)}%"
        );
        
        return input.Item2;
    }

    public bool Run()
    {
        Menu mainMenu = new Menu(
            @"
             __  __       _            __  __                  
            |  \/  | __ _(_)_ __      |  \/  | ___ _ __  _   _ 
            | |\/| |/ _` | | '_ \     | |\/| |/ _ \ '_ \| | | |
            | |  | | (_| | | | | |    | |  | |  __/ | | | |_| |
            |_|  |_|\__,_|_|_| |_|    |_|  |_|\___|_| |_|\__,_|
            ", 
            ["New Game", "Instructions", "Quit"]
        );

        Menu pauseMenu = new Menu(
            @"
             ____                           __  __                  
            |  _ \ __ _ _   _ ___  ___     |  \/  | ___ _ __  _   _ 
            | |_) / _` | | | / __|/ _ \    | |\/| |/ _ \ '_ \| | | |
            |  __/ (_| | |_| \__ \  __/    | |  | |  __/ | | | |_| |
            |_|   \__,_|\__,_|___/\___|    |_|  |_|\___|_| |_|\__,_|
            ", 
            ["Resume", "Main Menu"]
        );

        bool isRunning = false;
        int choice;
        do
        {
            choice = mainMenu.Display();
            if (choice == 0)
            {
                isRunning = true;
                this.SetUp();
            }
            else if (choice == 1)
            {
                Console.Clear();
                Console.WriteLine(
                    @"
             ___           _                   _   _                 
            |_ _|_ __  ___| |_ _ __ _   _  ___| |_(_) ___  _ __  ___ 
             | || '_ \/ __| __| '__| | | |/ __| __| |/ _ \| '_ \/ __|
             | || | | \__ \ |_| |  | |_| | (__| |_| | (_) | | | \__ \
            |___|_| |_|___/\__|_|   \__,_|\___|\__|_|\___/|_| |_|___/
                    
                          
         * Navigate with ↑ ↓ ← →   
         * Pause with Esc

         * Survive for 1 minute
         ** Maybe try staying close to lakes and forests
                
         * Close this page with Enter       
                    "
                );
                Console.ReadLine();
            }
            else if (choice == 2)
            {
                return false;
            }

        }while(choice == 1);

        int iterationCode;

        while (isRunning)
        {
            iterationCode = this.Iterate();
            if (iterationCode == 1)
            {
                if (pauseMenu.Display() == 1)
                {
                    return true;
                }
                this._camera.RecoverFrame();
            }
            else if (iterationCode == 2)
            {
                //game lost screen
            }
            else if (iterationCode == 3)
            {
                //game won screen
            }
            Thread.Sleep(30);
        }

        return false;
    }
}


