


public abstract class MapMaker
{
    private readonly Random _random;
    private readonly int[] _table;
    private readonly float _scaler;

    public MapMaker(int seed, float scaler=0.01f, int tableSize=512)
    {
        _random = new Random(seed);
        this._table = new int [tableSize * 2];

        for (int i = 0; i < tableSize; i++)
        {
            this._table[i] = i;
        }

        for (int i = 0; i < tableSize; i++)
        {
            int j = _random.Next(tableSize);
            int temp = _table[i];
            _table[i] = _table[j];
            _table[j] = temp;
            _table[i + tableSize] = _table[i];
        }
        this._scaler = scaler;
    }

    private char WeightedRandom((char, float)[] weightedArray)
    {
        float totalWeight = weightedArray.Sum(item => item.Item2);
        float randomValue = (float)new Random().NextDouble() * totalWeight;

        foreach ((char character, float weight) in weightedArray)
        {
            randomValue -= weight;
            if (randomValue <= 0)
                return character;
        }

        return weightedArray.Last().Item1;
    }

    private (char, bool) NoiseToCell(float noise)
    {
        (char, float)[] water = [('_', 0.34f), (' ', 0.66f)];
        (char, float)[] sand = [('.', 0.35f), ('~', 0.35f), (',', 0.15f), (' ', 0.15f)];
        (char, float)[] forest = [('Ʌ', 0.25f), ('^', 0.25f), (' ', 0.50f)];
        (char, float)[] plains = [('⌄', 0.05f), ('.', 0.025f), (' ', 0.925f)];
        
        if (noise < this._scaler * 26)
        {
            return (WeightedRandom(forest), false);   
        }
        else if (noise < this._scaler * 50)
        {   
            return (WeightedRandom(plains), true);
        }
        else if (noise < this._scaler * 53)
        {
            return (WeightedRandom(sand), true);
        }
        else if (noise < this._scaler * 60)
        {
            return (WeightedRandom(water), false);
        }
        else if (noise < this._scaler * 63)
        {
            return (WeightedRandom(sand), true);
        }
        else if (noise < this._scaler * 75)
        {   
            return (WeightedRandom(plains), true);
        }
        else
        {
            return (WeightedRandom(forest), false);   
        }
    }

    private static float Fade(float t)
    {
        return t * t * t * (t * (t * 6 - 15) + 10);
    }

    private static float Lerp(float t, float a, float b)
    {
        return a + t * (b - a);
    }

    private static float Grad(int hash, float x, float y)
    {
        int h = hash & 7;
        float u = h < 4 ? x : y;
        float v = h < 4 ? y : x;
        return ((h & 1) == 0 ? u : -u) + ((h & 2) == 0 ? v : -v);
    }

    public float GenerateNoise(float xf, float yf)
    {
        int X = (int)Math.Floor(xf) & (this._table.GetLength(0) / 2 - 1);
        int Y = (int)Math.Floor(yf) & (this._table.GetLength(0) / 2 - 1);

        xf -= (int)Math.Floor(xf);
        yf -= (int)Math.Floor(yf);

        float u = Fade(xf);
        float v = Fade(yf);

        int A = this._table[X] + Y;
        int AA = this._table[A];
        int AB = this._table[A + 1];
        int B = this._table[X + 1] + Y;
        int BA = this._table[B];
        int BB = this._table[B + 1];

        float result = Lerp(v,
            Lerp(u, Grad(this._table[AA], xf, yf), Grad(this._table[BA], xf - 1, yf)),
            Lerp(u, Grad(this._table[AB], xf, yf - 1), Grad(this._table[BB], xf - 1, yf - 1)));

        return (result + 1) / 2;
    }

    public (char, bool) MakeCell(int x, int y)
    {
        return NoiseToCell(GenerateNoise(x * this._scaler, y * this._scaler));
    }
}

