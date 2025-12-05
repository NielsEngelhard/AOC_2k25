using AdventOfCodeCSharp.Day03;

namespace AdventOfCodeCSharp.Day05.P1;

public class D5P1
{
    string basePath = AppDomain.CurrentDomain.BaseDirectory;

    string IdsFileName => $"{basePath}/Day05/real-input/ids.txt";
    string RangesFileName => $"{basePath}/Day05/real-input/ranges.txt";

    // P1
    public long ExecuteP1()
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

    // P2
    public long ExecuteP2()
    {
        var ranges = GetRanges();

        return FreshChecker.SmartUniqueNumberFinder(ranges);
    }

    public IEnumerable<long> GetIds()
    {
        return File.ReadLines(IdsFileName).Select(long.Parse);
    }

    public IList<RangeRecord> GetRanges()
    {
        return File.ReadLines(RangesFileName)
            .Select(StringToRangeRecord).ToList();
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
