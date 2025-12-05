namespace AdventOfCodeCSharp.Day03.P1;

public static class BatteryChecker
{
    // Joltage is the 2 largest numbers pasted to each other
    public static int GetJoltage(string input)
    {
        BatteryNumber highestNumber = FindHighestNumber(input, includeLast: false);

        // Besef de naam
        var inputRightOfTheHighestNumber = input.Substring(highestNumber.Index + 1, input.Length - highestNumber.Index - 1);
        var secondHighestNumberRightOfTheFirstHighestNumber = FindHighestNumber(inputRightOfTheHighestNumber, includeLast: true);

        return int.Parse(($"{highestNumber.Value}{secondHighestNumberRightOfTheFirstHighestNumber.Value}"));
    }

    public static BatteryNumber FindHighestNumber(string input, bool includeLast)
    {
        int[] numbers = [.. input.Select(n => int.Parse(n.ToString()))];

        BatteryNumber highestNumber = new BatteryNumber { Index = 0, Value = numbers[0] };

        var nIterations = includeLast ? input.Length : input.Length - 1;

        for (var i = 1; i < nIterations; i++) // Vanaf 1 is OK
        {
            var number = numbers[i];

            if (number > highestNumber.Value)
            {
                highestNumber = new BatteryNumber { Index = i, Value = number };
            }
        }

        return highestNumber;
    }
}

// Stap 1, vind het hoogste nummer;
// Stap 2, vind het hoogste nummer rechts van dat nummer

public record BatteryNumber
{
    public int Value { get; set; }
    public int Index { get; set; }
}