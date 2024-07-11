

class Program
{
    static void Main(string[] args)
    {
        int gameWidth = 75;
        int gameHeight = 25;
        Game game = new Game(gameWidth, gameHeight, seed: 0);
        while (game.Run()){}
    }
}
