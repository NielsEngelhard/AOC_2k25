namespace AdventOfCodeCSharp.Day05.P1;

public static class FreshChecker
{
    public static long GetUniqueNumbersInRanges(IEnumerable<RangeRecord> ranges)
    {
        var uniqueNumbers = new HashSet<long>();

        foreach (var range in ranges)
        {
            var numbersInRange = GetNumbersInRange(range);

            foreach(var n in numbersInRange)
            {
                uniqueNumbers.Add(n);
            }
        }

        return uniqueNumbers.Count;
    }

    public static IEnumerable<long> GetNumbersInRange(RangeRecord range)
    {
        var numbers = new List<long>();

        var currentNumber = range.Start;

        while(range.End+1 > currentNumber)
        {
            numbers.Add(currentNumber);
            currentNumber++;
        }

        return numbers;
    }

    public static bool IdIsInOneRange(IEnumerable<RangeRecord> ranges, long id)
    {
        foreach (RangeRecord range in ranges)
        {
            if (IsInRange(range.Start, range.End, id))
            {
                // Stop looping and return true
                return true;
            }
        }

        return false;
    }

    public static bool IsInRange(long start, long end, long value)
    {
        return value >= start && value <= end;
    }
}

public record RangeRecord
{
    public long Start { get; set; }
    public long End { get; set; }
}
