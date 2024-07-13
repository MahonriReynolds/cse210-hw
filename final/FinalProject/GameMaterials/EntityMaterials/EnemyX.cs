

public class EnemyX:Entity
{
    private PlayerO _targetPlayer;
    private float _attack;

    public EnemyX(int x, int y, float attack, PlayerO player)
    : base (x, y, 3, 'X')
    {
        this._targetPlayer = null;
        this._targetPlayer = player;
        this._attack = attack;
    }

    public float GetAttack()
    {
        return this._attack;
    }

    public void Follow()
    {
        int[] currentCoords = this.Locate();
        int[] targetCoords = this._targetPlayer.Locate();

        int[] difference = [targetCoords[0] - currentCoords[0], targetCoords[1] - currentCoords[1]];

        int[] step = [0, 0];

        List<int> validDirections = new List<int>();
        if (difference[0] != 0)
        {
            validDirections.Add(0);
        }
        if (difference[1] != 0)
        {
            validDirections.Add(1);
        }

        if (validDirections.Count > 0)
        {
            Random random = new Random();
            int directionIndex = random.Next(validDirections.Count);
            int direction = validDirections[directionIndex];

            if (direction == 0)
            {
                step[0] = Math.Sign(difference[0]);
            }
            else if (direction == 1)
            {
                step[1] = Math.Sign(difference[1]);
            }
        }

        base.Advance(step);
    }
}



