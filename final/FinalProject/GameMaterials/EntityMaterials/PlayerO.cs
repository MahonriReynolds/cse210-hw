

public class PlayerO:Entity
{
    private int _maxStamina;
    private float _stamina;
    private char[,] _dashSequence;

    public PlayerO(int x, int y, int maxHealth, float attack, int _maxStamina)
    : base (x, y, maxHealth, attack, 'O')
    {
        this._maxStamina = _maxStamina;
        this._stamina = _maxStamina;
        this._dashSequence = new char[,]{
            {'Ʌ', '|'},
            {'V', '|'},
            {'<', '—'},
            {'>', '—'}
        };
    }

    public char[] GetAttackSequence(int[] step)
    {
        Dictionary<int[], int> rowMap = new Dictionary<int[], int>{
            { [0, 1], 0 },
            { [1, 0], 1 },
            { [-1, 0], 2 },
            { [0, -1], 3 } 
        };

        int columns = this._dashSequence.GetLength(1);
        char[] result = new char[columns];
        
        for (int col = 0; col < columns; col++)
        {
            result[col] = this._dashSequence[rowMap[step], col];
        }

        return result;
        
    }

    public float GetStaminaPercentage()
    {
        return this._stamina / this._maxStamina;
    }

    public override void IncrementStatus()
    {
        this._health += 0.01f;
        if (this._health > this._maxHealth)
        {
            this._health = this._maxHealth;
        }
        
        this._stamina += this._maxStamina * 0.0005f;
        if (this._stamina > this._maxStamina)
        {
            this._stamina = this._maxStamina;
        }
    }

    public override void Advance(int[] step)
    {
        if (this._stamina > 0)
        {
            base.Advance(step);
            this._stamina -= this._maxStamina * 0.001f;
        }
    }

    public override void BackStep()
    {
        base.BackStep();
        this._stamina -= this._maxStamina * 0.001f;
        if (this._stamina < 0)
        {
            this._stamina = 0;
        }
    }
}

