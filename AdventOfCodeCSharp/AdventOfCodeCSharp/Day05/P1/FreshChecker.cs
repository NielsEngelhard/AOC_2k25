using AdventOfCodeCSharp.Day05.P2;
using System;

namespace AdventOfCodeCSharp.Day05.P1;

public static class FreshChecker
{
    public static long SmartUniqueNumberFinder(IList<RangeRecord> rawRanges)
    {
        var orderedRanges = rawRanges.OrderBy(r => r.Start).ToList();
        var mergedRanges = RangeCombiner.MergeOverlappingRanges(orderedRanges);

        return CountDifferenceInRanges(mergedRanges);
    }

    public static long CountDifferenceInRanges(IList<RangeRecord> ranges)
    {
        long count = 0;

        foreach(var range in ranges)
        {
            var difference = range.End - range.Start + 1; // TODO: HIER KAN NOG WEL WAT ZITTEN QUA +1-1
            count += difference;
        }

        return count;
    }

    // Brute force did not work. The first record resulted in 2.3 billion records
    public static long GetUniqueNumbersInRanges(IList<RangeRecord> ranges, bool printStatus = true)
    {
        var uniqueNumbers = new HashSet<long>();

        var totalRanges = ranges.Count();

        for (var i=0; i<totalRanges; i++)
        {
            var range = ranges[i];

            if (printStatus)
            {
                Console.WriteLine($"{i}/{totalRanges}");
            }            

            var currentNumber = range.Start;

            while (range.End + 1 > currentNumber)
            {
                uniqueNumbers.Add(currentNumber);
                currentNumber++;
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
