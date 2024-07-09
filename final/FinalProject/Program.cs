

class Program
{
    static void Main(string[] args)
    {
        Game game = new Game(91, 27, seed: 9287);
        game.RunGameLoop();
    }
}
