
public class Player:Entity
{

    private int _stamina;
    private int _maxStamina;

    public Player(char[] model, int maxHealth, int maxStamina)
    : base (model, maxHealth)
    {
        this._maxStamina = maxStamina;
        this._stamina = this._maxStamina;
    }

    public int CheckStamina()
    {
        return this._stamina;
    }

    public void Rest()
    {
        this._stamina += 1;
    }
}
