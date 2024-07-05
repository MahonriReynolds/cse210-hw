
public class X:Entity
{
    private Player _playerTarget;

    public X(int x, int y)
    : base (['X', 'x', 'X', 'x'], 1)
    {
        this._playerTarget = null;
        this.Spawn(x, y);
    }

    public void Aggro(Player player)
    {
        this._playerTarget = player;
    }

    public void Follow()
    {
        int []currentPos = this.Locate();
        int []playerPos = currentPos;
        if (this._playerTarget != null)
        {
            playerPos = this._playerTarget.Locate();
            if (playerPos[0] < 30)
            {
                playerPos = currentPos;
            }
        }
        
        int[] difference = [ playerPos[0] - currentPos[0], playerPos[1] - currentPos[1] ];

        int xDirection = difference[0] != 0 ? difference[0] / Math.Abs(difference[0]) : 0;
        int yDirection = difference[1] != 0 ? difference[1] / Math.Abs(difference[1]) : 0;

        this.Advance(xDirection, yDirection);
    }
}
