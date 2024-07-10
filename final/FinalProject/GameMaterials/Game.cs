

public class Game
{
    private Map _map;
    private Camera _camera;
    private PlayerO _player;
    private Controller _controller;
    private Mesh _mesh;
    private bool _isRunning;
    private int _width;
    private int _height;

    public Game(int width, int height, int seed=0)
    {
        this._map = new Map(seed, width, height);
        this._camera = new Camera(width, height);
        this._player = new PlayerO(0, 0, 100, 5, 50);
        this._controller = new Controller(this._player);
        this._mesh = new Mesh(this._player);
        this._isRunning = true;
        this._width = width;
        this._height = height;
    }

    public void RunGameLoop()
    {
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
        
        
        int[] centerPos = playerPos;
        int[] step;

        while (this._isRunning)
        {
            (step, playerPos) = this._controller.MovePlayer();

            int xPosDelta = Math.Abs(playerPos[0] - centerPos[0]);
            int yPosDelta = Math.Abs(playerPos[1] - centerPos[1]);

            if (xPosDelta > this._width / 10 || yPosDelta > this._height / 10)
            {
                centerPos[0] += step[0];
                centerPos[1] += step[1];
                this._map.Extend(centerPos, this._width, this._height, step);
            }

            mapSelection = this._map.GetSelection(centerPos, this._width, this._height);

            this._mesh.HandleCollision(centerPos, mapSelection.Item2);

            this._camera.MakeNextFrame(
                mapSelection.Item1,
                this._mesh.GetSelection(centerPos, this._width, this._height)
            );

            this._camera.Display();
        }
    }
}


