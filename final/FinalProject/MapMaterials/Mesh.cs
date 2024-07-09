
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

    public bool CheckForCollision()
    {
        int[] playerCoords = this._player.Locate();
        foreach (EnemyX enemy in this._enemies)
        {
            if (playerCoords == enemy.Locate())
            {
                enemy.Aggro(this._player);
                this._player.TakeDamage(enemy.GetAttack());
                // enemy.TakeDamage(this._player.GetAttack());
                return true;
            }
        }
        return false;
    }
}


