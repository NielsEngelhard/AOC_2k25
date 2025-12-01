namespace AdventOfCodeCSharp.Day01;

public static class SafeDial
{
    const int MinValue = 0;
    const int MaxValue = 99;

    public static DialResult DialToRight(int currentValue, int valueToAdd)
    {
        var rawNewValue = currentValue + valueToAdd; // Can be more than allowed

        // Happy flow - not rotated
        if (rawNewValue <= MaxValue)
        {
            return new DialResult
            {
                NewPosition = rawNewValue,
                TotalClicks = 0 // Correct
            };
        }

        double totalClicks = (Convert.ToDouble(rawNewValue) / Convert.ToDouble(MaxValue));

        // Edge case what if it is more
        return new DialResult
        {
            NewPosition = rawNewValue % (MaxValue + 1),
            TotalClicks = Convert.ToInt32(Math.Floor(totalClicks))
        };
    }

    public static DialResult DialToLeft(int currentValue, int valueToSubtract)
    {
        var rawNewValue = currentValue - valueToSubtract;

        // Happy flow within range
        if (rawNewValue >= MinValue)
        {
            return new DialResult
            {
                NewPosition = rawNewValue,
                TotalClicks = rawNewValue == 0 ? 1 : 0
            };
        }

        // 20 - 170 = -150

        var absRawValue = int.Abs(rawNewValue) % (MaxValue + 1);

        // Hier gaat het mis 0.05 is niet altijd 1
        double totalClicks = (currentValue == 0 && valueToSubtract < MaxValue)
            ? 0
            : (Convert.ToDouble(int.Abs(rawNewValue)) / Convert.ToDouble(MaxValue + 1));

        if (absRawValue == 0)
        {
            return new DialResult
            {
                NewPosition = 0,
                TotalClicks = Convert.ToInt32(Math.Ceiling(totalClicks))
            };
        }

        return new DialResult
        {
            NewPosition = MaxValue - (absRawValue - 1),
            TotalClicks = Convert.ToInt32(Math.Ceiling(totalClicks))
        };

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

public record DialResult
{
    public int NewPosition { get; set; }
    public int TotalClicks { get; set; }
}