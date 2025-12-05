namespace AdventOfCodeCSharp.Day03;

public static class AnyBatteryChecker
{
    // Joltage is the 2 largest numbers pasted to each other
    public static long GetJoltage(string input)
    {
        // Wat ik ga doen -> vind de hoogste, loop de hele tijd over de substring tot max 12 dan max 11 dan max 10 etc. BIJ GELIJK SPEL - wordt de linker al gepakt dus dat is priem

        const int numberLength = 12; // START
        string currentInput = input;

        string currentCombination = "";

        for (var i=0; i< numberLength; i++)
        {
            BatteryNumber highestNumber = FindHighestNumber(currentInput, numberLength - i - 1);

            currentCombination += highestNumber.Value.ToString();

            currentInput = currentInput.Substring(highestNumber.Index + 1, currentInput.Length - highestNumber.Index - 1);
        }

        return long.Parse(currentCombination);
    }

    public static BatteryNumber FindHighestNumber(string input, int nLastNumbersToExclude)
    {
        int[] numbers = [.. input.Select(n => int.Parse(n.ToString()))];

        BatteryNumber highestNumber = new BatteryNumber { Index = 0, Value = numbers[0] };

        var nIterations = input.Length - nLastNumbersToExclude;

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

public record BatteryNumber
{
    public int Value { get; set; }
    public int Index { get; set; }
}