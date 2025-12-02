namespace AdventOfCodeCSharp.Day02;

public class Day02Part2
{
    const string FileName = "./Day02/real-input.txt";

    public long Execute()
    {
        var lines = GetParsedLines();

        long total = 0;

        foreach (var line in lines)
        {
            total += AnyPatternMatcher.MatchAndCountPatterns(line.StartNumber, line.EndNumber);
        }

        return total;
    }

    // In format start-end
    public IEnumerable<ParsedLine> GetParsedLines()
    {
        return File.ReadLines(FileName).First()
            .Split(",") // Split in comma
            .Select(line => line.Split("-")) // Split on "-"
            .Select(splitLine => new ParsedLine
            {
                StartNumber = long.Parse(splitLine[0]),
                EndNumber = long.Parse(splitLine[1])
            });
    }
}

public record ParsedLine {
    public required long StartNumber { get; set; }
    public required long EndNumber { get; set; }
}