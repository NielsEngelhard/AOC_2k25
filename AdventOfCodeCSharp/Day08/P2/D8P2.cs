using AdventOfCodeCSharp.Day08.P1;

namespace AdventOfCodeCSharp.Day08.P2;

public static class D8P2
{
    const string FileName = $"Day08/real-input.txt";

    public static long Execute()
    {
        var input = GetInput();
        return CoordinateComparer.FindUntillLastIsConnected(input);
    }

    public static IList<ThreeDCoords> GetInput()
    {
        var lines = File.ReadLines(FileName);

        return [.. lines.Select((l, index) => MapLineToCoords(index + 1, l))];
    }

    public static ThreeDCoords MapLineToCoords(int id, string line)
    {
        var parts = line.Split(',');
        return new ThreeDCoords(id, int.Parse(parts[0]), int.Parse(parts[1]), int.Parse(parts[2]));
    }
}
