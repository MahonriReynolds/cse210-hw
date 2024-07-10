

class Program
{
    static void Main(string[] args)
    {
        int gameWidth = 91;
        int gameHeight = 27;
        
        Game game = new Game(gameWidth, gameHeight, seed: 0);
        game.RunGameLoop();
    }
}
