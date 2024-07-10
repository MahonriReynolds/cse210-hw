

public class EnemyX:Entity
{
    private PlayerO _targetPlayer;

    public EnemyX(int x, int y)
    : base (x, y, 2, 1, 'X')
    {
        this._targetPlayer = null;
    }

    public void Aggro(PlayerO player)
    {
        this._targetPlayer = player;
    }

    public void Follow()
    {
        int[] currentCoords = this.Locate();
        int[] targetCoords = currentCoords;
        if (this._targetPlayer != null)
        {
            targetCoords = this._targetPlayer.Locate();
        }

        int[] difference = [targetCoords[0] - currentCoords[0], targetCoords[1] - currentCoords[1]];
        int[] step = [
            difference[0] != 0 ? difference[0] / Math.Abs(difference[0]) : 0,
            difference[1] != 0 ? difference[1] / Math.Abs(difference[1]) : 0
        ];

        this.Advance(step);
    }
}



