
public class Player:Entity
{

    private float _stamina;
    private int _maxStamina;

    public Player(char[] model, int maxHealth, int maxStamina)
    : base (model, maxHealth)
    {
        this._maxStamina = maxStamina;
        this._stamina = this._maxStamina;
    }

    public float CheckStamina()
    {
        return this._stamina / this._maxStamina;
    }

    public bool UseStamina(int used)
    {
        if (this._stamina >= used)
        {
            this._stamina -= used;
            return true;
        }
        return false;
    }

    public void Rest()
    {
        this._stamina += 0.05f;
    }
}
