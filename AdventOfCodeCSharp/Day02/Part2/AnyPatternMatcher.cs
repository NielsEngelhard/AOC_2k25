namespace AdventOfCodeCSharp.Day02;

public static class AnyPatternMatcher
{
    public static long MatchAndCountPatterns(long start, long end)
    {
        long patternResultCount = 0;

        var currentNumber = start;
        while(currentNumber <= end) // While the currentNumber is not the end
        {
            string currentPattern = currentNumber.ToString();

            var hasPatternInIt = HasPatternInIt(currentNumber);
            if (hasPatternInIt)
            {
                Console.WriteLine("Found a pattern! " + currentPattern);
                patternResultCount += currentNumber;                
            }
            currentNumber++;
        }

        // Foreach number between start and end check if there is a pattern


        return patternResultCount;
    }

    public static bool HasPatternInIt(long input)
    {
        var inputAsString = input.ToString();

        // Sort of recursion

        // Do it for 1.2.3.4.5 .. up to half the size of the input after that you cant match anymore <--- so divided by 2
        for (var i=0; i< inputAsString.Length/2; i++) // Klopt deze gedeeld door 2??? TODO
        {
            var isMatch = IsMatch(inputAsString.Substring(0, i+1), inputAsString); // Kan altijd bij 0 beginnen anders sws geen pattern
            if (isMatch) return true;
        }

        return false;
    }

    // E.g. 22 in 2222222
    public static bool IsMatch(string possiblePattern, string input)
    {
        var wontFitForSure = (input.Length % possiblePattern.Length) != 0; // e.g. 8 input 3 pattern will never fit
        if (wontFitForSure)
        {
            return false;
        }

        var patternSize = possiblePattern.Length;

        var splittedInput = new List<string>();

        var numberOfSplits = input.Length / patternSize;


        for (var i=0; i< numberOfSplits; i++)
        {
            var startIndex = ((i) * possiblePattern.Length);
            splittedInput.Add(input.Substring(startIndex, possiblePattern.Length));
        }

        return !splittedInput.Any(item => item != possiblePattern);

        // 2.
    }
}