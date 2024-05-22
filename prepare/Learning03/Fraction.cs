

public class Fraction
{
    private int _top;
    private int _bottom;



    public Fraction()
    {
        this._top = 1;
        this._bottom = 1;
    }

    public Fraction(int top)
    {
        this._top = top;
        this._bottom = 1;
    }

    public Fraction(int top, int bottom)
    {
        this._top = top;
        this._bottom = bottom;
    }



    public int GetTop()
    {
        return this._top;
    }

    public int GetBottom()
    {
        return this._bottom;
    }

    public void SetTop(int top)
    {
        this._top = top;
    }

    public void SetBottom(int bottom)
    {
        this._bottom = bottom;
    }



    public string GetFractionString()
    {
        return $"{this._top}/{this._bottom}";
    }

    public double GetDecimalValue()
    {
        return (double)this._top / (double)this._bottom;
    }


}