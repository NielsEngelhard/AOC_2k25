namespace AdventOfCodeCSharp.Day05.P1;

public static class FreshChecker
{
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
