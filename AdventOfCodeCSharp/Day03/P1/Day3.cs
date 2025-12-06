namespace AdventOfCodeCSharp.Day03.P1;

public class Day03
{
    const string FileName = "./Day03/real-input.txt";

    public long Execute()
    {
        var lines = GetInput();

        long total = 0;

        foreach (var line in lines)
        {
            total += BatteryChecker.GetJoltage(line);
        }

        return total;
    }

    // In format start-end
    public IEnumerable<string> GetInput()
    {
        return File.ReadLines(FileName);
    }
}
