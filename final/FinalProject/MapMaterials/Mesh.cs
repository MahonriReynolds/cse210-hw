
public class Mesh
{
    private PlayerO _player;
    private List<EnemyX> _enemies;

    public Mesh(PlayerO player)
    {
        this._player = player;
        this._enemies = [];
    }

    public void AddEnemy(EnemyX newEnemy)
    {
        this._enemies.Add(newEnemy);
    }

    public void HandleCollision(int[] center, bool[,] pathways)
    {
        int offsetX = pathways.GetLength(0) / 2;
        int offsetY = pathways.GetLength(1) / 2;
        int[] playerCoords = this._player.Locate();
        int playerX = playerCoords[0] - (center[0] - offsetX);
        int playerY = playerCoords[1] - (center[1] - offsetY);

        if (!pathways[playerX, playerY])
        {
            this._player.BackStep();
        }

        foreach (EnemyX enemy in this._enemies)
        {
            int[] enemyCoords = enemy.Locate();
            int enemyX = playerCoords[0] - (center[0] - offsetX);
            int enemyY = playerCoords[1] - (center[1] - offsetY);

            if (!pathways[enemyX,enemyY])
            {
                this._enemies.Remove(enemy);
            }

            if (playerCoords[0] == enemyCoords[0] && playerCoords[1] == enemyCoords[1])
            {
                this._player.TakeDamage(enemy.GetAttack());
                this._player.BackStep();
            }
        }
    }

    public char[,] GetSelection(int[] center, int width, int height)
    {
        char[,] selection = new char[width, height];
        int[] playerPos = this._player.Locate();

        int offsetX = width / 2;
        int offsetY = height / 2;
        int playerX = playerPos[0] - (center[0] - offsetX);
        int playerY = playerPos[1] - (center[1] - offsetY);

        selection[playerX, playerY] = $"{this._player}"[0];

        foreach (EnemyX enemy in this._enemies)
        {
            int[] enemyPos = enemy.Locate();

            int enemyX = enemyPos[0] - (center[0] - offsetX);
            int enemyY = enemyPos[1] - (center[1] - offsetY);

            if (enemyX >= 0 && enemyX < width && enemyY >= 0 && enemyY < height)
            {
                selection[enemyX, enemyY] = $"{enemy}"[0]; 
            }
        }

        return selection;
    }
}


