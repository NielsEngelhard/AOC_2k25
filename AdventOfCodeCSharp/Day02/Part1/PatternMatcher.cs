namespace AdventOfCodeCSharp.Day02.Part1;

public static class PatternMatcher
{
    public static long MatchAndCountPatterns(long start, long end)
    {
        long patternResultCount = 0;


        var currentNumber = start;
        while(currentNumber <= end) // While the currentNumber is not the end
        {
            string currentPattern = currentNumber.ToString();

            if ((currentPattern.Length % 2) != 0)
            {
                currentNumber++;
                continue;
            }

            var middleCharIndex = (currentPattern.Length / 2) - 1;
            var halfSize = currentPattern.Length / 2;

            var firstPart  = currentPattern.Substring(0, halfSize);
            var secondPart = currentPattern.Substring(middleCharIndex + 1, halfSize);

            var isPattern = firstPart == secondPart;
            if (isPattern)
            {
                Console.WriteLine("Found a pattern! " + currentPattern);
                patternResultCount += currentNumber;                
            }
            currentNumber++;
        }

        // Foreach number between start and end check if there is a pattern


        return patternResultCount;
    }
}