

public class Game
{
    private Controller _controller;
    private Map _map;
    // private Mesh _mesh;
    private Camera _camera;
    // private Player _player;
    // private List<EnemyX>;
    private int _difficulty;
    private bool _isRunning;
    private int _width;
    private int _height;

    public Game(int width, int height, int seed=0)
    {
        this._controller = new Controller();
        this._map = new Map(seed, width, height);
        this._camera = new Camera(width, height);
        this._difficulty = 1;
        this._isRunning = true;
        this._width = width;
        this._height = height;
    }

    public void RunGameLoop()
    {
        Console.Clear();

        if (this._difficulty == 0){}


        int[] playerPos = [0, 0];
        while (this._isRunning)
        {
            this._camera.MakeNextFrame(this._map.GetSelection(playerPos, this._width, this._height));
            this._camera.Display(this._width, this._height, playerPos);

            int[] step = this._controller.GetStep();
            playerPos[0] += step[0];
            playerPos[1] += step[1];
            this._map.Extend(playerPos, this._width, this._height, step);
        }
    }


}


