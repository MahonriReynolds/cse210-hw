

class Program
{
    static void Main(string[] args)
    {
        int gameWidth = 80;
        int gameHeight = 30;
        Game game;
        do
        {
            game = new Game(gameWidth, gameHeight, seed: 0);
        }
        while (game.Run());
    }
}
