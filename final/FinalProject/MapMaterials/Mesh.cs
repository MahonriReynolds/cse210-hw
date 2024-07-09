
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

    public bool CheckCollision(int[] center, bool[,] pathways)
    {
        int offsetX = pathways.GetLength(0) / 2;
        int offsetY = pathways.GetLength(1) / 2;
        int[] playerCoords = this._player.Locate();
        int playerX = playerCoords[0] - (center[0] - offsetX);
        int playerY = playerCoords[1] - (center[1] - offsetY);

        if (!pathways[playerX, playerY])
        {
            return true;
        }

        foreach (EnemyX enemy in this._enemies)
        {
            int[] enemyPos = enemy.Locate();
            if (playerCoords[0] == enemyPos[0] && playerCoords[1] == enemyPos[1])
            {
                enemy.Aggro(this._player);
                this._player.TakeDamage(enemy.GetAttack());
                return true;
            }
        }
        

        return false;
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


