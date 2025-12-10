namespace AdventOfCodeCSharp.Day08.P1;

public static class D8P1
{
    const string FileName = $"Day08/real-input.txt";

    public static long Execute()
    {
        var input = GetInput();
        var coordGroups = CoordinateComparer.FindAllCoordinateGroups(input);

        return 0;
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
