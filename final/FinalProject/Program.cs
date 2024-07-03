
class Program
{
    static void Main(string[] args)
    {
        Map map = new Map();
        Player player = new Player(['@', '>', '-'], 1);
        player.Spawn(0);
        Camera camera = new Camera(1, map, player);
        

        bool run = true;
        while (run)
        {
            camera.Display();

            ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: true);

            if (keyInfo.Key == ConsoleKey.LeftArrow)
            {
                Console.WriteLine("Left arrow key pressed");
                player.Advance(-1);
            }
            else if (keyInfo.Key == ConsoleKey.RightArrow)
            {
                Console.WriteLine("Right arrow key pressed");
                player.Advance(1);
            }
            else if (keyInfo.Key == ConsoleKey.Escape)
            {
                Console.WriteLine("Exiting...");
                run = false;
            }
        }
    }
}
