


public abstract class MapMaker
{
    private readonly Random _random;
    private readonly int[] _table;
    private readonly float _scaler;

    public MapMaker(int seed, float scaler=0.01f, int tableSize=256)
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

    private char NoiseToChar(float noise)
    {
        (char, float)[] water = [('_', 0.34f), (' ', 0.66f)];
        (char, float)[] sand = [('.', 0.50f), (',', 0.25f), (' ', 0.25f)];
        (char, float)[] forest = [('Ʌ', 0.25f), ('⌄', 0.25f), (' ', 0.50f)];
        (char, float)[] plains = [('⌄', 0.10f), (' ', 0.90f)];
        
        if (noise < 0.40f)
        {
            return WeightedRandom(water);
        }
        else if (noise < 0.42f)
        {
            return WeightedRandom(sand);
        }
        else if (noise < 0.70f)
        {   
            return WeightedRandom(plains);
        }
        else
        {
        return WeightedRandom(forest);   
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
        int X = (int)Math.Floor(xf) & 255;
        int Y = (int)Math.Floor(yf) & 255;

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

    public char MakeCell(int x, int y)
    {
        return NoiseToChar(GenerateNoise(x * this._scaler, y * this._scaler));
    }
}

