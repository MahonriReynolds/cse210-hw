

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

    public void UseStamina(float staminaUsed)
    {
        this._stamina -= staminaUsed;
    }

    public float GetStaminaPercentage()
    {
        return this._stamina / this._maxStamina;
    }

    public void Rest()
    {
        this.Heal(0.1f);
        this._stamina += 0.5f;
    }
}

