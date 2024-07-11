
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

    public Game(int width, int height, int seed=0)
    {
        this._map = new Map(seed, width, height);
        this._camera = new Camera(width, height);
        this._player = new PlayerO(0, 0, 100, 5, 50);
        this._controller = new Controller();
        this._mesh = new EntityMesh(this._player);
        this._width = width;
        this._height = height;
    }

    private bool IsElapsed(float lastTriggeredTime, float intervalSeconds)
    {
        return (this._stopwatch.Elapsed.TotalSeconds - lastTriggeredTime) >= intervalSeconds;
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
    }

    private bool Iterate()
    {
        (int[], bool) input = this._controller.GetStep();
        int[] step = input.Item1;
        this._player.Advance(step);

        int[] playerPos = this._player.Locate();
        int[] centerPos = playerPos;

        int xPosDelta = Math.Abs(playerPos[0] - centerPos[0]);
        int yPosDelta = Math.Abs(playerPos[1] - centerPos[1]);

        if (xPosDelta > this._width / 10 || yPosDelta > this._height / 10)
        {
            centerPos[0] += step[0];
            centerPos[1] += step[1];
        }
        this._map.Extend(centerPos, this._width, this._height, step);
        
        (char[,], bool[,]) mapSelection = this._map.GetSelection(centerPos, this._width, this._height);

        if (IsElapsed(this._lastAddEnemy, 4.50f))
        {
            this._mesh.AddEnemy(centerPos, mapSelection.Item2, this._width, this._height);
            this._lastAddEnemy = (float)this._stopwatch.Elapsed.TotalSeconds;
        }

        if (IsElapsed(this._lastAdvanceEnemies, 0.25f))
        {
            this._mesh.AdvanceEnemies(centerPos, mapSelection.Item2);
            this._lastAdvanceEnemies = (float)this._stopwatch.Elapsed.TotalSeconds;
        }

        this._mesh.HandleCollisions(centerPos, mapSelection.Item2);

        this._camera.MakeNextFrame(
            mapSelection.Item1,
            this._mesh.GetSelection(centerPos, this._width, this._height)
        );

        this._camera.Display();
        
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
            ["Start", "Instructions", "Quit"]
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
                Console.WriteLine("Arrow keys to navigate");
                Console.WriteLine("Escape to pause");
                Console.WriteLine("Enter to leave instructions");
                Console.WriteLine("more to be filled out...");
                Console.ReadLine();
            }
            else if (choice == 2)
            {
                return false;
            }

        }while(choice == 1);

        while (isRunning)
        {
            if (this.Iterate())
            {
                if (pauseMenu.Display() == 1)
                {
                    return true;
                }
                this._camera.RecoverFrame();
            }
            Thread.Sleep(30);
        }

        return false;
    }
}


