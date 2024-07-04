
public abstract class Entity
{
    private int _xPos;
    private int _yPos;

    private int _maxHealth;
    private int _health;
    private int _attack;
    private int _defense;

    private bool _isAlive;

    // [stationary, right dash, end dash, left dash]
    private char[] _model;

    public Entity(char[] model, int maxHealth, bool isAlive=true, int attack=1, int defense=0)
    {
        this._model = model;

        this._maxHealth = maxHealth;

        if (isAlive)
        {
            this._health = maxHealth;
        }
        else
        {
            this._health = 0;
        }
        this._isAlive = isAlive;

        this._attack = attack;
        this._defense = defense;
    }

    public void Spawn(int xPos, int yPos)
    {
        this._xPos = xPos;
        this._yPos = yPos;
    }

    public void Advance(int x, int y)
    {
        this._xPos += x;
        if (this._xPos < 0)
        {
            this._xPos = 0;
        }

        this._yPos += y;
        if (this._yPos < 26)
        {
            this._yPos = 26;
        }

        if (this._yPos > 29)
        {
            this._yPos = 29;
        }
    }

    public float GetHealth()
    {
        return (float)this._health / this._maxHealth;
    }

    public int[] Locate()
    {
        return [this._xPos, this._yPos];
    }

    public bool TakeDamage(int damageAmount)
    {
        this._health -= damageAmount - this._defense;
        if (this._health <= 0)
        {
            this._isAlive = false;
        }
        return this._isAlive;
    }

    public void Heal(int healAmount)
    {
        int newHealth = this._health + healAmount;
        if (newHealth <= this._maxHealth)
        {
            this._health = newHealth;
        }
        else
        {
            this._health = this._maxHealth;
        }
    }

    public int DealDamage()
    {
        return this._attack;
    }

    public char[] GetAttackSequence(int direction)
    {
        // direction should be either -1 for left or 1 for right
        // if right, return the right attack animation sequence
        // else return the left sequence
        if (direction == -1)
        {
            return [this._model[3], this._model[2], this._model[3], this._model[0]];
        }
        return [this._model[1], this._model[2], this._model[1], this._model[0]];
    }

    public char Show()
    {
        return this._model[0];
    }
}
