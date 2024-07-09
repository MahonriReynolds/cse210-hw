

public class Game
{
    private Controller _controller;
    private Map _map;
    private Camera _camera;
    private PlayerO _player;
    private Mesh _mesh;
    private bool _isRunning;
    private int _width;
    private int _height;

    public Game(int width, int height, int seed=0)
    {
        this._controller = new Controller();
        this._map = new Map(seed, width, height);
        this._camera = new Camera(width, height);
        this._player = new PlayerO(0, 0, 100, 5, 50);
        this._mesh = new Mesh(this._player);
        this._isRunning = true;
        this._width = width;
        this._height = height;
    }

    public void RunGameLoop()
    {
        // main menu goes here?
        Console.Clear();

        while (this._isRunning)
        {
            int[] step = this._controller.GetStep();
            this._player.Advance(step);
            int[] playerPos = this._player.Locate();

            this._map.Extend(playerPos, this._width, this._height, step);
            this._camera.MakeNextFrame(this._map.GetSelection(playerPos, this._width, this._height));
            this._camera.Display();

            this._mesh.CheckForCollision();

            if (this._player.GetHealthPercentage() <= 0)
            {
                this._isRunning = false;
            }
        }
    }
}


