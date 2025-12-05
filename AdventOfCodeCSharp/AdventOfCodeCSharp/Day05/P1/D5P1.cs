using AdventOfCodeCSharp.Day03;

namespace AdventOfCodeCSharp.Day05.P1;

public class D5P1
{
    const string IdsFileName = "./Day05/real-input/ids.txt";
    const string RangesFileName = "./Day05/real-input/ranges.txt";

    public long Execute()
    {
        var ids = GetIds();
        var ranges = GetRanges();

        long total = 0;

        foreach (var id in ids)
        {
            var isFresh = FreshChecker.IdIsInOneRange(ranges, id);

            if (isFresh)
            {
                total++;
            }
        }

        return total;
    }

    public IEnumerable<long> GetIds()
    {
        return File.ReadLines(IdsFileName).Select(long.Parse);
    }

    public IEnumerable<RangeRecord> GetRanges()
    {
        return File.ReadLines(RangesFileName)
            .Select(StringToRangeRecord);
    }

    public RangeRecord StringToRangeRecord(string input)
    {
        var split = input.Split("-");

        return new RangeRecord
        {
            Start = long.Parse(split[0]),
            End = long.Parse(split[1])
        };
    }
}
