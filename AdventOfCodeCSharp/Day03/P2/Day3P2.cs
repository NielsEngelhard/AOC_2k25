namespace AdventOfCodeCSharp.Day03;

public class Day03P2
{
    const string FileName = "./Day03/real-input.txt";

    public long Execute()
    {
        var lines = GetInput();

        long total = 0;

        foreach (var line in lines)
        {
            total += AnyBatteryChecker.GetJoltage(line);
        }

        return total;
    }

    // In format start-end
    public IEnumerable<string> GetInput()
    {
        return File.ReadLines(FileName);
    }
}
