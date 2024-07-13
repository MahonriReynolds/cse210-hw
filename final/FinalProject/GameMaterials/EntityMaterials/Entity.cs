

public abstract class Entity
{
    private int _xPos;
    private int _yPos;
    protected int[] _prevStep;
    protected int _maxHealth;
    protected float _health;
    private float _attack;
    private char _model;

    public Entity(int x, int y, int maxHealth, float attack, char model)
    {
        this._xPos = x;
        this._yPos = y;
        this._maxHealth = maxHealth;
        this._health = maxHealth;
        this._attack = attack;
        this._model = model;
        this._prevStep = [0, 0];
    }

    public float GetAttack()
    {
        return this._attack;
    }

    public void TakeDamage(float damageTaken)
    {
        this._health -= damageTaken;
    }

    public float GetHealthPercentage()
    {
        return this._health / this._maxHealth;
    }

    public virtual void IncrementStatus()
    {
        this._health -= 0.1f;
        if (this._health > this._maxHealth)
        {
            this._health = this._maxHealth;
        }
    }

    public virtual void Advance(int[] step)
    {
        this._xPos += step[0];
        this._yPos += step[1];
        this._prevStep = step;
    }

    public virtual void BackStep()
    {
        this._xPos -= this._prevStep[0];
        this._yPos -= this._prevStep[1];
    }

    public int[] Locate()
    {
        return [this._xPos, this._yPos];
    }

    public override string ToString()
    {
        return $"{this._model}";
    }
}

