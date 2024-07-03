
public abstract class Entity
{
    private int _xPos;

    private int _maxHealth;
    private int _health;
    private int _attack;
    private int _defense;

    private bool _isAlive;

    private char[] _model;

    public Entity(char[] model, int maxHealth, bool isAlive=true, int attack=1, int defense=1)
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

    public void Spawn(int xPos)
    {
        this._xPos = xPos;
    }

    public void Advance(int x)
    {
        this._xPos += x;
        if (this._xPos < 0)
        {
            this._xPos = 0;
        }
    }

    public int Locate()
    {
        return this._xPos;
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

    public char[] AnimateAttack()
    {
        return this._model;
    }

    public char Show()
    {
        return this._model[0];
    }
}
