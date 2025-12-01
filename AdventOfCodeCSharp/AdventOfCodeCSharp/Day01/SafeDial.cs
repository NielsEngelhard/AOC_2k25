namespace AdventOfCodeCSharp.Day01;

public static class SafeDial
{
    const int MinValue = 0;
    const int MaxValue = 99;

    public static int DialToRight(int currentValue, int valueToAdd)
    {
        var rawNewValue = currentValue + valueToAdd; // Can be more than allowed

        // Happy flow - not rotated
        if (rawNewValue <= MaxValue) return rawNewValue;

        // Edge case what if it is more
        return rawNewValue % (MaxValue + 1);
    }

    public static int DialToLeft(int currentValue, int valueToSubtract)
    {
        var rawNewValue = currentValue - valueToSubtract;
        
        // Happy flow within range
        if (rawNewValue >= MinValue) return rawNewValue;

        // 20 - 170 = -150

        var absRawValue = int.Abs(rawNewValue) % (MaxValue + 1);

        if (absRawValue == 0) return 0;

        return MaxValue - (absRawValue - 1);

    }

    public static RotationDirection DetermineDirection(string input)
    {
        switch (input.ToLower().FirstOrDefault())
        {
            case 'l':
                return RotationDirection.Left;
            case 'r':
                return RotationDirection.Right;
            default:
                return RotationDirection.Unknown;
        }
    }

    public static ParsedLine ParseLine(string input)
    {
        var parsedPostPart = input.Substring(1, input.Length-1);

        return new ParsedLine
        {
            DialSize = int.Parse(parsedPostPart),
            Direction = DetermineDirection(input)
        };
    }
}

public record ParsedLine
{
    public int DialSize { get; set; }
    public RotationDirection Direction { get; set; }
}

public enum RotationDirection { 
    Left,
    Right,
    Unknown
}